using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReverseEnginereeingEF.Models
{
    [Keyless]
    public partial class VNeighborhoodTotalPrice
    {
        [StringLength(30)]
        [Unicode(false)]
        public string CityName { get; set; } = null!;
        [StringLength(30)]
        [Unicode(false)]
        public string Neighborhood { get; set; } = null!;
        [Column("Total Wanted", TypeName = "money")]
        public decimal? TotalWanted { get; set; }
    }
}
