using SlmsAppDataAccess.Models;
using SlmsAppDataAccess.VideoRepos;
using SlmsAppModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SlmsAppBusiness.VideoServices
{
    public class VideoService : IvideoService
    {
        private readonly IVideoRepo _repository;

        // AES key and IV - replace with your secure config values
        private readonly byte[] _key = System.Text.Encoding.UTF8.GetBytes("0123456789abcdef0123456789abcdef"); // 32 bytes = 256 bit key
        private readonly byte[] _iv = System.Text.Encoding.UTF8.GetBytes("abcdef9876543210"); // 16 bytes = 128 bit block size

        public VideoService(IVideoRepo repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Adds a new video or updates an existing one.
        /// The video data is stored as raw bytes (byte[]).
        /// </summary>
        public async Task AddOrUpdateVideoAsync(AddVideotoVideo dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            if (dto.VideoId > 0)
            {
                var existingVideo = await _repository.GetVideoByIdAsync(dto.VideoId);
                if (existingVideo == null)
                    throw new Exception("Video not found.");

                existingVideo.UserId = dto.UserId;
                existingVideo.VideoName = dto.VideoName;
                existingVideo.SectionId = dto.SectionId;
                existingVideo.VideoUrl = dto.VideoUrl;  // raw bytes
                existingVideo.Description = dto.Description;
                existingVideo.FileType = dto.FileType;
                existingVideo.VideoDuration = dto.VideoDuration;
                existingVideo.UpdatedAt = DateTime.UtcNow;

                await _repository.UpdateVideoAsync(existingVideo);
            }
            else
            {
                var newVideo = new Video
                {
                    UserId = dto.UserId,
                    SectionId = dto.SectionId,
                    VideoName = dto.VideoName,
                    VideoUrl = dto.VideoUrl,  // raw bytes
                    Description = dto.Description,
                    FileType = dto.FileType,
                    VideoDuration = dto.VideoDuration,
                    CreatedAt = DateTime.UtcNow
                };

                await _repository.AddVideoAsync(newVideo);
            }
        }

        /// <summary>
        /// Get list of videos for a section (summary DTO).
        /// </summary>
        public async Task<List<VideoSummeryDto>> GetVideosBySectionAsync(int sectionId)
        {
            return await _repository.GetVideosBySectionAsync(sectionId);
        }

        /// <summary>
        /// Retrieves and decrypts video data by ID.
        /// Returns raw decrypted bytes, content-type, and file name.
        /// </summary>
        public async Task<(byte[] Data, string ContentType, string FileName)> GetDecryptedVideoAsync(int videoId)
        {
            var video = await _repository.GetVideoByVideoIdAsync(videoId);

            if (video == null)
            {
                Console.WriteLine($"[DEBUG] Video with ID {videoId} not found.");
                return (null, null, null);
            }

            if (video.VideoUrl == null || video.VideoUrl.Length == 0)
            {
                Console.WriteLine($"[DEBUG] Video data empty or null for ID {videoId}.");
                return (null, null, null);
            }

            Console.WriteLine($"[DEBUG] Video found for ID {videoId}, FileType: {video.FileType}, Name: {video.VideoName}");

            try
            {
                var rawBytes = video.VideoUrl;

                // Check if encrypted (AES ciphertext length multiple of block size = 16 bytes)
                if (rawBytes.Length % 16 == 0)
                {
                    Console.WriteLine("[DEBUG] Data length multiple of 16, attempting AES decryption.");

                    try
                    {
                        var decryptedBytes = AesDecryptor.Decrypt(rawBytes, _key, _iv);
                        Console.WriteLine($"[DEBUG] AES decryption successful. Decrypted size: {decryptedBytes.Length}");

                        return (
                            decryptedBytes,
                            video.FileType ?? "application/octet-stream",
                            video.VideoName ?? $"video_{videoId}.mp4"
                        );
                    }
                    catch (CryptographicException ex)
                    {
                        Console.WriteLine($"[ERROR] AES decryption failed: {ex.Message}");
                        return (null, null, null);
                    }
                }
                else
                {
                    // Assume data is stored unencrypted
                    Console.WriteLine("[DEBUG] Data length not multiple of 16, assuming raw video bytes.");

                    return (
                        rawBytes,
                        video.FileType ?? "application/octet-stream",
                        video.VideoName ?? $"video_{videoId}.mp4"
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Unexpected error processing video ID {videoId}: {ex.Message}");
                return (null, null, null);
            }
        }

        /// <summary>
        /// Deletes a video by its ID.
        /// </summary>
        public async Task DeleteVideoAsync(int videoId)
        {
            var existingVideo = await _repository.GetVideoByIdAsync(videoId);
            if (existingVideo == null)
                throw new Exception("Video not found.");

            await _repository.DeleteVideoAsync(videoId);
        }

        /// <summary>
        /// AES decrypt helper.
        /// </summary>
        public static class AesDecryptor
        {
            public static byte[] Decrypt(byte[] encryptedData, byte[] key, byte[] iv)
            {
                using Aes aes = Aes.Create();
                aes.Key = key;
                aes.IV = iv;
                aes.Padding = PaddingMode.PKCS7;
                aes.Mode = CipherMode.CBC;

                using var decryptor = aes.CreateDecryptor();
                using var ms = new MemoryStream(encryptedData);
                using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
                using var result = new MemoryStream();

                cs.CopyTo(result);
                return result.ToArray();
            }
        }
    }
}