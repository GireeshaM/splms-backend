using SlmsAppDataAccess.CourseContent;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.SectionServicesBuss
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<IEnumerable<SectionDto>> GetAllSectionsAsync()
        {
            return await _sectionRepository.GetAllAsync();
        }

        public async Task<SectionDto> GetSectionByIdAsync(int id)
        {
            return await _sectionRepository.GetByIdAsync(id);
        }

        public async Task CreateSectionAsync(SectionDto section)
        {
            await _sectionRepository.AddAsync(section);
        }

        public async Task UpdateSectionAsync(SectionDto section)
        {
            await _sectionRepository.UpdateAsync(section);
        }

        public async Task DeleteSectionAsync(int id)
        {
            await _sectionRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SectionDto>> GetSectionsByCourseIdAsync(int courseId)
        {
            return await _sectionRepository.GetByCourseIdAsync(courseId);
        }
    }
}
