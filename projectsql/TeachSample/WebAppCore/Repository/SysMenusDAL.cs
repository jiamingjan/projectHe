using WebAppCore.DbModel;
using System.Security.Claims;
using WebAppCore.Service;
using IRepository;
using Microsoft.EntityFrameworkCore;
using WebAppCore.ViewModels;

namespace Repository
{
    public class SysMenusDAL : BaseRepository<SysMenu, int>, ISysMenusDAL
	{        
        public SysMenusDAL(VueworkdbTeachContext Dbcontext) : base(Dbcontext)
        {           
        }

        public List<SysMenu> GetSysMenusByRoleIds(string roleIds)
        {
			List<SysMenu> sys_menuList = null;
			// 生成 SQL 语句
			string strSql = $"SELECT * FROM sys_menus WHERE menu_id IN (SELECT DISTINCT menu_id FROM sys_role_menus WHERE role_id IN ({roleIds}))";
			var datas = this.GetContext().SysMenus.FromSqlRaw<SysMenu>(strSql);
			sys_menuList = datas.ToList();

			return sys_menuList;
		}

	}
}