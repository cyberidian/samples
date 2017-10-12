using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtomicArcade.DataModels.Content;
using AtomicArcade.Repositories;

namespace AtomicArcade.Repositories.Content.Games
{
    public interface IGamesRepository: IBaseRepository
    {
        Game Get(int gameId);
        IEnumerable<Game> Find(string text);
        IEnumerable<Game> FindByCategoryId(int categoryId);
        IEnumerable<Game> GetFeatured();
    }
}
