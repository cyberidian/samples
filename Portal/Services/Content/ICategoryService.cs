using AtomicArcade.ViewModels.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicArcade.Services.Content
{
    public interface ICategoryService
    {
        IList<GameThumbnailViewModel> GetGamesByCategory(int id);
        IList<CategoryViewModel> GetAllCategories();
        IList<CategoryDetailsViewModel> GetAllCategoriesDetails();
        CategoryDetailsViewModel GetCategory(int id);
    }
}
