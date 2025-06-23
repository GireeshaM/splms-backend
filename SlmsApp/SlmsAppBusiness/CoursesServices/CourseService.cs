using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SlmsAppDataAccess.InstructorCourses;
using SlmsAppDataAccess.Models;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.CoursesServices
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateCourseAsync(CreateCourseDto dto)
        {
            int categoryId;
            if (dto.CategoryId > 0)
            {
                categoryId = dto.CategoryId;
            }
            else if (!string.IsNullOrWhiteSpace(dto.CategoryName))
            {
                categoryId = await _repository.AddCategoryIfNotExistsAsync(dto.CategoryName);
            }
            else
            {
                throw new ArgumentException("Either CategoryId or CategoryName must be provided.");
            }

            int subCategoryId;
            if (dto.SubCategoryId > 0)
            {
                subCategoryId = dto.SubCategoryId;
            }
            else if (!string.IsNullOrWhiteSpace(dto.SubCategoryName))
            {
                subCategoryId = await _repository.AddSubCategoryIfNotExistsAsync(dto.SubCategoryName, categoryId);
            }
            else
            {
                throw new ArgumentException("Either SubCategoryId or SubCategoryName must be provided.");
            }

            var course = _mapper.Map<CreateCourse>(dto);
            course.CategoryId = categoryId;
            course.SubCategoryId = subCategoryId;

            await _repository.AddCourseAsync(course);
        }

        public async Task<IEnumerable<CreateCourseDto>> GetCoursesByUserIdAsync(int userId)
        {
            var courses = await _repository.GetCoursesByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<CreateCourseDto>>(courses);
        }


        public async Task<CreateCourseDto> GetByIdAsync(int id)
        {
            var course = await _repository.GetByIdAsync(id);
            return _mapper.Map<CreateCourseDto>(course);
        }

        public async Task<int> CreateOrUpdateAsync(CreateCourseDto dto)
        {
            var courseId = dto.CreateCourseId ?? 0;

            var existingCourse = await _repository.GetByTitleAsync(dto.CourseTitle);

            if (existingCourse != null && existingCourse.CreateCourseId != courseId)
            {
                throw new ApplicationException("A course with this title already exists.");
            }

            var entity = _mapper.Map<CreateCourse>(dto);
            entity.CourseCreatedDate = dto.CourseCreatedDate ?? DateTime.UtcNow;
            entity.CourseUpdatedDate = DateTime.UtcNow;

            try
            {
                return await _repository.CreateOrUpdateAsync(entity);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException?.Message.Contains("UNIQUE", StringComparison.OrdinalIgnoreCase) == true)
                {
                    throw new ApplicationException("Course with this title or demo video already exists.");
                }

                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<int> AddCategoryIfNotExistsAsync(string name)
        {
            return await _repository.AddCategoryIfNotExistsAsync(name);
        }

        public async Task<int> AddSubCategoryIfNotExistsAsync(string name, int categoryId)
        {
            await _repository.AddSubCategoryIfNotExistsAsync(name, categoryId);
            var subCategory = await _repository.GetSubCategoryByNameAndCategoryIdAsync(name, categoryId);
            return subCategory?.SubCategoriesId ?? throw new Exception("SubCategory not found after insert.");
        }

        public async Task MarkCourseAsSentToAdminAsync(int courseId)
        {
            await _repository.MarkCourseAsSentToAdminAsync(courseId);
        }

        public async Task<UserCourseDetailsDto> FetchUserCourseDetailsAsync(int courseId, int userId)
        {
            var course = await _repository.GetUserCourseDetailsAsync(courseId, userId);
            if (course == null) return null;

            var dto = _mapper.Map<UserCourseDetailsDto>(course);
            return dto;
        }

    }

}