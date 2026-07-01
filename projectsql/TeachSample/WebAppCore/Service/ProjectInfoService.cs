using AutoMapper;
using IRepository;
using Microsoft.EntityFrameworkCore;
using MyTool;
using Newtonsoft.Json;
using Service;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.Json;
using WebAppCore.DbExtensions;
using WebAppCore.DbModel;
using WebAppCore.ViewModels;

namespace WebAppCore.Service
{
    public class ProjectInfoService : BaseService<ProjectInfo, int>, IProjectInfoService
    {
        private readonly IProjectInfoDAL _repository;
        private readonly IMapper _mapper;

        public ProjectInfoService(IProjectInfoDAL repository, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public string GetTableData(int pageNum, int pageSize, ProjectInfoModel dataParams)
        {
            int total = 0;
            VueResMsg<VueTable<ProjectInfoModel>> res = new VueResMsg<VueTable<ProjectInfoModel>>();

            Expression<Func<ProjectInfo, bool>> pieceWhere = PredicateExtensions.True<ProjectInfo>();

            if (dataParams != null && !string.IsNullOrEmpty(dataParams.PrjName))
                pieceWhere = PredicateExtensions.And(pieceWhere, r => r.PrjName.Contains(dataParams.PrjName));

            if (dataParams != null && !string.IsNullOrEmpty(dataParams.PrjCode))
                pieceWhere = PredicateExtensions.And(pieceWhere, r => r.PrjCode.Contains(dataParams.PrjCode));

            if (dataParams != null && !string.IsNullOrEmpty(dataParams.Manager))
                pieceWhere = PredicateExtensions.And(pieceWhere, r => r.Manager.Contains(dataParams.Manager));

            if (dataParams != null && !string.IsNullOrEmpty(dataParams.PrjStatus))
                pieceWhere = PredicateExtensions.And(pieceWhere, r => r.PrjStatus.Equals(dataParams.PrjStatus));

            List<ProjectInfo> records = _repository.LoadPageEntities<long>(pageNum, pageSize, out total, pieceWhere, r => r.Id, false).ToList();
            List<ProjectInfoModel> listdata = _mapper.Map<List<ProjectInfoModel>>(records);

            res.SetOK();
            VueTable<ProjectInfoModel> table = new VueTable<ProjectInfoModel>();
            table.total = total;
            table.pageNum = pageNum;
            table.pageSize = pageSize;
            table.data = listdata;
            res.data = table;

            return JsonConvert.SerializeObject(res);
        }

        public string AddTableData(List<ProjectInfoModel> list)
        {
            VueResMsg<ProjectInfoModel> res = new VueResMsg<ProjectInfoModel>();

            if (list == null || list.Count <= 0)
            {
                res.code = 400;
                res.msg = "数据为空";
                return JsonConvert.SerializeObject(res);
            }

            foreach (ProjectInfoModel one in list)
            {
                ProjectInfo dbData = _mapper.Map<ProjectInfo>(one);
                _repository.Add(dbData, false);
            }

            int num = _repository.SaveChange();
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

        public string UpdateTableData(List<ProjectInfoModel> list)
        {
            VueResMsg<ProjectInfoModel> res = new VueResMsg<ProjectInfoModel>();

            if (list == null || list.Count <= 0)
            {
                res.code = 400;
                res.msg = "数据为空";
                return JsonConvert.SerializeObject(res);
            }

            foreach (ProjectInfoModel one in list)
            {
                ProjectInfo dbData = _mapper.Map<ProjectInfo>(one);
                _repository.Update(dbData, false);
            }

            int num = _repository.SaveChange();
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

        public string DeleteTableData(List<long> ids)
        {
            VueResMsg<ProjectInfoModel> res = new VueResMsg<ProjectInfoModel>();

            if (ids == null || ids.Count <= 0)
            {
                res.code = 400;
                res.msg = "数据为空";
                return JsonConvert.SerializeObject(res);
            }

            foreach (long id in ids)
            {
                ProjectInfo dbData = new ProjectInfo();
                dbData.Id = id;
                _repository.Delete(dbData, false);
            }

            int num = _repository.SaveChange();
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