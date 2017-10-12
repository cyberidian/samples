using AtomicArcade.DataModels;
using AtomicArcade.DataModels.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicArcade.Repositories.Content
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly AADbContext _aaDbContext;

        public CategoryRepository(AADbContext dbContext)
        {
            _aaDbContext = dbContext;
        }

        public IEnumerable<Game> GetGamesByCategory(int categoryId)
        {
            var categoryGameIdList = _aaDbContext.GameCategories.Where(x => x.CategoryId == categoryId).Select(y => y.GameId).ToList();
            var categoryGameList = _aaDbContext.Games.Where(x => categoryGameIdList.Contains(x.GameId)).ToList();
            return categoryGameList;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _aaDbContext.Categories.ToList();
        }

        public Category Get(int categoryId)
        {
            return _aaDbContext.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
        }


    }
}
