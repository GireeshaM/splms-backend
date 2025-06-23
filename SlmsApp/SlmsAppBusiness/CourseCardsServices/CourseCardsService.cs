using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SlmsAppDataAccess.CourseCards;
using SlmsAppDataAccess.Models;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.CourseCardsServices
{
    public class CourseCardsService : ICourseCardsService
    {
        private readonly ICourseCardsRepository _repo;
        private readonly IMapper _mapper;
        private readonly SlmsAppContext _context;

        public CourseCardsService(ICourseCardsRepository repo, IMapper mapper, SlmsAppContext context)
        {
            _repo = repo;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<CourseCardDto>> GetAllCourseCardsAsync()
        {
            var courses = await _repo.GetAllCoursesAsync();
            return await BuildCourseCardDtos(courses);
        }

        public async Task<IEnumerable<CourseCardDto>> GetCourseCardsByUserIdAsync(int userId)
        {
            var courses = await _repo.GetCoursesByUserIdAsync(userId);
            return await BuildCourseCardDtos(courses, userId);
        }

        public async Task<IEnumerable<CourseCardDto>> GetEnrolledCoursesAsync(int userId)
        {
            var courses = await _repo.GetEnrolledCoursesByUserIdAsync(userId);
            return await BuildCourseCardDtos(courses, userId);
        }

        public async Task<IEnumerable<CourseCardDto>> GetWishlistedCoursesAsync(int userId)
        {
            var courses = await _repo.GetWishlistedCoursesByUserIdAsync(userId);
            return await BuildCourseCardDtos(courses, userId);
        }

        private async Task<IEnumerable<CourseCardDto>> BuildCourseCardDtos(IEnumerable<CreateCourse> courses, int? userId = null)
        {
            var dtos = _mapper.Map<List<CourseCardDto>>(courses);

            foreach (var dto in dtos)
            {
                var user = await _context.Users.FindAsync(dto.UserId);
                dto.FullName = user?.FullName;

                var profile = await _context.Myprofiles.FindAsync(dto.UserId);
                dto.PhotoPath = profile?.PhotoPath;

                dto.VideoDuration = await _context.Videos
                    .Where(v => v.SectionId == dto.CreateCourseId) // adjust if Section has CourseId ref
                    .SumAsync(v => (decimal?)v.VideoDuration) ?? 0;

                if (userId.HasValue)
                {
                    var enrollment = await _context.CourseEnrollments
                        .FirstOrDefaultAsync(e => e.UserId == userId && e.CreateCourseId == dto.CreateCourseId);
                    dto.IsEnrolled = enrollment != null;
                    dto.EnrollmentId = enrollment?.EnrollmentId;

                    var wishlist = await _context.UserWishlistAndVisiteds
                        .FirstOrDefaultAsync(w => w.UserId == userId && w.CreateCourseId == dto.CreateCourseId && w.CourseWishlist);
                    dto.IsWishlisted = wishlist != null;
                    dto.UserInteractionId = wishlist?.UserInteractionId;
                }
            }

            return dtos;
        }
    }
}