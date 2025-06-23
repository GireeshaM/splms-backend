using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppBusiness.VideoServices
{
    public interface IvideoService
    {
        Task AddOrUpdateVideoAsync(AddVideotoVideo dto);
        Task<List<VideoSummeryDto>> GetVideosBySectionAsync(int sectionId);
        Task<(byte[] Data, string ContentType, string FileName)> GetDecryptedVideoAsync(int videoId);
        Task DeleteVideoAsync(int videoId);
    }
}
