using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Madrugada.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string OfficialHomepage { get; set; }
        public string Logo { get; set; }

        [InverseProperty("Company")]
        public List<Work> Works { get; set; }
        
    }
}
