

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Api.Models
{

    public class Grid
    {
            
        public List<GridColumn> Columns { get; set; } = [];
        public required string Synth { get; set; }

    }
}
