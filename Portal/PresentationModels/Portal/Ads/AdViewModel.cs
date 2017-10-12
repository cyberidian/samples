using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicArcade.ViewModels.Portal.Ads
{
    public class AdViewModel
    {
        public int AdId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string BannerFile { get; set; }
        public int? SortOrder { get; set; }
    }
}
