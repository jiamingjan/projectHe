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
using NPOI.SS.UserModel;
using System.Security.Policy;
//using Newtonsoft.Json;


namespace WebAppCore.Service
{
    /// <summary>
    ///
    /// </summary>   
    public class ColorDiffService : BaseService<ColorDiff, int>, IColorDiffService
	{
        private readonly IColorDiffDAL _repository;		
		private readonly IMapper _mapper;
        public ColorDiffService(IColorDiffDAL repository, IMapper mapper) : base(repository)
        {
            _repository = repository;			
			_mapper = mapper;
        }

		public string GetAllData()
		{			
			VueResMsg<List<ColorDiffModel>> res = new VueResMsg<List<ColorDiffModel>>();

			List<ColorDiff> records = _repository.LoadEntities<string?>(null, r => r.Name, true).ToList();
			List<ColorDiffModel> listdata = _mapper.Map<List<ColorDiffModel>>(records);

			foreach (ColorDiffModel model in listdata) //为了节约流量，图片不传到前台
				model.Image = "";
			//return
			res.SetOK();
			
			res.data = listdata;
			return JsonConvert.SerializeObject(res);
		}

		public string GetListData(int? pageNum, int? pageSize, string? name)
		{
			int total = 0;
			Expression<Func<ColorDiff, bool>> pieceWhere = PredicateExtensions.True<ColorDiff>();
			if(!string.IsNullOrWhiteSpace(name))
				pieceWhere = PredicateExtensions.And(pieceWhere, r => r.Name.Contains(name));
			VueResMsg<List<ColorDiffModel>> res = new VueResMsg<List<ColorDiffModel>>();
			List<ColorDiff> records = _repository.LoadPageEntities<string?>((int)pageNum, (int)pageSize, 
				out total, pieceWhere, r => r.Name, false).ToList();
			List<ColorDiffModel> listdata = _mapper.Map<List<ColorDiffModel>>(records);

			foreach (ColorDiffModel model in listdata) //为了节约流量，图片不传到前台
				model.Image = "";
			//return
			res.SetOK();

			res.data = listdata;
			return JsonConvert.SerializeObject(res);
		}

		public string GetImage(string name)
		{			
			VueResMsg<string> resMsg = new VueResMsg<string>();
			if (string.IsNullOrEmpty(name))
			{
				resMsg.code = -1;
				resMsg.msg = "名称不能为空！";
				return System.Text.Json.JsonSerializer.Serialize(resMsg);
			}
			Expression<Func<ColorDiff, bool>> pieceWhere = PredicateExtensions.True<ColorDiff>();
			pieceWhere = PredicateExtensions.And(pieceWhere, r => r.Name.Equals(name));
			List<ColorDiff> records = _repository.LoadEntities<long>(pieceWhere, r => r.Id, true).ToList();
			if (records != null && records.Count > 0) //数据存在了，做update
			{
				ColorDiff colorDiff = records[0];
				resMsg.SetOK();
				resMsg.data = colorDiff.Image;
			}
			else
			{
				resMsg.code = -2;
				resMsg.msg = "没找到！";
			}
			string json = System.Text.Json.JsonSerializer.Serialize(resMsg);
			return json;
		}


		public string UpdateTableData(ColorDiffModel data)
		{
			VueResMsg<string> resMsg = new VueResMsg<string>();
			Expression<Func<ColorDiff, bool>> pieceWhere = PredicateExtensions.True<ColorDiff>();
			if (data == null || string.IsNullOrEmpty(data.Name))
			{
				resMsg.code = -1;
				resMsg.msg = "名称不能为空！";
				return System.Text.Json.JsonSerializer.Serialize(resMsg);
			}

			pieceWhere = PredicateExtensions.And(pieceWhere, r => r.Name.Equals(data.Name));
			List<ColorDiff> records = _repository.LoadEntities<long>(pieceWhere, r => r.Id, true).ToList();
			if (records != null && records.Count > 0) //数据存在了，做update
			{
				ColorDiff colorDiff = records[0];
				colorDiff.Brightness = data.Brightness;
				colorDiff.RedGreen = data.RedGreen;
				colorDiff.YellowBlue = data.YellowBlue;
				if(!string.IsNullOrEmpty(data.Image))
					colorDiff.Image = data.Image;
				_repository.Update(colorDiff);

				int addNum = _repository.SaveChange();
				if (addNum >= 0)
				{
					resMsg.SetOK();
					resMsg.msg = addNum.ToString();
				}
				else
				{
					resMsg.code = -1;
					resMsg.msg = "更新失败！";
				}
			}
			else //insert
			{
				ColorDiff colorDiff = _mapper.Map<ColorDiff>(data);				
				_repository.Add(colorDiff, false);
				int addNum = _repository.SaveChange();
				if (addNum >= 0)
				{
					resMsg.SetOK();
					resMsg.msg = addNum.ToString();
				}
				else
				{
					resMsg.code = -1;
					resMsg.msg = "新增失败！";
				}
			}

			string json = System.Text.Json.JsonSerializer.Serialize(resMsg);
			return json;
		}
	}
}