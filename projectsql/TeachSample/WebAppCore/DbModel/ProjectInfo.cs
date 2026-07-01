using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class ProjectInfo
{
    public long Id { get; set; }
    public string? PrjName { get; set; }
    public string? PrjCode { get; set; }
    public long? PrjType { get; set; }
    public string? PrjStatus { get; set; }
    public string? PrjDesc { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Manager { get; set; }
    public decimal? Money { get; set; }
    public string? Remark { get; set; }
    public string? CreateBy { get; set; }
    public string? UpdateBy { get; set; }
    public DateTime? CreateTime { get; set; }
    public DateTime? UpdateTime { get; set; }
    public DateTime? DeleteTime { get; set; }
}