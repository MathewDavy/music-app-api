

using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Grid
    {
        [Key]
        public int Id { get; set; }
        public ICollection<GridColumn> Columns { get; set; } = [];
    }
}
