using Autofac.Extras.DynamicProxy;
using WebAppCore.AutofacExtensions;

namespace WebAppCore.Service.Samples
{
    /// <summary>
    ///
    /// </summary>
    [Intercept(typeof(CustomInterfaceInterceptor))]
    public interface IPerson
    {
        /// <summary>
        ///
        /// </summary>
        void Eat(string content);
       
    }
}