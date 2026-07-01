
namespace WebAppCore.ViewModels
{
    public class page
    {
        /// <summary>
        /// 每页记录数量
        /// </summary>
        public int pageSize { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int currentPage { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int total { get; set; }
    }

    public class VxeGridTable<T>
    {
        /// <summary>
        /// 页信息
        /// </summary>
        public page page { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public List<T> result { get; set; }
    }

    //导入结果返回
    public class ImportResult
    {
        /// <summary>
        /// 成功行数
        /// </summary>
        public int insertRows { get; set; }
    }

    //total
    public class Total
    {
        public int total { get; set; }

    }
}
