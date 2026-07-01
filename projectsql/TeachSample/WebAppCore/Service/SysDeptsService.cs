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
    public class SysDeptsService : BaseService<SysDept, int>, ISysDeptsService
	{
        private readonly ISysDeptsDAL _repository;
		private readonly ISysRoleDeptDAL _roleDeptRepository;
		private readonly IMapper _mapper;
        public SysDeptsService(ISysDeptsDAL repository, ISysRoleDeptDAL roleDeptRepository, IMapper mapper) : base(repository)
        {
            _repository = repository;
			_roleDeptRepository = roleDeptRepository;
			_mapper = mapper;
        }

		public string GetDeptTree()
		{
			VueResMsg<List<SysDeptsModel>> res = new VueResMsg<List<SysDeptsModel>>();
			List<SysDeptsModel> listdata = new List<SysDeptsModel>();

			List<SysDept> records = _repository.LoadEntities<string>(null, r => r.DeptName, true).ToList();
			int topParentId = 0; // 父节点0表示根节点
			GetSubDepts(ref listdata, records, topParentId);

			res.SetOK();
			res.data = listdata;
			return JsonConvert.SerializeObject(res);
		}
		/// <summary>
		/// 递归生成json格式的部门树，特别注意第一个参数要用ref
		/// </summary>
		/// <param name="target"></param>
		/// <param name="src"></param>
		/// <param name="ParentId"></param>
		private void GetSubDepts(ref List<SysDeptsModel> target, List<SysDept> src, long ParentId)
		{
			foreach (SysDept one in src)
			{
				if (one.ParentId == ParentId)
				{
					SysDeptsModel row = new SysDeptsModel
					{
						deptId = one.DeptId,
						parentId = one.ParentId,
						deptPath = one.DeptPath,
						deptName = one.DeptName,
						sort = one.Sort,
						leader = one.Leader,
						phone = one.Phone,
						email = one.Email,
						status = one.Status,
						createBy = one.CreateBy,
						updateBy = one.UpdateBy,
						create_time = one.CreateTime,
						update_time = one.UpdateTime
					};

					List<SysDeptsModel> newtarget = new List<SysDeptsModel>();
					GetSubDepts(ref newtarget, src, row.deptId);
					row.children = newtarget;

					// 把该节点row及所有子节点都加入到target数组中
					if (target == null)
						target = new List<SysDeptsModel>();
					target.Add(row);
				}
			}
		}

		public string GetTableData()
		{
			return GetDeptTree();
		}

		public string GetRoleDeptTree(long roleId)
		{
			VueResMsg<deptsSelect> res = new VueResMsg<deptsSelect>();

			Expression<Func<SysDept, bool>> pieceWhere = null;

			List<SysRoleDept> role_deptsList = _roleDeptRepository.LoadEntities<int?>(r => r.RoleId == roleId, 
				r => r.RoleId, true).ToList();
			if (role_deptsList != null && role_deptsList.Count > 0)
			{
				pieceWhere = PredicateExtensions.True<SysDept>();
				foreach (var roleDept in role_deptsList)
				{
					pieceWhere = PredicateExtensions.Or(pieceWhere, r => r.DeptId == roleDept.DeptId);
				}
			}

			List<SysDeptsModel> listdata = new List<SysDeptsModel>();
			List<SysDept> records = _repository.LoadEntities<long>(pieceWhere, r => r.DeptId, true).ToList();
			long parentId = 0; // 父节点0表示根节点
			GetSubDepts(ref listdata, records, parentId);

			res.SetOK();
			if (res.data == null)
				res.data = new deptsSelect();
			res.data.checkedKeys = new List<long>(); // checked keys
			res.data.depts = listdata;
			return JsonConvert.SerializeObject(res);
		}
	}
}