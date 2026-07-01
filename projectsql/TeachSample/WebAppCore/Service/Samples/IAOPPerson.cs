using Autofac.Extras.DynamicProxy;
using WebAppCore.AutofacExtensions;

namespace WebAppCore.Service.Samples
{
    /// <summary>
    ///
    /// </summary>
    [Intercept(typeof(CustomInterfaceInterceptor))]
    public interface IAOPPerson
    {
        /// <summary>
        ///
        /// </summary>
        void Process();

        /// <summary>
        ///
        /// </summary>
        void ProcessTwo();

        /// <summary>
        ///
        /// </summary>
        void ProcessThree();
    }
}