

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Api.Models
{

    public class Song
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; } 
        public required Grid ChordGrid { get; set; }
        public required Grid MelodyGrid { get; set; }

    }
}
