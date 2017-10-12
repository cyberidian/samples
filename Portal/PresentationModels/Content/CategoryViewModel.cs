using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicArcade.ViewModels.Content
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int? SortOrder { get; set; }
    }

    public class CategoryDetailsViewModel : CategoryViewModel
    {
        public string Description { get; set; }
        public string BannerFile { get; set; }
    }

}
