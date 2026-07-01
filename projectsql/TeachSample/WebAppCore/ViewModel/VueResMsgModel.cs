
namespace WebAppCore.ViewModels
{
    /// <summary>
    /// 返回的最外层消息定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class VueResMsg<T>
    {
        /// <summary>
        /// 返回消息编码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 消息提示
        /// </summary>
        public string? msg { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public T? data { get; set; }

        /// <summary>
        /// 这个是针对我们的前端vue项目的要求
        /// </summary>
        
        public void SetOK(string message = "success")
        {
            code = 200;
            msg = message;
        }
        public void SetFail(int codeValue, string message)
        {
            code = codeValue;
            msg = message;
        }
    }

    /// <summary>
    /// 下面是自带表格的数据返回定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class VueTable<T>
    {
        /// <summary>
        /// 数据
        /// </summary>
        public List<T>? data { get; set; }
        /// <summary>
        /// 每页记录数量
        /// </summary>
        public int pageSize { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int pageNum { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int total { get; set; }
    }

    public class KeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public KeyValue() { }
        public KeyValue(string k, string v)
        {
            Key = k;
            Value = v;
        }
    }
}