using AtomicArcade.DataModels;
using AtomicArcade.DataModels.Content;
using AtomicArcade.Repositories.Content.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicArcade.Repositories.Content
{
    public class GamesRepository: IGamesRepository
    {

        private readonly AADbContext _aaDbContext;

        public object GameCategories { get; private set; }

        public GamesRepository(AADbContext dbContext)
        {
            _aaDbContext = dbContext;
        }


        public Game Get(int gameId)
        {
            return _aaDbContext.Games.FirstOrDefault(x => x.GameId == gameId);
        }

        public IEnumerable<Game> GetAll()
        {
            return _aaDbContext.Games.ToList();
        }

        public IEnumerable<Game> Find(string text)
        {
            return _aaDbContext.Games.Where(x => x.Name.StartsWith(text)).ToList();
        }

        public IEnumerable<Game> FindByCategoryId(int categoryId)
        {
            return _aaDbContext.Games.ToList();
        }
        public IEnumerable<Game> GetFeatured()
        {
            return _aaDbContext.Games.Where(x => x.Featured==true).ToList();
        }

    }
}
