using Castle.DynamicProxy;

namespace WebAppCore.AutofacExtensions
{
    /// <summary>
    /// 接口级别的拦截器，标注在要实现AOP功能的接口类型上。
    /// </summary>
    public sealed class CustomInterfaceInterceptor : IInterceptor
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            {
                Console.WriteLine("CustomInterfaceInterceptor.Before");
            }
            invocation.Proceed();
            {
                Console.WriteLine("CustomInterfaceInterceptor.After");
            }
        }
    }
}