﻿using Microsoft.EntityFrameworkCore;
using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SlmsAppContext _context;

        public CategoryRepository(SlmsAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync() => await _context.Categories.ToListAsync();

        public async Task<Category> GetByIdAsync(int id) => await _context.Categories.FindAsync(id);

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            bool isReferenced = await _context.SubCategories.AnyAsync(sc => sc.CategoryId == id);
            if (isReferenced)
            {
                throw new InvalidOperationException("Cannot delete category because it has associated subcategories.");
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