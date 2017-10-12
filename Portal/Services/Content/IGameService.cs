using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtomicArcade.ViewModels.Content;

namespace AtomicArcade.Services.Content
{
    public interface IGameService
    {
        IList<GameViewModel> GetAllGames();
        IList<GameFeaturesViewModel> GetFeaturedGames();
        IList<GameThumbnailViewModel> GetThumbnailGames();
        IList<GameDetailsViewModel> GetDetailsGames();
    }
}
