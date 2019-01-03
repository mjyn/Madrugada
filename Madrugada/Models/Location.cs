using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int? WorkId { get; set; }
        [ForeignKey("WorkId")]
        public Work Work { get; set; }

        [MaxLength(5000)]
        public string Text { get; set; }

        [MaxLength(300)]
        [DisplayName("地址")]
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Zoom { get; set; }

        public bool HasStreetView { get; set; }
        public double? StreetViewLatitude { get; set; }
        public double? StreetViewLongitude { get; set; }
        public int? StreetViewHeading { get; set; }
        public int? StreetViewPitch { get; set; }

        [InverseProperty("Location")]
        public List<Image> Images { get; set; }
        
        [InverseProperty("Location")]
        public List<Message> Messages { get; set; }

        public bool IsPublished { get; set; }
    }
}
