using System;
using System.Collections.Generic;

namespace SlmsAppDataAccess.Models;

public partial class Video
{
    public int VideoId { get; set; }

    public string VideoName { get; set; }

    public string Description { get; set; }

    public int SectionId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? UserId { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string FileType { get; set; }

    public byte[] VideoUrl { get; set; }

    public decimal? VideoDuration { get; set; }

    public virtual ICollection<LessonsOrder> LessonsOrders { get; set; } = new List<LessonsOrder>();

    public virtual Section Section { get; set; }

    public virtual User User { get; set; }
}
