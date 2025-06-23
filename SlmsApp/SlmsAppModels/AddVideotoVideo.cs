using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SlmsAppModels
{
    public class AddVideotoVideo
    {
        public int UserId { get; set; }
        public int? VideoId { get; set; }

        public int SectionId { get; set; }
        public string VideoName { get; set; }

        [BindNever] // ✅ Prevents model binding from trying to assign this from form
        public byte[]? VideoUrl { get; set; }
        public string Description { get; set; }
        public string FileType { get; set; }
        public IFormFile VideoFileUpload { get; set; }

        public decimal? VideoDuration { get; set; }

    }

}