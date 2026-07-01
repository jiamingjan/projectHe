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
    public class SysDictDatumService : BaseService<SysDictDatum, int>, ISysDictDatumService
	{
        private readonly ISysDictDatumDAL _repository;
        private readonly IMapper _mapper;
        public SysDictDatumService(ISysDictDatumDAL repository, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }


		/// <summary>
		/// 根据字典类型获取字典
		/// </summary>
		/// <param name="dictType"></param>
		/// <returns></returns>
		public string GetDicts(string dictType)
		{
			VueResMsg<List<SysDictDatumModel>> res = new VueResMsg<List<SysDictDatumModel>>();

			Expression<Func<SysDictDatum, bool>> pieceWhere = PredicateExtensions.True<SysDictDatum>();
			if (!string.IsNullOrEmpty(dictType))
				pieceWhere = PredicateExtensions.And(pieceWhere, r => r.DictType.ToUpper().Equals(dictType.ToUpper()));

			List<SysDictDatum> records = _repository.LoadEntities<long>(pieceWhere, 
				r => r.DictCode, true).ToList();

			List<SysDictDatumModel> results = _mapper.Map<List<SysDictDatumModel>>(records);			

			res.SetOK();
			res.data = results;
			return JsonConvert.SerializeObject(res);
		}

		
    }
}