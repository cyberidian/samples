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
using AtomicArcade.DataModels.Content;
using AtomicArcade.Repositories.Content.Games;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AAPortalUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _repository;
        private readonly CategoryVMConverter _vmCategoryConverter;
        private readonly GameVMConverter _vmGameConverter;

        public CategoryService()
        {
            _unitOfWork = new AAPortalUnitOfWork();
            _repository = _unitOfWork.GetRepository<CategoryRepository>();
            _vmCategoryConverter = new CategoryVMConverter();
            _vmGameConverter = new GameVMConverter();
        }

        public IList<GameThumbnailViewModel> GetGamesByCategory(int id)
        {
            var games = _repository.GetGamesByCategory(id);
            var gamesList = _vmGameConverter.GetThumbnailViewModelList(games).ToList();
            return gamesList;
        }
        public IList<CategoryViewModel> GetAllCategories()
        {
            var categories = _repository.GetAllCategories();
            var categoryList = _vmCategoryConverter.GetViewModelList(categories).ToList();
            return categoryList;
        }
        public IList<CategoryDetailsViewModel> GetAllCategoriesDetails()
        {
            var categories = _repository.GetAllCategories();
            var categoryList = _vmCategoryConverter.GetDetailsViewModelList(categories).ToList();
            return categoryList;
        }
        public CategoryDetailsViewModel GetCategory(int id)
        {
            var category = _repository.Get(id);
            var categoryVm = _vmCategoryConverter.GetDetailsViewModel(category);
            return categoryVm;
        }
    }
}
