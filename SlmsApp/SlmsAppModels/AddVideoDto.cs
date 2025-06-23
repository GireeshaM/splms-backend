using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppModels
{
    public class AddVideoDto
    {
        public int AddVideoId { get; set; }
        public string VideoTitle { get; set; }
        public string VideoDescription { get; set; }
        public DateTime VideoCreatedDate { get; set; }
        public DateTime? VideoUpdatedDate { get; set; }
        public int CreatedByUserId { get; set; }
        public int SectionId { get; set; }
        public string VideoContent { get; set; }
    }
}
