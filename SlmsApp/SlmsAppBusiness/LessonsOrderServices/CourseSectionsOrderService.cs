using SlmsAppDataAccess.LessonsOrderRepo;
using SlmsAppDataAccess.Models;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.LessonsOrderServices
{
    public class CourseSectionsOrderService : ICourseSectionsOrderService
    {
        private readonly ICourseSectionsOrderRepository _repository;

        public CourseSectionsOrderService(ICourseSectionsOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CourseSectionsOrder>> GetSectionOrdersAsync(int userId, int courseId)
        {
            return await _repository.GetByUserAndCourseAsync(userId, courseId);
        }

        public async Task CreateOrUpdateSectionOrderAsync(CourseSectionsOrder order)
        {
            var existing = await _repository.GetByUserCourseSectionAsync(order.UserId, order.CreateCourseId, order.SectionId);

            if (existing == null)
            {
                await _repository.AddAsync(order);
            }
            else
            {
                existing.SectionOrder = order.SectionOrder;
                _repository.Update(existing);
            }

            await _repository.SaveChangesAsync();
        }
        public async Task<bool> SwapSectionOrdersAsync(SwapSectionOrderDto dto)
        {
            var first = await _repository.GetByUserCourseSectionAsync(dto.UserId, dto.CreateCourseId, dto.FirstSectionId);
            var second = await _repository.GetByUserCourseSectionAsync(dto.UserId, dto.CreateCourseId, dto.SecondSectionId);

            if (first == null || second == null)
                return false;

            int tempOrder = first.SectionOrder;

            // Step 1: Temporarily assign a value to break unique constraint
            first.SectionOrder = -1;
            _repository.Update(first);
            await _repository.SaveChangesAsync();

            // Step 2: Swap the actual values
            first.SectionOrder = second.SectionOrder;
            second.SectionOrder = tempOrder;

            _repository.Update(first);
            _repository.Update(second);
            await _repository.SaveChangesAsync();

            return true;
        }

    }
}
