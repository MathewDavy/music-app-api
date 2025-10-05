
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Api.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class SongsController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        public async Task<IActionResult> ParseRows(List<Song> songs)
        {
            var result = songs.Select(song => new Song
            {
                Id = song.Id,
                ChordGrid = song.ChordGrid,
                MelodyGrid = song.MelodyGrid,
                Name = song.Name,

            }).ToList();
            return Ok(result);
        }


        [HttpGet("{songId}")]
        public async Task<IActionResult> GetSong(int songId)
        {
            var songs = await _context.Song.Where(song => song.Id == songId).ToListAsync();
            return await ParseRows(songs);
        }


        [HttpGet]
        public async Task<IActionResult> GetSongs()
        {
            var songs = await _context.Song.ToListAsync();
            return await ParseRows(songs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSong([FromBody] Song song)
        {      
            _context.Song.Add(song);
            await _context.SaveChangesAsync();
            return Ok(song);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSong(int songId)
        {
            Console.WriteLine($"Deleting grid with ID: {songId}");
            var rows = await _context.Song.Where(song => song.Id == songId).ExecuteDeleteAsync();
            return Ok(true);
        }
    }
}