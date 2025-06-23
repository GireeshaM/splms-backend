using SlmsAppDataAccess.Categories;
using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.CategoriesServices
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _repository;

        public SubCategoryService(ISubCategoryRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<SubCategory>> GetByCategoryIdAsync(int categoryId) => _repository.GetByCategoryIdAsync(categoryId);
        public Task<IEnumerable<SubCategory>> GetAllAsync() => _repository.GetAllAsync();
        public Task<SubCategory> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public Task AddAsync(SubCategory subCategory) => _repository.AddAsync(subCategory);
        public Task UpdateAsync(SubCategory subCategory) => _repository.UpdateAsync(subCategory);
        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }

}
