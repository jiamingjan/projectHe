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
    public class SysConfigsService : BaseService<SysConfig, int>, ISysConfigsService
	{
        private readonly ISysConfigsDAL _repository;		
		private readonly IMapper _mapper;
        public SysConfigsService(ISysConfigsDAL repository,IMapper mapper) : base(repository)
        {
            _repository = repository;			
			_mapper = mapper;
        }

		public string GetTableData(int pageNum, int pageSize)
		{
			int total = 0;
			VueResMsg<VueTable<SysConfigsModel>> res = new VueResMsg<VueTable<SysConfigsModel>>();
						
			//true 正序， false 倒序结果
			List<SysConfig> records = _repository.LoadPageEntities<long>(pageNum, pageSize, out total, null, r => r.ConfigId, true).ToList();
			List<SysConfigsModel> listdata = _mapper.Map<List<SysConfigsModel>>(records);
		
			//return
			res.SetOK();
			VueTable<SysConfigsModel> table = new VueTable<SysConfigsModel>();
			table.total = total;
			table.pageNum = pageNum;
			table.pageSize = pageSize;
			table.data = listdata;
			res.data = table;
			return JsonConvert.SerializeObject(res);
		}

		
	}
}