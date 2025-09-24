
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Microsoft.EntityFrameworkCore;
namespace Api.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class GridsController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        public async Task<IActionResult> ParseRows(List<Grid> gridEntities)
        {
            var result = gridEntities.Select(grid => new Grid
            {
                Id = grid.Id,
                Columns = grid.Columns

            }).ToList();
            return Ok(result);
        }


        [HttpGet("{gridId}")]
        public async Task<IActionResult> GetGrid(int gridId)
        {
            var gridEntities = await _context.Grid.Where(grid => grid.Id == gridId).ToListAsync();
            return await ParseRows(gridEntities);
        }


        [HttpGet]
        public async Task<IActionResult> GetGrids()
        {
            var gridEntities = await _context.Grid.ToListAsync();
            return await ParseRows(gridEntities);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGrid([FromBody] Grid grid)
        {
            _context.Grid.Add(grid);
            await _context.SaveChangesAsync();
            return Ok(grid);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGrid(int gridId)
        {
            Console.WriteLine($"Deleting grid with ID: {gridId}");
            var rows = await _context.Grid.Where(grid => grid.Id == gridId).ExecuteDeleteAsync();
            return Ok(true);
        }
    }
}