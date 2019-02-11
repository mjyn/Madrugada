using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Madrugada.ViewModels.Home
{
    public class Index
    {
        public List<Models.Location> RecentlyUpdatedLocations { get; set; }
        public List<Models.Location> FeaturedLocations { get; set; }
        public List<Models.Work> FeaturedWorks { get; set; }
    }
}
