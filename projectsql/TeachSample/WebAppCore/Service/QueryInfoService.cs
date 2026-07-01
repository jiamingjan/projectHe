using Autofac.Extras.DynamicProxy;
using WebAppCore.AutofacExtensions;
using System.Text.Json;
using WebAppCore.DbModel;
using Microsoft.EntityFrameworkCore;
using WebAppCore.ViewModels;
using Service;
using IRepository;
using System.Linq.Expressions;
using WebAppCore.DbExtensions;
using AutoMapper;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NPOI.SS.Formula.Functions;
using NPOI.HSSF.Record;

namespace WebAppCore.Service
{
    /// <summary>
    ///
    /// </summary>   
    public class QueryInfoService : BaseService<queryinfo, int>, IQueryInfoService
    {      
        private readonly IQueryInfoDAL _repository;
        private readonly IMapper _mapper;
        public QueryInfoService(IQueryInfoDAL repository,IMapper mapper) : base(repository)
        {
            _repository = repository;            
            _mapper = mapper;
        }
        
            
        public string GetTableData(int page, int rows, string user, string queryStock, string startTime, string endTime)
        {     
            int total = 0;    

            Expression<Func<queryinfo, bool>> pieceWhere = null!;
            pieceWhere = PredicateExtensions.True<queryinfo>();
            if (!string.IsNullOrEmpty(user))
            {
                pieceWhere = PredicateExtensions.And(pieceWhere, r => r.User.Equals(user));               
            }
            if (!string.IsNullOrEmpty(queryStock))
            {
                pieceWhere = PredicateExtensions.And(pieceWhere, r => r.QueryStock.Equals(queryStock));
            }
            
            if (!string.IsNullOrEmpty(startTime))
            {
                DateTime start = Convert.ToDateTime(startTime);
                pieceWhere = PredicateExtensions.And(pieceWhere, r => r.QueryTime >= start);
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                DateTime end = Convert.ToDateTime(endTime);
                pieceWhere = PredicateExtensions.And(pieceWhere, r => r.QueryTime <= end);
            }

            List<queryinfo> records = _repository.LoadPageEntities<long>((int)page!, (int)rows!, out total, pieceWhere, r => r.Id, false).ToList();

            //下面这句转换出错，为什么？
            //List<QueryInfoModel> results = _mapper.Map<List<QueryInfoModel>>(records);
            //JqGridTable<QueryInfoModel> jqGridTable = new JqGridTable<QueryInfoModel>();
            JqGridTable<queryinfo> jqGridTable = new JqGridTable<queryinfo>();
            jqGridTable.page = page;
            jqGridTable.records = total;
            //jqGridTable.rows = results;
            jqGridTable.rows = records;  
            jqGridTable.total = total / rows;
            if (total % rows != 0) jqGridTable.total++;            
            string json = JsonSerializer.Serialize(jqGridTable);
            return json;
        }


        public string GetVxeTableData(int pageIndex, int pageSize, QueryInfoModel data)
        {
            int total = 0;

            Expression<Func<queryinfo, bool>> pieceWhere = null!;
            pieceWhere = PredicateExtensions.True<queryinfo>();
            if (!string.IsNullOrEmpty(data.User))
            {
                pieceWhere = PredicateExtensions.And(pieceWhere, r => r.User.Equals(data.User));
            }
            if (!string.IsNullOrEmpty(data.QueryStock))
            {
                pieceWhere = PredicateExtensions.And(pieceWhere, r => r.QueryStock.Equals(data.QueryStock));
            }

          
            
            List<queryinfo> records = _repository.LoadPageEntities<long>((int)pageIndex!, (int)pageSize!, out total, pieceWhere, r => r.Id, false).ToList();
            List<QueryInfoModel> results = _mapper.Map<List<QueryInfoModel>>(records);
            VxeGridTable<QueryInfoModel> xGrid = new VxeGridTable<QueryInfoModel>();
            xGrid.page = new page();
            xGrid.page.currentPage = pageIndex;
            xGrid.page.pageSize = pageSize;
            xGrid.page.total = total;
            xGrid.result = results;
            string json = JsonSerializer.Serialize(xGrid);
            return json;

        }
        public string DeleteTableData(string Ids)
        {
            VueResMsg<string> resMsg = new VueResMsg<string>();

            if (string.IsNullOrEmpty(Ids))
            {
                resMsg.SetFail(-1, "Id为空！");
                return JsonSerializer.Serialize(resMsg);
            }

            string[] idArrary = Ids.Split(',');
            if (idArrary == null || idArrary.Length <= 0)
            {
                resMsg.SetFail(-1, "Id错误！");
                return JsonSerializer.Serialize(resMsg);
            }

            foreach (string idStr in idArrary)
            {
                queryinfo data = new queryinfo();
                uint id = 0;
                if (uint.TryParse(idStr, out id))
                {
                    data.Id = id;
                    _repository.Delete(data, false);
                }
            }

            int num = _repository.SaveChange();

            if (num > 0)
                resMsg.SetOK(num.ToString());
            else
                resMsg.SetFail(-1, "删除出错！"); ;

            string json = JsonSerializer.Serialize(resMsg);
            return json;
        }

        public string AddTableData(List<QueryInfoModel> data)
        {

            VueResMsg<string> resMsg = new VueResMsg<string>();
            if (data == null || data.Count <= 0)
            {
                resMsg.code = -1;
                resMsg.msg = "没有数据！";
                return JsonSerializer.Serialize(resMsg);
            }

            foreach (QueryInfoModel one in data)
            {
                queryinfo info = _mapper.Map<queryinfo>(one);
                info.Id = 0; //特别注意，这里一定要赋值为0，否则会出错
                _repository.Add(info,false);
            }


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

            string json = JsonSerializer.Serialize(resMsg);
            return json;
        }

        public string DeleteTableData(List<QueryInfoModel> data)
        {
            VueResMsg<string> resMsg = new VueResMsg<string>();
            if (data == null || data.Count <= 0)
            {
                resMsg.code = -1;
                resMsg.msg = "没有数据！";
                return JsonSerializer.Serialize(resMsg);
            }

            foreach (QueryInfoModel one in data)
            {
                queryinfo user = new queryinfo();

                user.Id = one.Id;
                _repository.Delete(user, false);
            }


            int addNum = _repository.SaveChange();
            if (addNum >= 0)
            {
                resMsg.SetOK();
                resMsg.msg = addNum.ToString();
            }
            else
            {
                resMsg.code = -1;
                resMsg.msg = "删除失败！";
            }

            string json = JsonSerializer.Serialize(resMsg);
            return json;
        }

        public string UpdateTableData(List<QueryInfoModel> data)
        {

            VueResMsg<string> resMsg = new VueResMsg<string>();
            if (data == null || data.Count <= 0)
            {
                resMsg.code = -1;
                resMsg.msg = "没有数据！";
                return JsonSerializer.Serialize(resMsg);
            }

            foreach (QueryInfoModel one in data)
            {
                queryinfo user = _mapper.Map<queryinfo>(one);
                
                _repository.Update(user, false);
            }


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

            string json = JsonSerializer.Serialize(resMsg);
            return json;
        }
    }
}