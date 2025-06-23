using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace SlmsAppDataAccess.CourseContent
{
    public interface ISectionRepository
    {
        Task<IEnumerable<SectionDto>> GetAllAsync();
        Task<SectionDto> GetByIdAsync(int id);
        Task AddAsync(SectionDto section);
        Task UpdateAsync(SectionDto section);
        Task DeleteAsync(int id);
        Task<IEnumerable<SectionDto>> GetByCourseIdAsync(int courseId); // 👈 New

    }


}
