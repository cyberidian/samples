using AtomicArcade.DataModels.Content;
using AtomicArcade.ViewModels.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicArcade.ViewLogic.Content
{
    public class CategoryVMConverter: ICategoryVMConverter
    {
        public IEnumerable<CategoryViewModel> GetViewModelList(IEnumerable<Category> categoryList)
        {
            var categoryVMList = new List<CategoryViewModel>();

            //change this to LINQ projection
            foreach (Category category in categoryList)
            {
                var categoryVM = new CategoryViewModel()
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name
                };
                categoryVMList.Add(categoryVM);
            }
            //Business Logic - sort based on ??

            return categoryVMList;
        }
        public IEnumerable<CategoryDetailsViewModel> GetDetailsViewModelList(IEnumerable<Category> categoryList)
        {
            var categoryVMList = new List<CategoryDetailsViewModel>();

            //change this to LINQ projection
            foreach (Category category in categoryList)
            {
                var categoryVM = new CategoryDetailsViewModel()
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description,
                    BannerFile = category.BannerGraphicFile
                };
                categoryVMList.Add(categoryVM);
            }
            //Business Logic - sort based on ??

            return categoryVMList;

        }
        public CategoryDetailsViewModel GetDetailsViewModel(Category category)
        {
            var categoryVM = new CategoryDetailsViewModel()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
                BannerFile = category.BannerGraphicFile
            };
            return categoryVM;
        }

    }
}
