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
//using Newtonsoft.Json;


namespace WebAppCore.Service
{
    /// <summary>
    ///
    /// </summary>   
    public class SysDictTypeService : BaseService<SysDictType, int>, ISysDictTypeService
	{
        private readonly ISysDictTypeDAL _repository;
        private readonly IMapper _mapper;
        public SysDictTypeService(ISysDictTypeDAL repository, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

		public string GetTableData(int pageNum, int pageSize)
		{
			int total = 0;
			VueResMsg<VueTable<SysDictTypeModel>> res = new VueResMsg<VueTable<SysDictTypeModel>>();
			
			//List<sys_dict_types> records = sys_dict_typesDAL.LoadEntities(r => r.dict_id > 0).ToList();
			//true 正序， false 倒序结果
			List<SysDictType> records = _repository.LoadPageEntities<long>(pageNum, pageSize,
				out total, null, r => r.DictId, true).ToList();

			List<SysDictTypeModel> results = _mapper.Map<List<SysDictTypeModel>>(records);
			//return
			res.SetOK();
			VueTable<SysDictTypeModel> table = new VueTable<SysDictTypeModel>();
			table.total = total;
			table.pageNum = pageNum;
			table.pageSize = pageSize;
			table.data = results;
			res.data = table;
			return JsonConvert.SerializeObject(res);
		}
	}
}