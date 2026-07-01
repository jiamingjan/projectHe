namespace WebAppCore.ViewModels
{
    public class ProjectInfoModel
    {
        public long Id { get; set; }
        public string PrjName { get; set; }
        public string PrjCode { get; set; }
        public long? PrjType { get; set; }
        public string PrjStatus { get; set; }
        public string PrjDesc { get; set; }
        public System.DateTime? StartDate { get; set; }
        public System.DateTime? EndDate { get; set; }
        public string Manager { get; set; }
        public decimal? Money { get; set; }
        public string Remark { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public System.DateTime? CreateTime { get; set; }
        public System.DateTime? UpdateTime { get; set; }
        public System.DateTime? DeleteTime { get; set; }
    }
}