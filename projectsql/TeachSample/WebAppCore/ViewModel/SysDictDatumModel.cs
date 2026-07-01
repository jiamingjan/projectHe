
namespace WebAppCore.ViewModels
{
    public class SysDictDatumModel
	{
		public string createBy { get; set; }
		public DateTime? create_time { get; set; }
		public string cssClass { get; set; }
		public long dictCode { get; set; }
		public string dictLabel { get; set; }
		public int? dictSort { get; set; }

		public string dictValue { get; set; }
		public string dictType { get; set; }
		public string isDefault { get; set; }
		public string listClass { get; set; }
		public string remark { get; set; }
		public string status { get; set; }

		public string updateBy { get; set; }
		public DateTime? update_time { get; set; }
	}

}