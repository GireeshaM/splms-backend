using Microsoft.EntityFrameworkCore;
using SlmsAppDataAccess.Models;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.LessonsOrderRepo
{
    public class LessonsOrderRepository : ILessonsOrderRepository
    {
        private readonly SlmsAppContext _context;

        public LessonsOrderRepository(SlmsAppContext context)
        {
            _context = context;
        }

        public async Task SaveOrUpdateOrdersAsync(List<LessonsOrderDto> orders)
        {
            foreach (var dto in orders)
            {
                if ((dto.VideoId.HasValue && dto.QuizId.HasValue) ||
                    (!dto.VideoId.HasValue && !dto.QuizId.HasValue))
                {
                    throw new InvalidOperationException("Only one of VideoId or QuizId must be set.");
                }

                // Delete existing duplicate if any
                if (dto.VideoId.HasValue)
                {
                    var existingVideoOrders = await _context.LessonsOrders
                        .Where(x => x.VideoId == dto.VideoId &&
                                    x.UserId == dto.UserId &&
                                    x.CourseId == dto.CourseId &&
                                    x.SectionId == dto.SectionId)
                        .ToListAsync();

                    if (existingVideoOrders.Any())
                    {
                        _context.LessonsOrders.RemoveRange(existingVideoOrders);
                    }
                }
                else if (dto.QuizId.HasValue)
                {
                    var existingQuizOrders = await _context.LessonsOrders
                        .Where(x => x.QuizId == dto.QuizId &&
                                    x.UserId == dto.UserId &&
                                    x.CourseId == dto.CourseId &&
                                    x.SectionId == dto.SectionId)
                        .ToListAsync();

                    if (existingQuizOrders.Any())
                    {
                        _context.LessonsOrders.RemoveRange(existingQuizOrders);
                    }
                }

                // Add the new order
                var newOrder = new Models.LessonsOrder
                {
                    UserId = dto.UserId,
                    CourseId = dto.CourseId,
                    SectionId = dto.SectionId,
                    VideoId = dto.VideoId,
                    QuizId = dto.QuizId,
                    OrderId = dto.OrderId
                };

                await _context.LessonsOrders.AddAsync(newOrder);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<int?> GetOrderIdByVideoIdAsync(int videoId)
        {
            return await _context.LessonsOrders
                .Where(x => x.VideoId == videoId)
                .Select(x => (int?)x.OrderId)
                .FirstOrDefaultAsync();
        }

        public async Task<int?> GetOrderIdByQuizIdAsync(int quizId)
        {
            return await _context.LessonsOrders
                .Where(x => x.QuizId == quizId)
                .Select(x => (int?)x.OrderId)
                .FirstOrDefaultAsync();
        }

        public async Task DeleteByVideoIdAsync(int videoId)
        {
            var entities = await _context.LessonsOrders
                .Where(x => x.VideoId == videoId)
                .ToListAsync();

            if (entities.Any())
            {
                _context.LessonsOrders.RemoveRange(entities);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteByQuizIdAsync(int quizId)
        {
            var entities = await _context.LessonsOrders
                .Where(x => x.QuizId == quizId)
                .ToListAsync();

            if (entities.Any())
            {
                _context.LessonsOrders.RemoveRange(entities);
                await _context.SaveChangesAsync();
            }
        }

    }

}
