using SlmsAppDataAccess.Models;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.VideoRepos
{
    public interface IVideoRepo
    {
        Task AddVideoAsync(Video video);
        Task UpdateVideoAsync(Video video);
        Task<Video> GetVideoByIdAsync(int? videoId);
        Task<List<VideoSummeryDto>> GetVideosBySectionAsync(int sectionId);
        Task<Video> GetVideoByVideoIdAsync(int Videoid);
        Task DeleteVideoAsync(int videoId);
    }


}
