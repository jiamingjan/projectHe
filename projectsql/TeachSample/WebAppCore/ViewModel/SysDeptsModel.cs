
namespace WebAppCore.ViewModels
{
    public class SysDeptsModel
	{
		public long deptId { get; set; }
		public int? parentId { get; set; }
		public string deptPath { get; set; }
		public string deptName { get; set; }
		public int? sort { get; set; }
		public string leader { get; set; }
		public string phone { get; set; }
		public string email { get; set; }
		public string status { get; set; }
		public string createBy { get; set; }
		public string updateBy { get; set; }

		public DateTime? create_time { get; set; }
		public DateTime? update_time { get; set; }
		public List<SysDeptsModel> children { get; set; }//вс╡©це
	}

	public class deptsSelect
	{
		public List<long> checkedKeys { get; set; }
		public List<SysDeptsModel> depts { get; set; }
	}
}