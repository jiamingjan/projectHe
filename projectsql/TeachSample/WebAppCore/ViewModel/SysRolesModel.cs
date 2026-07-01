
namespace WebAppCore.ViewModels
{
    public class SysRolesModel
    {
		public long roleId { get; set; }
		public string roleName { get; set; }
		public string status { get; set; }
		public string roleKey { get; set; }
		public string dataScope { get; set; }
		public int? roleSort { get; set; }
		public string flag { get; set; }
		public string createBy { get; set; }
		public string updateBy { get; set; }
		public string remark { get; set; }
		public DateTime? create_time { get; set; }
		public DateTime? update_time { get; set; }
		public string apiIds { get; set; }
		public string menuIds { get; set; }
		public string deptIds { get; set; }
	}


	public class roleApiInfo
	{
		public string method { get; set; }
		public string path { get; set; }
	}

	public class sys_rolesUpdate
	{
		public long roleId { get; set; }
		public string roleName { get; set; }
		public string status { get; set; }
		public string roleKey { get; set; }
		public string dataScope { get; set; }
		public int? roleSort { get; set; }
		public string flag { get; set; }
		public string createBy { get; set; }
		public string updateBy { get; set; }
		public string remark { get; set; }
		public DateTime? create_time { get; set; }
		public DateTime? update_time { get; set; }
		public List<roleApiInfo> apiIds { get; set; }
		public List<long> menuIds { get; set; }
		public List<long> deptIds { get; set; } //²»È·¶¨
	}



	public class sys_rolesAddParam
	{
		public int? roleSort { get; set; }
		public string status { get; set; }
		public string roleName { get; set; }
		public string roleKey { get; set; }
		public string createBy { get; set; }
		public List<long> menuIds { get; set; }
		public List<roleApiInfo> apiIds { get; set; }
	}
}