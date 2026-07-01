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
    public class SysPostsService : BaseService<SysPost, int>, ISysPostsService
	{
        private readonly ISysPostsDAL _repository;	
		private readonly IMapper _mapper;
        public SysPostsService(ISysPostsDAL repository, IMapper mapper) : base(repository)
        {
            _repository = repository;			
			_mapper = mapper;
        }

		public string GetTableData(int pageNum, int pageSize)
		{
			int total = 0;
			VueResMsg<VueTable<SysPostsModel>> res = new VueResMsg<VueTable<SysPostsModel>>();

			List<SysPost> records = _repository.LoadPageEntities<string>(pageNum, pageSize, out total, null, r => r.PostName, true).ToList();

			List<SysPostsModel> listdata = _mapper.Map<List<SysPostsModel>>(records);	
			//return
			res.SetOK();
			VueTable<SysPostsModel> table = new VueTable<SysPostsModel>();
			table.total = total;
			table.pageNum = pageNum;
			table.pageSize = pageSize;
			table.data = listdata;
			res.data = table;
			return JsonConvert.SerializeObject(res);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="post">查询条件</param>
		/// <returns></returns>
		public List<SysPostsModel> GetPosts(SysPostsModel post)
		{
			List<SysPostsModel> resList = new List<SysPostsModel>();
			Expression<Func<SysPost, bool>> pieceWhere = null;
			if (post != null)
			{
				//设置查询条件
				pieceWhere = PredicateExtensions.True<SysPost>();
				pieceWhere = PredicateExtensions.And(pieceWhere, r => r.PostId == post.postId);
				//下面还有其他条件
			}

			List<SysPost> records = _repository.LoadEntities<long>(pieceWhere, r => r.PostId, true).ToList();

			if (records != null && records.Count > 0)
			{
				resList = _mapper.Map<List<SysPostsModel>>(records);				
			}
			return resList;
		}

		
	}
}