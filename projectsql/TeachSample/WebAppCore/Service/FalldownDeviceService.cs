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
    public class FalldownDeviceService : BaseService<FalldownDevice, int>, IFalldownDeviceService
	{
        private readonly IFalldownDeviceDAL _repository;		
		private readonly IMapper _mapper;
        public FalldownDeviceService(IFalldownDeviceDAL repository,IMapper mapper) : base(repository)
        {
            _repository = repository;			
			_mapper = mapper;
        }

		public string GetTableData(int pageNum, int pageSize, FalldownDeviceModel dataParams)
		{
			int total = 0;
			VueResMsg<VueTable<FalldownDeviceModel>> res = new VueResMsg<VueTable<FalldownDeviceModel>>();
									
			Expression<Func<FalldownDevice, bool>> pieceWhere = PredicateExtensions.True<FalldownDevice>();
			if (dataParams != null && !string.IsNullOrEmpty(dataParams.Model))
				pieceWhere = PredicateExtensions.And(pieceWhere, r => r.Model.Contains(dataParams.Model));

			if (dataParams != null && !string.IsNullOrEmpty(dataParams.DeviceCode))
				pieceWhere = PredicateExtensions.And(pieceWhere, r => r.DeviceCode.Contains(dataParams.DeviceCode));

			if (dataParams != null && !string.IsNullOrEmpty(dataParams.Status))
				pieceWhere = PredicateExtensions.And(pieceWhere, r => r.DeviceCode.Equals(dataParams.Status));


			List<FalldownDevice> records = _repository.LoadPageEntities<long>(pageNum, pageSize, out total, pieceWhere, r => r.Id, false).ToList();

			List<FalldownDeviceModel> listdata = _mapper.Map<List<FalldownDeviceModel>>(records); 
		
			res.SetOK();
			VueTable<FalldownDeviceModel> table = new VueTable<FalldownDeviceModel>();
			table.total = total;
			table.pageNum = pageNum;
			table.pageSize = pageSize;
			table.data = listdata;
			res.data = table;
			return JsonConvert.SerializeObject(res);
		}

		public string AddTableData(List<FalldownDeviceModel> list)
		{
			VueResMsg<FalldownDeviceModel> res = new VueResMsg<FalldownDeviceModel>();

			if (list == null || list.Count <= 0)
			{
				res.code = 400;
				res.msg = "数据为空";
				return JsonConvert.SerializeObject(res);
			}

			
			foreach (FalldownDeviceModel one in list)
			{
				FalldownDevice dbData = _mapper.Map<FalldownDevice>(one);	
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


		public string UpdateTableData(List<FalldownDeviceModel> list)
		{
			VueResMsg<FalldownDeviceModel> res = new VueResMsg<FalldownDeviceModel>();

			if (list == null || list.Count <= 0)
			{
				res.code = 400;
				res.msg = "数据为空";
				return JsonConvert.SerializeObject(res);
			}
			
			foreach (FalldownDeviceModel one in list)
			{
				FalldownDevice dbData = _mapper.Map<FalldownDevice>(one);				
				bool ret = _repository.Update(dbData,false);
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
			VueResMsg<FalldownDeviceModel> res = new VueResMsg<FalldownDeviceModel>();

			if (ids == null || ids.Count <= 0)
			{
				res.code = 400;
				res.msg = "数据为空";
				return JsonConvert.SerializeObject(res);
			}

			foreach (long id in ids)
			{
				FalldownDevice dbData = new FalldownDevice();
				dbData.Id = id;
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
	}
}
