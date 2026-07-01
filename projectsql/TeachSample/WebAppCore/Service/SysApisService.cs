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
    public class SysApisService : BaseService<SysApi, int>, ISysApisService
	{
        private readonly ISysApisDAL _repository;
		private readonly ICasbinRuleDAL _casbinRuleRepository;
		private readonly IMapper _mapper;
        public SysApisService(ISysApisDAL repository, ICasbinRuleDAL casbinRuleRepository, IMapper mapper) : base(repository)
        {
            _repository = repository;
			_casbinRuleRepository = casbinRuleRepository;
			_mapper = mapper;
        }

		public string GetTableData(int pageNum, int pageSize)
		{
			int total = 0;
			VueResMsg<VueTable<SysApisModel>> res = new VueResMsg<VueTable<SysApisModel>>();		
			
			//true 正序， false 倒序结果
			List<SysApi> records = _repository.LoadPageEntities<long>(pageNum, pageSize, out total, null, r => r.Id, true).ToList();

			List<SysApisModel> listdata = _mapper.Map<List<SysApisModel>>(records);
			
			//return
			res.SetOK();
			VueTable<SysApisModel> table = new VueTable<SysApisModel>();
			table.total = total;
			table.pageNum = pageNum;
			table.pageSize = pageSize;
			table.data = listdata;
			res.data = table;
			return JsonConvert.SerializeObject(res);
		}

		public string GetAllData()
		{
			VueResMsg<List<SysApisModel>> res = new VueResMsg<List<SysApisModel>>();

			//true 正序， false 倒序结果
			List<SysApi> records = _repository.LoadEntities<long>(null, r => r.Id, true).ToList();

			List<SysApisModel> listdata = _mapper.Map<List<SysApisModel>>(records);

			res.SetOK();
			res.data = listdata;
			return JsonConvert.SerializeObject(res);
		}

		public string getPolicyPathByRoleId(string roleKey)
		{
			VueResMsg<List<CasbinRuleModel>> res = new VueResMsg<List<CasbinRuleModel>>();
			if (string.IsNullOrEmpty(roleKey))
			{
				res.code = 400;
				res.msg = "角色名(roleKey)为空!";
				return JsonConvert.SerializeObject(res);
			}
			List<CasbinRule> listRules = _casbinRuleRepository.LoadEntities<long>(r => r.V0.Equals(roleKey), r => r.Id, true).ToList();
			List<CasbinRuleModel> listRulesTab = new List<CasbinRuleModel>();

			foreach (CasbinRule srcone in listRules)
			{
				CasbinRuleModel row = new CasbinRuleModel();
				row.id = srcone.Id;
				row.method = srcone.V2;
				row.path = srcone.V1;
				row.roleKey = srcone.V0;
				listRulesTab.Add(row);
			}
			res.SetOK();
			res.data = listRulesTab;
			return JsonConvert.SerializeObject(res);
		}
	}
}