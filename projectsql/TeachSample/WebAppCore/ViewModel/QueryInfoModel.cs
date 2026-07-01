
namespace WebAppCore.ViewModels
{
    /// <summary>
    /// 注意去寻找model的写法，很多新的 helm
    ///
    /// </summary>
    public class QueryInfoModel
    {
        public uint Id { get; set; }

        /// <summary>
        /// 查询的用户
        /// </summary>
        public string? User { get; set; }

        /// <summary>
        /// 输入的查询股票
        /// </summary>
        public string? QueryStock { get; set; }

        /// <summary>
        /// 返回的股票
        /// </summary>
        public string? RespStocks { get; set; }

        /// <summary>
        /// 返回的股票交易（产生）日期
        /// </summary>
        public DateOnly? RespStockDate { get; set; }

        /// <summary>
        /// 查询日期时间
        /// </summary>
        public DateTime? QueryTime { get; set; }

    }

    
}