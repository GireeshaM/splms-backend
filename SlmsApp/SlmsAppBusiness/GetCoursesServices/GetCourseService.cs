using AutoMapper;
using SlmsAppDataAccess.GetCourses;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.GetCoursesServices
{
    public class GetCourseService : IGetCourseService
    {
        private readonly IGetCourseRepository _repo;
        private readonly IMapper _mapper;

        public GetCourseService(IGetCourseRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CreateCourseDto>> GetAllCoursesAsync() =>
            _mapper.Map<IEnumerable<CreateCourseDto>>(await _repo.GetAllCoursesAsync());

        public async Task<IEnumerable<CreateCourseDto>> GetCoursesByCategoryAsync(int categoryId) =>
            _mapper.Map<IEnumerable<CreateCourseDto>>(await _repo.GetCoursesByCategoryIdAsync(categoryId));

        public async Task<IEnumerable<CreateCourseDto>> GetCoursesBySubCategoryAsync(int subCategoryId) =>
            _mapper.Map<IEnumerable<CreateCourseDto>>(await _repo.GetCoursesBySubCategoryIdAsync(subCategoryId));

        public async Task<IEnumerable<CreateCourseDto>> GetCoursesByLevelAsync(string level) =>
            _mapper.Map<IEnumerable<CreateCourseDto>>(await _repo.GetCoursesByLevelAsync(level));

        public async Task<IEnumerable<CreateCourseDto>> GetCoursesByDurationAsync(string duration) =>
            _mapper.Map<IEnumerable<CreateCourseDto>>(await _repo.GetCoursesByDurationAsync(duration));

        public async Task<IEnumerable<CreateCourseDto>> GetCoursesBySkillAsync(string skill) =>
            _mapper.Map<IEnumerable<CreateCourseDto>>(await _repo.GetCoursesBySkillAsync(skill));

        public async Task<IEnumerable<string>> GetAllLevelsAsync() => await _repo.GetAllLevelsAsync();
        public async Task<IEnumerable<string>> GetAllDurationsAsync() => await _repo.GetAllDurationsAsync();
        public async Task<IEnumerable<string>> GetAllSkillsAsync() => await _repo.GetAllSkillsAsync();

        public async Task<IEnumerable<SubCategoryDto>> GetAllSubCategoriesAsync()
        {
            return await _repo.GetAllSubCategoriesAsync(); // Assuming this exists in your data access layer
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            return await _repo.GetAllCategoriesAsync();
        }

    }
}