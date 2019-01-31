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
        [DisplayName("Work")]
        public Work Work { get; set; }

        [MaxLength(5000)]
        public string Text { get; set; }

        [MaxLength(300)]
        [DisplayName("Address")]
        public string Address { get; set; }
        [Range(-90, 90)]
        [DisplayName("Latitude")]
        public double Latitude { get; set; }
        [Range(-180, 180)]
        [DisplayName("Longitude")]
        public double Longitude { get; set; }
        [DisplayName("Zoom")]
        public int Zoom { get; set; }
        [DisplayName("HasStreetView")]
        public bool HasStreetView { get; set; }
        [Range(-90, 90)]
        [DisplayName("StreetViewLatitude")]
        public double? StreetViewLatitude { get; set; }
        [Range(-180, 180)]
        [DisplayName("StreetViewLongitude")]
        public double? StreetViewLongitude { get; set; }
        [DisplayName("StreetViewHeading")]
        public int? StreetViewHeading { get; set; }
        [DisplayName("StreetViewPitch")]
        public int? StreetViewPitch { get; set; }

        [InverseProperty("Location")]
        public List<Image> Images { get; set; }

        [InverseProperty("Location")]
        public List<Message> Messages { get; set; }
        [DisplayName("")]
        public bool IsPublished { get; set; }
    }
}
