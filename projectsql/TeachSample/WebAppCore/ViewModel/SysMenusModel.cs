
namespace WebAppCore.ViewModels
{
    public class SysMenusModel
	{
		public long menuId { get; set; }
		public string menuName { get; set; }
		public string title { get; set; }
		public int? parentId { get; set; }
		public int? sort { get; set; }
		public string icon { get; set; }
		public string path { get; set; }
		public string component { get; set; }
		public string isFrame { get; set; }
		public string isLink { get; set; }
		public string menuType { get; set; }//M 目录 C 菜单 F 功能
		public string isHide { get; set; } //1的话就不显示了
		public string isKeepAlive { get; set; }
		public string isAffix { get; set; } //这个是固定在页面顶部的如果1的话
		public string permission { get; set; }
		public string status { get; set; }
		public string createBy { get; set; }
		public string update_by { get; set; }
		public string remark { get; set; }
		public DateTime? create_time { get; set; }
		public DateTime? update_time { get; set; }
		public List<SysMenusModel> children { get; set; }
	}


	public class menusSelect
	{
		public long menuId { get; set; }
		public string menuName { get; set; }
		public List<menusSelect> children { get; set; }
	}

	public class menusSelectRes
	{
		//这是选中的菜单id
		public List<long> checkedKeys { get; set; }
		//菜单信息
		public List<menusSelect> menus { get; set; }
	}
}