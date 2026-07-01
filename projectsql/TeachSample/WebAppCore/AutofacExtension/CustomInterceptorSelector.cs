using Castle.DynamicProxy;
using System.Reflection;

namespace WebAppCore.AutofacExtensions
{
    /// <summary>
    ///
    /// </summary>
    public class CustomInterceptorSelector : IInterceptorSelector
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="type"></param>
        /// <param name="method"></param>
        /// <param name="interceptors">如果类型有标注拦截器，这里会获取所有拦截器。</param>
        /// <returns></returns>
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            IList<IInterceptor> interceptorsList = new List<IInterceptor>();
            interceptorsList.Add(new CustomInterfaceInterceptor());
            //在这个方法里面，我们可以过滤拦截器，想是哪个起作用哪个就起作用。返回的拦截器，就是起作用的拦截器。
            return interceptorsList.ToArray();
        }
    }
}