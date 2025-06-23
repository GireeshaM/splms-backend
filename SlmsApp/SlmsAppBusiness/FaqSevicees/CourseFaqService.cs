using AutoMapper;
using SlmsAppDataAccess.Faq;
using SlmsAppDataAccess.Models;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.FaqSevicees
{
    public class CourseFaqService : ICourseFaqService
    {
        private readonly ICourseFaqRepository _repo;
        private readonly IMapper _mapper;

        public CourseFaqService(ICourseFaqRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseFaqDto>> GetAllFaqsAsync()
        {
            var faqs = await _repo.GetAllFaqsAsync();
            return _mapper.Map<IEnumerable<CourseFaqDto>>(faqs);
        }

        public async Task<IEnumerable<CourseFaqDto>> GetFaqsByCourseIdAsync(int courseId)
        {
            var faqs = await _repo.GetFaqsByCourseIdAsync(courseId);
            return _mapper.Map<IEnumerable<CourseFaqDto>>(faqs);
        }

        public async Task<CourseFaqDto> AddOrUpdateFaqAsync(CourseFaqDto faqDto)
        {
            var entity = _mapper.Map<CourseFaq>(faqDto);
            var result = await _repo.AddOrUpdateFaqAsync(entity);
            return _mapper.Map<CourseFaqDto>(result);
        }

        public async Task<bool> DeleteFaqAsync(int id)
        {
            return await _repo.DeleteFaqAsync(id);
        }
    }

}
