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
using NPOI.SS.Formula;
//using Newtonsoft.Json;


namespace WebAppCore.Service
{
    /// <summary>
    ///
    /// </summary>   
    public class FalldownLocationService : BaseService<FalldownLocation, int>, IFalldownLocationService
	{
        private readonly IFalldownLocationDAL _repository;		
		private readonly IMapper _mapper;
        public FalldownLocationService(IFalldownLocationDAL repository,IMapper mapper) : base(repository)
        {
            _repository = repository;			
			_mapper = mapper;
        }

		public string Query(string deviceCode, DateTime? startTime, DateTime? endTime)
		{
			int total = 0;

			List<loc> path = new List<loc>();
			if (string.IsNullOrEmpty(deviceCode))
				return JsonConvert.SerializeObject(path);

			Expression<Func<FalldownLocation, bool>> pieceWhere = PredicateExtensions.True<FalldownLocation>();
			if (!string.IsNullOrEmpty(deviceCode))
				pieceWhere = PredicateExtensions.And(pieceWhere, r => r.DeviceCode.Equals(deviceCode));				
			if (startTime != null)
				pieceWhere = PredicateExtensions.And(pieceWhere, r => r.UpdateTime >= startTime);
			if (endTime != null)
				pieceWhere = PredicateExtensions.And(pieceWhere, r => r.UpdateTime <= endTime);
			

			List<FalldownLocation> records = _repository.LoadEntities<long>(pieceWhere, r => r.Id, true).ToList();
			if (records != null && records.Count > 0)
			{				
				foreach (FalldownLocation one in records)
				{
					loc loc1 = new loc();
					loc1.lng = one.Lon;
					loc1.lat = one.Lat;
					path.Add(loc1);
				}
			}

			return JsonConvert.SerializeObject(path);
		}
	}
}
