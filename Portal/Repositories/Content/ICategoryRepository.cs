using AtomicArcade.DataModels.Content;
using AtomicArcade.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicArcade.Repositories.Content
{
    public interface ICategoryRepository : IBaseRepository
    {
        IEnumerable<Game> GetGamesByCategory(int id);
        IEnumerable<Category> GetAllCategories();
        Category Get(int categoryId);
    }
}
