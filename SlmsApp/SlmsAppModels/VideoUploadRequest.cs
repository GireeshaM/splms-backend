using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppModels
{
    public class VideoUploadRequest
    {
        public int AddVideoId { get; set; } // 0 for create, non-zero for update
        public string VideoTitle { get; set; }

        public string VideoDescription { get; set; }
        public int CreatedByUserId { get; set; }
        public int SectionId { get; set; }

        [Required]
        public IFormFile VideoFile { get; set; }
    }
}
