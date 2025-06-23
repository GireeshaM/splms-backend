using Microsoft.EntityFrameworkCore;
using SlmsAppDataAccess.Models;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppDataAccess.VideoRepos
{
    public class VideoRepo : IVideoRepo
    {
        private readonly SlmsAppContext _context;
        public VideoRepo(SlmsAppContext context)
        {
            _context = context;
        }
        public async Task AddVideoAsync(Video video)
        {
            await _context.Videos.AddAsync(video);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVideoAsync(Video video)
        {
            _context.Videos.Update(video);
            await _context.SaveChangesAsync();
        }

        public async Task<Video> GetVideoByIdAsync(int? videoId)
        {
            return await _context.Videos.FindAsync(videoId);
        }
        public async Task<List<VideoSummeryDto>> GetVideosBySectionAsync(int sectionId)
        {
            return await _context.Videos
                .Where(v => v.SectionId == sectionId)
                .Select(v => new VideoSummeryDto
                {
                    VideoId = v.VideoId,
                    VideoName = v.VideoName,
                    Description = v.Description,
                    FileType = v.FileType,
                    VideoDuration = v.VideoDuration

                })
                .ToListAsync();
        }
        public async Task<Video> GetVideoByVideoIdAsync(int videoId)
        {
            return await _context.Videos
                .Where(v => v.VideoId == videoId)
                .Select(v => new Video
                {
                    VideoId = v.VideoId,
                    VideoName = v.VideoName,
                    FileType = v.FileType,
                    VideoUrl = v.VideoUrl // Only include what's absolutely required
                })
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task DeleteVideoAsync(int videoId)
        {
            var video = await _context.Videos.FindAsync(videoId);
            if (video != null)
            {
                _context.Videos.Remove(video);
                await _context.SaveChangesAsync();
            }
        }


    }

}