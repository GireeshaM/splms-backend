using AutoMapper;
using SlmsAppDataAccess.CourseEnrollmentRepo;
using SlmsAppDataAccess.Models;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.CourseEnrollmentServices
{
    public class CourseEnrollmentService : ICourseEnrollmentService
    {
        private readonly ICourseEnrollmentRepository _repo;
        private readonly IMapper _mapper;

        public CourseEnrollmentService(ICourseEnrollmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseEnrollmentDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<CourseEnrollmentDto>>(await _repo.GetAllAsync());

        public async Task<CourseEnrollmentDto> GetByIdAsync(int id) =>
            _mapper.Map<CourseEnrollmentDto>(await _repo.GetByIdAsync(id));

        public async Task<IEnumerable<CourseEnrollmentDto>> GetByUserIdAsync(int userId) =>
            _mapper.Map<IEnumerable<CourseEnrollmentDto>>(await _repo.GetByUserIdAsync(userId));

        public async Task<IEnumerable<CourseEnrollmentDto>> GetByCourseIdAsync(int courseId) =>
            _mapper.Map<IEnumerable<CourseEnrollmentDto>>(await _repo.GetByCourseIdAsync(courseId));

        public async Task<CourseEnrollmentDto> AddOrUpdateAsync(CourseEnrollmentDto dto)
        {
            var entity = _mapper.Map<CourseEnrollment>(dto);
            var result = await _repo.AddOrUpdateAsync(entity);
            return _mapper.Map<CourseEnrollmentDto>(result);
        }

        public async Task<bool> DeleteAsync(int id) => await _repo.DeleteAsync(id);
    }

}
