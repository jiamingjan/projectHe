using System.Text.Json;
using WebAppCore.DbModel;
using WebAppCore.ViewModels;
using Service;
using IRepository;
using System.Linq.Expressions;
using WebAppCore.DbExtensions;
using AutoMapper;
using MyTool;
using SixLabors.ImageSharp.Formats.Gif;
using System.Security.Cryptography;
using System.Text;
using NPOI.HSSF.Record;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Newtonsoft.Json;
using Repository;
//using Newtonsoft.Json;


namespace WebAppCore.Service
{
    /// <summary>
    ///
    /// </summary>   
    public class SysMenusService : BaseService<SysMenu, int>, ISysMenusService
	{
        private readonly ISysMenusDAL _repository;
		private readonly ISysRoleMenusDAL _roleMenusRepository;
		private readonly IMapper _mapper;
        public SysMenusService(ISysMenusDAL repository,ISysRoleMenusDAL roleMenusRepository,IMapper mapper) : base(repository)
        {
            _repository = repository;
			_roleMenusRepository = roleMenusRepository;
			_mapper = mapper;
        }

		public string GetTableData(SysMenu data)
		{
			VueResMsg<List<SysMenusModel>> res = new VueResMsg<List<SysMenusModel>>();

			List<SysMenusModel> listdata = new List<SysMenusModel>();
			Expression<Func<SysMenu, bool>> pieceWhere = PredicateExtensions.True<SysMenu>();
			if (data != null && !string.IsNullOrEmpty(data.MenuName))
				pieceWhere = PredicateExtensions.And(pieceWhere, r => r.MenuName.Contains(data.MenuName));
			if (data != null && !string.IsNullOrEmpty(data.Status))
				pieceWhere = PredicateExtensions.And(pieceWhere, r => r.Status.Equals(data.Status));
			//true 正序， false 倒序结果
			List<SysMenu> records = _repository.LoadEntities<long>(pieceWhere, r => r.MenuId, true).ToList();
			GetSubMenus(ref listdata, records, 0); //父节点0表示根节点

			res.SetOK();
			res.data = listdata;
			return JsonConvert.SerializeObject(res);
		}
		/// <summary>
		/// 递归生成json格式的树菜单，特别注意第一个参数要用ref
		/// 这个有点慢。
		/// </summary>
		/// <param name="target"></param>
		/// <param name="src"></param>
		/// <param name="parentMenuId"></param>
		private void GetSubMenus(ref List<SysMenusModel> target, List<SysMenu> src, long parentMenuId)
		{
			foreach (SysMenu one in src)
			{
				if (one.ParentId == parentMenuId)
				{					
					SysMenusModel row = _mapper.Map<SysMenusModel>(one);
					List<SysMenusModel> newtarget = null;
					GetSubMenus(ref newtarget, src, row.menuId);
					row.children = newtarget;

					//把该节点row及所有子节点都加入到target数组中
					if (target == null)
						target = new List<SysMenusModel>();
					target.Add(row);
				}
			}
		}

		public string MenuTreeSelect()
		{
			VueResMsg<List<menusSelect>> res = new VueResMsg<List<menusSelect>>();

			List<menusSelect> listdata = new List<menusSelect>();

			//true 正序， false 倒序结果
			List<SysMenu> records = _repository.LoadEntities<long>(null, r => r.MenuId, true).ToList();
			GetSubTreeMenus(ref listdata, records, 0); //父节点0表示根节点

			res.SetOK();
			res.data = listdata;
			return JsonConvert.SerializeObject(res);
		}

		/// <summary>
		/// 递归生成json格式的树菜单，特别注意第一个参数要用ref
		/// 这个有点慢。
		/// </summary>
		/// <param name="target"></param>
		/// <param name="src"></param>
		/// <param name="CurrentMenuId"></param>
		private void GetSubTreeMenus(ref List<menusSelect> target, List<SysMenu> src, long CurrentMenuId)
		{
			foreach (SysMenu one in src)
			{
				if (one.ParentId == CurrentMenuId)
				{
					menusSelect row = new menusSelect();
					row.menuId = one.MenuId;
					row.menuName = one.MenuName;

					List<menusSelect> newtarget = null;
					GetSubTreeMenus(ref newtarget, src, row.menuId);
					row.children = newtarget;

					//把该节点row及所有子节点都加入到target数组中
					if (target == null)
						target = new List<menusSelect>();
					target.Add(row);
				}

			}
		}

