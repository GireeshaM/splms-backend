using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SlmsAppDataAccess.Models;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.GetCourses
{
    public class GetCourseRepository : IGetCourseRepository
    {
        private readonly IConfiguration _config;

        public GetCourseRepository(IConfiguration config)
        {
            _config = config;
        }

        private SqlConnection GetConnection() => new SqlConnection(_config.GetConnectionString("DefaultConnection"));

        public async Task<IEnumerable<CreateCourse>> GetAllCoursesAsync()
        {
            var sql = "SELECT * FROM CreateCourse";
            using var conn = GetConnection();
            return await conn.QueryAsync<CreateCourse>(sql);
        }

        public async Task<IEnumerable<CreateCourse>> GetCoursesByCategoryIdAsync(int categoryId)
        {
            var sql = "SELECT * FROM CreateCourse WHERE CategoryId = @CategoryId";
            using var conn = GetConnection();
            return await conn.QueryAsync<CreateCourse>(sql, new { CategoryId = categoryId });
        }

        public async Task<IEnumerable<CreateCourse>> GetCoursesBySubCategoryIdAsync(int subCategoryId)
        {
            var sql = "SELECT * FROM CreateCourse WHERE SubCategoryId = @SubCategoryId";
            using var conn = GetConnection();
            return await conn.QueryAsync<CreateCourse>(sql, new { SubCategoryId = subCategoryId });
        }

        public async Task<IEnumerable<CreateCourse>> GetCoursesByLevelAsync(string level)
        {
            var sql = "SELECT * FROM CreateCourse WHERE Level = @Level";
            using var conn = GetConnection();
            return await conn.QueryAsync<CreateCourse>(sql, new { Level = level });
        }

        public async Task<IEnumerable<CreateCourse>> GetCoursesByDurationAsync(string duration)
        {
            var sql = "SELECT * FROM CreateCourse WHERE Duration = @Duration";
            using var conn = GetConnection();
            return await conn.QueryAsync<CreateCourse>(sql, new { Duration = duration });
        }

        public async Task<IEnumerable<CreateCourse>> GetCoursesBySkillAsync(string skill)
        {
            var sql = "SELECT * FROM CreateCourse WHERE SkillsYouGain LIKE '%' + @Skill + '%'";
            using var conn = GetConnection();
            return await conn.QueryAsync<CreateCourse>(sql, new { Skill = skill });
        }

        public async Task<IEnumerable<string>> GetAllLevelsAsync()
        {
            var sql = "SELECT DISTINCT Level FROM CreateCourse";
            using var conn = GetConnection();
            return await conn.QueryAsync<string>(sql);
        }

        public async Task<IEnumerable<string>> GetAllDurationsAsync()
        {
            var sql = "SELECT DISTINCT Duration FROM CreateCourse WHERE Duration IS NOT NULL";
            using var conn = GetConnection();
            return await conn.QueryAsync<string>(sql);
        }

        public async Task<IEnumerable<string>> GetAllSkillsAsync()
        {
            var sql = "SELECT DISTINCT SkillsYouGain FROM CreateCourse WHERE SkillsYouGain IS NOT NULL";
            using var conn = GetConnection();
            return await conn.QueryAsync<string>(sql);
        }

        public async Task<IEnumerable<SubCategoryDto>> GetAllSubCategoriesAsync()
        {
            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                var query = @"
            SELECT 
                SubCategoriesId,
                Name AS Name,
                CategoryId,
                CreatedAt,
                UpdatedAt
            FROM SubCategories";

                var result = await connection.QueryAsync<SubCategoryDto>(query);
                return result.ToList();
            }
        }


        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var sql = @"SELECT CategoriesId, Name FROM Categories";
            using var connection = GetConnection(); 
            var result = await connection.QueryAsync<CategoryDto>(sql);
            return result;
        }

    }
}
