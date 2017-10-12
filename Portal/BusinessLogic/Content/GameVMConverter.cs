using AtomicArcade.DataModels.Content;
using AtomicArcade.ViewModels.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicArcade.ViewLogic.Content
{
    public class GameVMConverter:IGameVMConverter
    {
        public IEnumerable<GameViewModel> GetViewModelList(IEnumerable<Game> gameList) {

            var gameVMList =new List<GameViewModel>();

            //change this to LINQ projection
            foreach (Game game in gameList)
            {
                var gameVM = new GameViewModel()
                {
                    GameId = game.GameId,
                    Name = game.Name,
                    Link = game.Link,
                    Description = game.Description
                };
                gameVMList.Add(gameVM);
            }
            //Business Logic - sort based on ??

            return gameVMList;
        }
        public IEnumerable<GameFeaturesViewModel> GetFeaturesViewModelList(IEnumerable<Game> gameList)
        {
            var gameVMList = new List<GameFeaturesViewModel>();

            //change this to LINQ projection
            foreach (Game game in gameList)
            {
                var gameVM = new GameFeaturesViewModel()
                {
                    GameId = game.GameId,
                    Name = game.Name,
                    Link = game.Link,
                    Description = game.Description,
                    Graphic400x200 = game.Graphic400x200                    
                };
                gameVMList.Add(gameVM);
            }
            //Business Logic - sort based on ??

            return gameVMList;
        }
        public IEnumerable<GameThumbnailViewModel> GetThumbnailViewModelList(IEnumerable<Game> gameList) {
            var gameVMList = new List<GameThumbnailViewModel>();

            //change this to LINQ projection
            foreach (Game game in gameList)
            {
                var gameVM = new GameThumbnailViewModel()
                {
                    GameId = game.GameId,
                    Name = game.Name,
                    Link = game.Link,
                    Description = game.Description,
                    Graphic100x100 = game.Graphic100x100
                };
                gameVMList.Add(gameVM);
            }
            //Business Logic - sort based on ??

            return gameVMList;

        }
        public IEnumerable<GameDetailsViewModel> GetDetailsViewModelList(IEnumerable<Game> gameList)
        {
            var gameVMList = new List<GameDetailsViewModel>();

            //change this to LINQ projection
            foreach (Game game in gameList)
            {
                var gameVM = new GameDetailsViewModel()
                {
                    GameId = game.GameId,
                    Name = game.Name,
                    Link = game.Link,
                    Description = game.Description,
                    Graphic400x200 = game.Graphic400x200,
                    Graphic100x100 = game.Graphic100x100,
                    TechNotes = game.TechNotes,
                    Developer = game.Developer
                };
                gameVMList.Add(gameVM);
            }
            //Business Logic - sort based on ??

            return gameVMList;

        }
        public GameDetailsViewModel GetDetailsViewModel(Game game)
        {
            var gameVM = new GameDetailsViewModel()
            {
                GameId = game.GameId,
                Name = game.Name,
                Link = game.Link,
                Description = game.Description,
                Graphic400x200 = game.Graphic400x200,
                Graphic100x100 = game.Graphic100x100,
                TechNotes = game.TechNotes,
                Developer = game.Developer
            };
            return gameVM;
        }
    }
}
