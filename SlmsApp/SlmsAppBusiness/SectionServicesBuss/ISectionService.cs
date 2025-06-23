using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.SectionServicesBuss
{
    public interface ISectionService
    {
        Task<IEnumerable<SectionDto>> GetAllSectionsAsync();
        Task<SectionDto> GetSectionByIdAsync(int id);
        Task CreateSectionAsync(SectionDto section);
        Task UpdateSectionAsync(SectionDto section);
        Task DeleteSectionAsync(int id);
        Task<IEnumerable<SectionDto>> GetSectionsByCourseIdAsync(int courseId);
    }
}
