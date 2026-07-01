
namespace WebAppCore.ViewModels
{
    public class SysPostsModel
    {
        public long postId { get; set; }
        public string postName { get; set; }
        public string postCode { get; set; }
        public int? sort { get; set; }
        public string status { get; set; }
        public string remark { get; set; }
        public string createBy { get; set; }
        public string updateBy { get; set; }
        public DateTime? create_time { get; set; }
        public DateTime? update_time { get; set; }
    }
}