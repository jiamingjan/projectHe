
namespace WebAppCore.ViewModels
{
    /// <summary>
    /// 注意去寻找model的写法，很多新的 helm
    ///
    /// </summary>
    public class StockRecomModel
    {
        public uint Id { get; set; }

        /// <summary>
        /// 股票代码
        /// </summary>
        public string? StockCode { get; set; }

        /// <summary>
        /// 股票名称
        /// </summary>
        public string? StockName { get; set; }

        /// <summary>
        /// 所属行业
        /// </summary>
        public string? StockField { get; set; }
        public int? StockScore { get; set; }

        public DateOnly? StockDate { get; set; }

        public string? UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

    }


    public class StockSearchResult
    {       

        /// <summary>
        /// 股票代码
        /// </summary>
        public string? StockCode { get; set; }

        /// <summary>
        /// 股票名称
        /// </summary>
        public string? StockName { get; set; }

        /// <summary>
        /// 所属行业
        /// </summary>       

    }

}