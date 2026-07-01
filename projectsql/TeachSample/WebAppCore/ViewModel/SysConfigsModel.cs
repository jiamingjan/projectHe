
namespace WebAppCore.ViewModels
{
    public class SysConfigsModel
	{
		public long configId { get; set; }
		public string configName { get; set; }
		public string configKey { get; set; }
		public string configValue { get; set; }
		public string configType { get; set; }
		public string isFrontend { get; set; }
		public string remark { get; set; }
		public DateTime? create_time { get; set; }
		public DateTime? update_time { get; set; }
	}
	
}