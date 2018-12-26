using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Madrugada.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public int? WorkId { get; set; }
        [ForeignKey("WorkId")]
        public Work Work { get; set; }

        [InverseProperty("Location")]
        public List<Message> Messages { get; set; }
    }
}
