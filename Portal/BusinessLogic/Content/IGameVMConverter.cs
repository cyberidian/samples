using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtomicArcade.DataModels.Content;
using AtomicArcade.ViewModels.Content;

namespace AtomicArcade.ViewLogic.Content
{
    public interface IGameVMConverter
    {
        IEnumerable<GameViewModel> GetViewModelList(IEnumerable<Game> gameList);
        IEnumerable<GameFeaturesViewModel> GetFeaturesViewModelList(IEnumerable<Game> gameList);
        IEnumerable<GameThumbnailViewModel> GetThumbnailViewModelList(IEnumerable<Game> gameList);
        IEnumerable<GameDetailsViewModel> GetDetailsViewModelList(IEnumerable<Game> gameList);
        GameDetailsViewModel GetDetailsViewModel(Game game);
    }
}
