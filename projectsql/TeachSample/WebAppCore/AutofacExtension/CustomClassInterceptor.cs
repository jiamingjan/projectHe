using Autofac.Core;
using System.Reflection;
using Castle.DynamicProxy;

namespace WebAppCore.AutofacExtensions
{
    /// <summary>
    /// 类级别的拦截器，标注在要实现AOP功能的类型上。
    /// </summary>
    public sealed class CustomClassInterceptor : IInterceptor
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            {
                Console.WriteLine("CustomClassInterceptor.Before");
            }
            invocation.Proceed();
            {
                Console.WriteLine("CustomClassInterceptor.After");
            }
        }
    }
}