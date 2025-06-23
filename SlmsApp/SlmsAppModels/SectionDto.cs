using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlmsAppModels
{
    public class SectionDto
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public string SectionObjective { get; set; }
        public DateTime SectionCreatedDate { get; set; }
        public DateTime? SectionUpdatedDate { get; set; }
        public int CreatedByUserId { get; set; }
        public bool IsActive { get; set; }
        public int? CreateCourseId { get; set; }

    }

}
