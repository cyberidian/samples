using AtomicArcade.Repositories;
using AtomicArcade.Repositories.Content;
using AtomicArcade.Services.Content;
using AtomicArcade.ViewModels.Content;
using AtomicArcade.ViewLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class GameService: IGameService
    {
        private readonly AAPortalUnitOfWork _unitOfWork;
        private readonly GamesRepository _repository;
        private readonly GameVMConverter _vmConverter;

        public GameService()
        {
            _unitOfWork = new AAPortalUnitOfWork();
            _repository = _unitOfWork.GetRepository<GamesRepository>();
            _vmConverter = new GameVMConverter();
        }
        public IList<GameViewModel> GetAllGames()
        {
            var games = _repository.GetAll();
            var gamesList = _vmConverter.GetViewModelList(games).ToList();
            return gamesList;
        }
        public IList<GameFeaturesViewModel> GetFeaturedGames()
        {
            var games = _repository.GetAll();
            var gamesList = _vmConverter.GetFeaturesViewModelList(games).ToList();
            return gamesList;
        }
        public IList<GameThumbnailViewModel> GetThumbnailGames()
        {
            var games = _repository.GetAll();
            var gamesList = _vmConverter.GetThumbnailViewModelList(games).ToList();
            return gamesList;
        }
        public IList<GameDetailsViewModel> GetDetailsGames()
        {
            var games = _repository.GetAll();
            var gamesList = _vmConverter.GetDetailsViewModelList(games).ToList();
            return gamesList;
        }
    }
}
