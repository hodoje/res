using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Entities.Models
{
    public class PowerConsumptionData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Timestamp { get; set; }
        [Required]
        public double Consumption { get; set; }
        [Required]
        public string GeoAreaId { get; set; }
        [ForeignKey("GeoAreaId")]
        public GeoArea GeoArea { get; set; }
    }
}
