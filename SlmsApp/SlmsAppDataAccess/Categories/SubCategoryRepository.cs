using Microsoft.EntityFrameworkCore;
using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.Categories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly SlmsAppContext _context;

        public SubCategoryRepository(SlmsAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubCategory>> GetAllAsync() =>
            await _context.SubCategories.ToListAsync();

        public async Task<IEnumerable<SubCategory>> GetByCategoryIdAsync(int categoryId) =>
            await _context.SubCategories.Where(sc => sc.CategoryId == categoryId).ToListAsync();

        public async Task<SubCategory> GetByIdAsync(int id) =>
            await _context.SubCategories.FindAsync(id);

        public async Task AddAsync(SubCategory subCategory)
        {
            await _context.SubCategories.AddAsync(subCategory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SubCategory subCategory)
        {
            _context.SubCategories.Update(subCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var subCategories = await _context.SubCategories.Where(sc => sc.CategoryId == id).ToListAsync();
            if (subCategories.Any())
            {
                // You can either remove these subcategories manually
                _context.SubCategories.RemoveRange(subCategories);
            }

            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }



    }

}
