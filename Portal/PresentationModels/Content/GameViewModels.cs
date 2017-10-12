using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicArcade.ViewModels.Content
{
    public class GameViewModel
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public int? SortOrder { get; set; }
    }
    public class GameFeaturesViewModel : GameViewModel
    {
        public string Graphic400x200 { get; set; }
    }
    public class GameThumbnailViewModel : GameViewModel
    {
        public string Graphic100x100 { get; set; }
    }
    public class GameDetailsViewModel : GameViewModel
    {
        public string Graphic400x200 { get; set; }
        public string Graphic100x100 { get; set; }
        public string TechNotes { get; set; }
        public string Developer { get; set; }
    }
}
