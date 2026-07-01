
namespace WebAppCore.ViewModels
{
    /// <summary>
    /// 返回的最外层消息定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JqGridTable<T>
    {
        /// <summary>
        /// 总页数
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// 记录总数
        /// </summary>
        public int records { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public List<T> rows { get; set; }
    }


    public class CountTable
    {
        public int count { get; set; }
    }

}