		public string AddTableData(List<SysMenusModel> list)
		{
			VueResMsg<SysMenusModel> res = new VueResMsg<SysMenusModel>();

			if (list == null || list.Count <= 0)
			{
				res.code = 400;
				res.msg = "数据为空";
				return JsonConvert.SerializeObject(res);
			}

			foreach (SysMenusModel one in list)
			{
				SysMenu dbData = _mapper.Map<SysMenu>(one);			
				_repository.Add(dbData, false);
			}
			int num = 0;
			num = _repository.SaveChange();

			if (num <= 0)
			{
				res.code = 400;
				res.msg = "新增失败";
			}
			else
			{
				res.SetOK();
			}

			return JsonConvert.SerializeObject(res);
		}

		
		public string UpdateTableData(List<SysMenusModel> list)
		{
			VueResMsg<SysMenusModel> res = new VueResMsg<SysMenusModel>();

			if (list == null || list.Count <= 0)
			{
				res.code = 400;
				res.msg = "数据为空";
				return JsonConvert.SerializeObject(res);
			}

			foreach (SysMenusModel one in list)
			{
				SysMenu dbData = _mapper.Map<SysMenu>(one);				
				bool ret = _repository.Update(dbData);
			}
			int num = 0;
			num = _repository.SaveChange();

			if (num <= 0)
			{
				res.code = 400;
				res.msg = "修改失败";

			}
			else
			{
				res.SetOK();

			}

			return JsonConvert.SerializeObject(res);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		public string DeleteTableData(List<long> ids)
		{
			VueResMsg<SysMenusModel> res = new VueResMsg<SysMenusModel>();

			if (ids == null || ids.Count <= 0)
			{
				res.code = 400;
				res.msg = "数据为空";
				return JsonConvert.SerializeObject(res);
			}

			foreach (long id in ids)
			{
				SysMenu dbData = new SysMenu();
				dbData.MenuId = id;
				bool ret = _repository.Delete(dbData,false);
			}
			int num = 0;
			num = _repository.SaveChange();

			if (num <= 0)
			{
				res.code = 400;
				res.msg = "删除失败";
			}
			else
			{
				res.SetOK();
			}

			return JsonConvert.SerializeObject(res);
		}

		public string RoleMenuTreeSelect(int roleId)
		{
			VueResMsg<menusSelectRes> res = new VueResMsg<menusSelectRes>();

			if (roleId <= 0)
			{
				res.code = 400;
				res.msg = "roleId 错误：" + roleId;
				return JsonConvert.SerializeObject(res);
			}

			menusSelectRes data = new menusSelectRes();

			//read checkedKeys from sys_role_menus
			//string strSql = "select menu_id from sys_role_menus where role_id in (" + roleId + ") ";
			//List<long> checkedKeys = DAL.DBContextFactory.CreateDbContext().Database.SqlQuery<long>(strSql).ToList();
			Expression<Func<SysRoleMenu, bool>> pieceWhere = PredicateExtensions.True<SysRoleMenu>();
			pieceWhere = PredicateExtensions.And(pieceWhere, r => r.RoleId == roleId);

			//true 正序， false 倒序结果
			List<SysRoleMenu> roleMenusList = _roleMenusRepository.LoadEntities<int?>(pieceWhere, r => r.MenuId, true).ToList();
			List<long> checkedKeys = new List<long>();
			if (roleMenusList != null && roleMenusList.Count > 0)
			{
				foreach (SysRoleMenu one in roleMenusList)
					checkedKeys.Add((long)one.MenuId);
			}
			data.checkedKeys = checkedKeys;

			//read all menus from sys_menus
			List<SysMenu> records = _repository.LoadEntities<long>(null, r => r.MenuId, true).ToList();
			List<menusSelect> listdata = new List<menusSelect>();
			if (records != null && records.Count > 0)
				GetSubTreeMenus(ref listdata, records, 0); //父节点0表示根节点

			data.menus = listdata;

			res.data = data;
			res.SetOK();
			return JsonConvert.SerializeObject(res);
		}
	}
}