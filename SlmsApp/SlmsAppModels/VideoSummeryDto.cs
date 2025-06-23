using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppModels
{
    public class VideoSummeryDto
    {
        public int VideoId { get; set; }
        public string VideoName { get; set; }
        public string Description { get; set; }
        public string FileType { get; set; }
        public decimal? VideoDuration { get; set; }

    }

}
