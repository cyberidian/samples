using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtomicArcade.DataModels.Content;
using AtomicArcade.ViewModels.Content;

namespace AtomicArcade.ViewLogic.Content
{
    public interface ICategoryVMConverter
    {
        IEnumerable<CategoryViewModel> GetViewModelList(IEnumerable<Category> categoryList);
        IEnumerable<CategoryDetailsViewModel> GetDetailsViewModelList(IEnumerable<Category> categoryList);
        CategoryDetailsViewModel GetDetailsViewModel(Category categoryList);
    }
}
