using AutoMapper;
using SlmsAppDataAccess.Models;
using SlmsAppDataAccess.MyProfiles;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.ProfileService
{
    public class MyProfileService : IMyProfileService
    {
        private readonly IMyProfileRepository _repository;
        private readonly IMapper _mapper;

        public MyProfileService(IMyProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<MyProfileDto> GetProfileByUserIdAsync(int userId)
        {
            var profile = await _repository.GetProfileByUserIdAsync(userId);
            return _mapper.Map<MyProfileDto>(profile);
        }

        public async Task CreateOrUpdateProfileAsync(MyProfileDto profileDto)
        {
            var entity = _mapper.Map<Myprofile>(profileDto);
            entity.UpdateDate = DateTime.Now;
            if (entity.CreateDate == default)
                entity.CreateDate = DateTime.Now;

            await _repository.CreateOrUpdateProfileAsync(entity);
        }
    }
}
