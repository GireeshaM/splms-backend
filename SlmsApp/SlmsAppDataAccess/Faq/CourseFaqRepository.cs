using Microsoft.EntityFrameworkCore;
using SlmsAppDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.Faq
{
    public class CourseFaqRepository : ICourseFaqRepository
    {
        private readonly SlmsAppContext _context;

        public CourseFaqRepository(SlmsAppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CourseFaq>> GetAllFaqsAsync()
            => await _context.CourseFaqs.ToListAsync();

        public async Task<IEnumerable<CourseFaq>> GetFaqsByCourseIdAsync(int courseId)
            => await _context.CourseFaqs
                            .Where(f => f.CreateCourseId == courseId)
                            .ToListAsync();

        public async Task<CourseFaq> GetFaqByIdAsync(int id)
            => await _context.CourseFaqs.FindAsync(id);

        public async Task<CourseFaq> AddOrUpdateFaqAsync(CourseFaq faq)
        {
            if (faq.CourseFaqsId > 0)
            {
                var existing = await _context.CourseFaqs.FindAsync(faq.CourseFaqsId);
                if (existing != null)
                {
                    existing.FaqQuestion = faq.FaqQuestion;
                    existing.FaqAnswer = faq.FaqAnswer;
                    existing.FaqUpdatedDate = DateTime.Now;
                }
            }
            else
            {
                faq.FaqCreatedDate = DateTime.Now;
                await _context.CourseFaqs.AddAsync(faq);
            }

            await _context.SaveChangesAsync();
            return faq;
        }

        public async Task<bool> DeleteFaqAsync(int id)
        {
            var faq = await _context.CourseFaqs.FindAsync(id);
            if (faq == null) return false;

            _context.CourseFaqs.Remove(faq);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
