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
    public class SysRolesService : BaseService<SysRole, int>, ISysRolesService
	{
        private readonly ISysRolesDAL _repository;
		private readonly ISysRoleMenusDAL _roleMenuRepository;
		private readonly ICasbinRuleDAL _casbinRuleRepository;
		private readonly IMapper _mapper;
        public SysRolesService(ISysRolesDAL repository, ISysRoleMenusDAL roleMenuRepository,
			ICasbinRuleDAL casbinRuleRepository, IMapper mapper) : base(repository)
        {
            _repository = repository;
			_roleMenuRepository = roleMenuRepository;
			_casbinRuleRepository = casbinRuleRepository;
			_mapper = mapper;
        }



		public string GetTableData(int pageNum, int pageSize, SysRolesModel data)
		{
			int total = 0;
			VueResMsg<VueTable<SysRolesModel>> res = new VueResMsg<VueTable<SysRolesModel>>();
						
			//List<sys_roles> records = sys_rolesDAL.LoadEntities(r => r.dict_id > 0).ToList();
			//true 正序， false 倒序结果
			Expression<Func<SysRole, bool>> piceWhere = PredicateExtensions.True<SysRole>();
			if (data != null)
			{
				if (!string.IsNullOrEmpty(data.status))
				{
					piceWhere = PredicateExtensions.And(piceWhere, r => r.Status == data.status);
				}

				if (!string.IsNullOrEmpty(data.roleName))
				{
					piceWhere = PredicateExtensions.And(piceWhere, r => r.RoleName.Contains(data.roleName));
				}

				if (!string.IsNullOrEmpty(data.roleKey))
				{
					piceWhere = PredicateExtensions.And(piceWhere, r => r.RoleKey.Contains(data.roleKey));
				}
			}

			List<SysRole> records = _repository.LoadPageEntities<long>(pageNum, pageSize, out total, piceWhere, r => r.RoleId, true).ToList();

			List<SysRolesModel> results = _mapper.Map<List<SysRolesModel>>(records);			
			
			res.SetOK();
			VueTable<SysRolesModel> table = new VueTable<SysRolesModel>();
			table.total = total;
			table.pageNum = pageNum;
			table.pageSize = pageSize;
			table.data = results;
			res.data = table;
			return JsonConvert.SerializeObject(res);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="post">查询条件</param>
		/// <returns></returns>
		public List<SysRolesModel> GetRoles(SysRolesModel role)
		{
			List<SysRolesModel> resList = new List<SysRolesModel>();
			Expression<Func<SysRole, bool>> pieceWhere = null;
			if (role != null)
			{
				//设置查询条件
				pieceWhere = PredicateExtensions.True<SysRole>();
				pieceWhere = PredicateExtensions.And(pieceWhere, r => r.RoleId == role.roleId);
				//下面还有其他条件
			}

			List<SysRole> records = _repository.LoadEntities<long>(pieceWhere, r => r.RoleId, true).ToList();

			if (records != null && records.Count > 0)
			{
				resList = _mapper.Map<List<SysRolesModel>>(records);
				//TransforData(resList, records);
			}
			return resList;
		}

		
		public string GetById(long Id)
		{
			SysRolesModel role = new SysRolesModel();
			role.roleId = Id;
			List<SysRolesModel> list = GetRoles(role);
			VueResMsg<SysRolesModel> res = new VueResMsg<SysRolesModel>();
			if (list == null || list.Count <= 0)
			{
				res.code = 400;//?
				res.msg = "获取角色信息失败";
			}

			//List<sys_rolesTable> listdata = new List<sys_rolesTable>();
			//List<sys_roles> records = sys_rolesDAL.LoadEntities(r => r.role_id == Id).ToList();
			//if (records == null || records.Count <= 0)
			//{
			//    res.code = 400;//?
			//    res.msg = "获取角色信息失败";
			//}

			//TransforData(listdata, records);
			//return
			res.SetOK();

			res.data = list[0];
			return JsonConvert.SerializeObject(res);

		}

		public string AddTableData(sys_rolesAddParam param)
		{
			VueResMsg<SysRolesModel> res = new VueResMsg<SysRolesModel>();

			if (param == null)
			{
				res.code = 400;
				res.msg = "数据为空";
				return JsonConvert.SerializeObject(res);
			}

			//先插入一条role数据
			SysRole dbData = new SysRole();
			dbData.CreateTime = DateTime.Now;
			//TokenInfo ti = (TokenInfo)HttpContext.Current.Session["TokenInfo"];
			//if (ti != null)
			//	dbData.CreateBy = ti.UserName;
			dbData.CreateBy = param.createBy;

			dbData.Status = param.status;
			dbData.RoleKey = param.roleKey;
			dbData.RoleName = param.roleName;
			dbData.RoleSort = param.roleSort;
			_repository.Add(dbData, false); //
			int num = _repository.SaveChange();
			
			//再插入对应的menu信息到sys_role_menus
			if (param.menuIds != null)
			{
				//
				int total = 0;
				List<SysRole> rolesList = _repository.LoadPageEntities<long>(1, 1, out total, r => r.RoleName.Equals(param.roleName), r => r.RoleId, false).ToList();
				if (rolesList != null && rolesList.Count > 0)
				{
					foreach (long menuId in param.menuIds)
					{
						SysRoleMenu roleMenu = new SysRoleMenu();
						roleMenu.RoleId = (int)rolesList[0].RoleId;
						roleMenu.RoleName = param.roleName;
						roleMenu.MenuId = (int)menuId;
						_roleMenuRepository.Add(roleMenu,false); //这里后面一起保存
					}
					_roleMenuRepository.SaveChange();
				}
			}


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

		public string UpdateTableData(sys_rolesUpdate param)
		{
			VueResMsg<sys_rolesUpdate> res = new VueResMsg<sys_rolesUpdate>();

			if (param == null)
			{
				res.code = 400;
				res.msg = "数据为空";
				return JsonConvert.SerializeObject(res);
			}

			//1.先修改sys_role表格数据
			SysRole dbData = new SysRole();
			dbData.CreateBy = param.createBy;
			dbData.CreateTime = param.create_time;
			dbData.DataScope = param.dataScope;
			dbData.Flag = param.flag;
			dbData.Remark = param.remark;
			dbData.RoleId = param.roleId;
			dbData.RoleKey = param.roleKey;
			dbData.RoleName = param.roleName;
			dbData.RoleSort = param.roleSort;
			dbData.Status = param.status;
			dbData.UpdateTime = DateTime.Now;
			//TokenInfo ti = (TokenInfo)HttpContext.Current.Session["TokenInfo"];
			//if (ti != null)
			//	dbData.UpdateBy = ti.UserName;
			dbData.UpdateBy = param.updateBy;

			bool ret = _repository.Update(dbData);
			int num = 0;
			num = _repository.SaveChange();

			//2.再处理role api 对应的表 casbin_rule
			//目前的做法是如果不带这个参数就不动数据库，但是万一人家要全部删除呢？
			if (param.apiIds != null && param.apiIds.Count > 0)
			{
				//1）先删除旧的
				//string strSql1 = "delete from casbin_rule where v0 = '" + param.roleKey + "'";
				//DAL.DBContextFactory.CreateDbContext().Database.ExecuteSqlCommand(strSql1);
				//下面不确定能否起效果
				CasbinRule cr2 = new CasbinRule();
				cr2.V0 = param.roleKey;
				_casbinRuleRepository.Delete(cr2);
				
				//2)再插入新的
				foreach (roleApiInfo api in param.apiIds)
				{
					CasbinRule rule = new CasbinRule();
					rule.V0 = param.roleKey;
					rule.V1 = api.path;
					rule.V2 = api.method;
					rule.Ptype = "p";
					_casbinRuleRepository.Add(rule);
				}
				_casbinRuleRepository.SaveChange();
			}

			//3.再处理role menu 对应的表 sys_role_menus
			//目前的做法是如果不带这个参数就全部删除
			//1）先删除旧的
			//string strSql2 = "delete from sys_role_menus where role_id = " + param.roleId + "";
			//int num2 = DAL.DBContextFactory.CreateDbContext().Database.ExecuteSqlCommand(strSql2);
			//下面不确定能否起效果
			SysRoleMenu sr = new SysRoleMenu();
			sr.RoleId = (int?)param.roleId;
			_roleMenuRepository.Delete(sr,true);

			if (param.menuIds != null && param.menuIds.Count > 0)
			{
				//2)再插入新的
				foreach (long menuId in param.menuIds)
				{
					SysRoleMenu roleMenu = new SysRoleMenu();
					roleMenu.Id = (int)param.roleId;
					roleMenu.MenuId = (int)menuId;
					roleMenu.RoleName = param.roleKey;
					_roleMenuRepository.Add(roleMenu);
				}
				_roleMenuRepository.SaveChange();
			}

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
	}
}