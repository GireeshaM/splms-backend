using AutoMapper;
using SlmsAppDataAccess.Models;
using SlmsAppDataAccess.UserWishlist;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.UserWishlistServices
{
    public class UserWishlistService : IUserWishlistService
    {
        private readonly IUserWishlistRepository _repo;
        private readonly IMapper _mapper;

        public UserWishlistService(IUserWishlistRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task AddOrUpdateAsync(UserWishlistAndVisitedDto dto)
        {
            var existing = await _repo.GetAsync(dto.UserId, dto.CreateCourseId);
            if (existing == null)
            {
                var entity = _mapper.Map<UserWishlistAndVisited>(dto);
                entity.CourseWishlistDate = DateTime.Now;
                entity.CourseVisitedDate = DateTime.Now;
                await _repo.AddAsync(entity);
            }
            else
            {
                existing.CourseWishlist = dto.CourseWishlist;
                existing.CourseVisited = dto.CourseVisited;
                existing.CourseWishlistDate = DateTime.Now;
                existing.CourseVisitedDate = DateTime.Now;
                await _repo.UpdateAsync(existing);
            }
        }

        public async Task DeleteWishlistAsync(int userId, int courseId)
        {
            await _repo.DeleteAsync(userId, courseId);
        }

        public async Task<IEnumerable<UserWishlistAndVisitedDto>> GetWishlistByUserAsync(int userId)
        {
            var data = await _repo.GetWishlistByUserAsync(userId);
            return _mapper.Map<IEnumerable<UserWishlistAndVisitedDto>>(data);
        }

        public async Task<IEnumerable<UserWishlistAndVisitedDto>> GetWishlistByCourseAsync(int courseId)
        {
            var data = await _repo.GetWishlistByCourseAsync(courseId);
            return _mapper.Map<IEnumerable<UserWishlistAndVisitedDto>>(data);
        }

        public async Task<IEnumerable<UserWishlistAndVisitedDto>> GetVisitedByUserAsync(int userId)
        {
            var data = await _repo.GetVisitedByUserAsync(userId);
            return _mapper.Map<IEnumerable<UserWishlistAndVisitedDto>>(data);
        }

        public async Task<IEnumerable<UserWishlistAndVisitedDto>> GetVisitedByCourseAsync(int courseId)
        {
            var data = await _repo.GetVisitedByCourseAsync(courseId);
            return _mapper.Map<IEnumerable<UserWishlistAndVisitedDto>>(data);
        }
    }
}