using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Madrugada.Utilities.ListToStringConverter;

namespace Madrugada.Models
{
    public class Work
    {
        [Key]
        public int WorkId { get; set; }
        [Required]
        public string Name { get; set; }
        public string AlternativeName { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public string Cover { get; set; }
        public string OfficialHomepage { get; set; }

        [InverseProperty("Work")]
        public List<Location> Locations { get; set; }


        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public string TagsString { get; set; }
        [NotMapped]
        public IEnumerable<string> Tags
        {
            get
            {
                return StringGetter(TagsString);
            }
            set
            {
                TagsString = Setter(value.Cast<object>());
            }
        }
    }
}
