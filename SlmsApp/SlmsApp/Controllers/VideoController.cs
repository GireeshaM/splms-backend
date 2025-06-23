using Microsoft.AspNetCore.Mvc;
using SlmsAppBusiness.VideoServices;
using SlmsAppModels;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;

namespace SlmsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IvideoService _service;
        private readonly ILogger<VideoController> _logger;

        public VideoController(IvideoService service, ILogger<VideoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost("videos")]
        public async Task<IActionResult> AddOrUpdateVideo([FromForm] AddVideotoVideo videoDto)
        {
            if (videoDto == null || videoDto.VideoFileUpload == null)
                return BadRequest("Invalid video data.");

            try
            {
                // Extract and assign file extension (e.g., .mp4, .avi)
                videoDto.FileType = Path.GetExtension(videoDto.VideoFileUpload.FileName).ToLower();

                // Convert uploaded video to byte array and assign to VideoUrl
                using (var memoryStream = new MemoryStream())
                {
                    await videoDto.VideoFileUpload.CopyToAsync(memoryStream);
                    videoDto.VideoUrl = memoryStream.ToArray(); // Automatically set VideoUrl
                }

                // Call service method to add/update
                await _service.AddOrUpdateVideoAsync(videoDto);

                return Ok(new
                {
                    message = videoDto.VideoId > 0
                        ? "Video updated successfully."
                        : "Video added successfully."
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing video.");
                return BadRequest(new
                {
                    message = ex.Message,
                    inner = ex.InnerException?.Message
                });
            }
        }

        [HttpGet("section/{sectionId}/videos")]
        public async Task<IActionResult> GetVideosBySection(int sectionId)
        {
            try
            {
                var videos = await _service.GetVideosBySectionAsync(sectionId);
                return Ok(videos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching videos by section.");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("decrypted/{id}")]
        public async Task<IActionResult> GetDecryptedVideoById(int id)
        {
            try
            {
                var (data, contentType, fileName) = await _service.GetDecryptedVideoAsync(id);
                if (data == null)
                    return NotFound("Media not found.");

                // Convert file extension to proper MIME type
                if (!string.IsNullOrEmpty(contentType) && contentType.StartsWith('.'))
                {
                    contentType = GetContentType(contentType);
                }

                if (string.IsNullOrEmpty(contentType))
                {
                    contentType = "application/octet-stream";
                }

                return File(data, contentType, fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to decrypt video with ID {VideoId}", id);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("videos/{id}")]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            try
            {
                await _service.DeleteVideoAsync(id);
                return Ok($"Video with ID {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting video with ID {id}");
                return NotFound(ex.Message);
            }
        }

        // Helper method for content type mapping
        private string GetContentType(string extension)
        {
            var ext = extension.ToLowerInvariant();
            return ext switch
            {
                ".mp4" => "video/mp4",
                ".mov" => "video/quicktime",
                ".avi" => "video/x-msvideo",
                ".wmv" => "video/x-ms-wmv",
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".pdf" => "application/pdf",
                ".docx" => "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                ".pptx" => "application/vnd.openxmlformats-officedocument.presentationml.presentation",
                ".txt" => "text/plain",
                _ => "application/octet-stream"
            };
        }
    }
}
