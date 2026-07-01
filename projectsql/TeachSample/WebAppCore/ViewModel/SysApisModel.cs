
namespace WebAppCore.ViewModels
{
    public class SysApisModel
	{
		public long id { get; set; }
		public DateTime? create_time { get; set; }
		public DateTime? update_time { get; set; }
		public string path { get; set; }
		public string description { get; set; }
		public string apiGroup { get; set; }
		public string method { get; set; }
	}

}