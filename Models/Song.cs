

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
        public List<GridColumn> ChordGrid { get; set; } = [];
        public List<GridColumn> MelodyGrid { get; set; } = [];
       


    }
}
