
namespace WebAppCore.ViewModels
{
    public class FalldownDeviceModel
	{
		public long Id { get; set; }
		public string DeviceCode { get; set; }
		public string Status { get; set; }
		public string Model { get; set; }
		public string ContactPhones { get; set; }
		public string Phone { get; set; }
		public string Flag { get; set; }
		public string CreateBy { get; set; }
		public string UpdateBy { get; set; }
		public string Remark { get; set; }
		public DateTime? CreateTime { get; set; }
		public DateTime? UpdateTime { get; set; }
		public DateTime? DeleteTime { get; set; }
	}

}