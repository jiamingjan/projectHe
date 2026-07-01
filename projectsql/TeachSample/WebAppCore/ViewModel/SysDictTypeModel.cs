
namespace WebAppCore.ViewModels
{
    public class SysDictTypeModel
	{
		public long dictId { get; set; }
		public string dictName { get; set; }
		public string dictType { get; set; }
		public string status { get; set; }
		public string createBy { get; set; }
		public string updateBy { get; set; }
		public string remark { get; set; }
		public DateTime? create_time { get; set; }
		public DateTime? update_time { get; set; }
	}

}