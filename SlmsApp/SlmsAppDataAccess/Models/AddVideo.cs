using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class AddVideo
{
    public int AddVideoId { get; set; }

    public string VideoDescription { get; set; }

    public DateTime VideoCreatedDate { get; set; }

    public DateTime? VideoUpdatedDate { get; set; }

    public int CreatedByUserId { get; set; }

    public int SectionId { get; set; }

    public string VideoContent { get; set; }

    public virtual User CreatedByUser { get; set; }

    public virtual Section Section { get; set; }
}
