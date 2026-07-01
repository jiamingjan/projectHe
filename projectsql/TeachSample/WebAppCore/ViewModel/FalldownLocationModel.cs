
namespace WebAppCore.ViewModels
{
    public class FalldownLocationModel
	{
		public long Id { get; set; }
		public string DeviceCode { get; set; }
		public string Status { get; set; }
		public decimal? Lon { get; set; }
		public decimal? Lat { get; set; }
		public string Remark { get; set; }
		public DateTime? UpdateTime { get; set; }
	}

	public class loc
	{
		public decimal? lng { get; set; } //百度地图默认用Lng
		public decimal? lat { get; set; }
	}
}
