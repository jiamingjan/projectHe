using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class ResearchPaper
{
    public uint Id { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public string? Type { get; set; }

    public string? Code { get; set; }

    public DateOnly? PublishDate { get; set; }

    public string? Journal { get; set; }

    public string? Orgnization { get; set; }

    public string? Level { get; set; }

    public string? CreateBy { get; set; }

    public string? UpdateBy { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public DateTime? DeleteTime { get; set; }
}
