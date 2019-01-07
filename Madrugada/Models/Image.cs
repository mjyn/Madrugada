using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Madrugada.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        public string Name { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }

        public int? LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        public bool IsCompare { get; set; }
        public bool IsCg { get; set; }

        public string Copyright { get; set; }

        public string Url { get; set; }

        public int? CompareId { get; set; }
        [ForeignKey("CompareId")]
        public Image CompareImage { get; set; }
    }
}
