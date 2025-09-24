
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Microsoft.EntityFrameworkCore;
        using System.Text.Json;
        using System.Text.Json.Serialization;
namespace Api.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class GridsController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        public async Task<IActionResult> ParseRows(List<Grids> gridEntities)
        {
            var result = gridEntities.Select(grids => new Grids
            {
                Id = grids.Id,
                ChordGrid = grids.ChordGrid,
                MelodyGrid = grids.MelodyGrid,

            }).ToList();
            return Ok(result);
        }


        [HttpGet("{gridId}")]
        public async Task<IActionResult> GetGrid(int gridId)
        {
            var gridEntities = await _context.Grids.Where(grid => grid.Id == gridId).ToListAsync();
            return await ParseRows(gridEntities);
        }


        [HttpGet]
        public async Task<IActionResult> GetGrids()
        {
            var gridEntities = await _context.Grids.ToListAsync();
            return await ParseRows(gridEntities);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGrids([FromBody] Grids grids)
        {

            Console.WriteLine($"Creating grid with {grids.ChordGrid}");
            _context.Grids.Add(grids);
            await _context.SaveChangesAsync();
            return Ok(grids);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGrid(int gridId)
        {
            Console.WriteLine($"Deleting grid with ID: {gridId}");
            var rows = await _context.Grids.Where(grid => grid.Id == gridId).ExecuteDeleteAsync();
            return Ok(true);
        }
    }
}