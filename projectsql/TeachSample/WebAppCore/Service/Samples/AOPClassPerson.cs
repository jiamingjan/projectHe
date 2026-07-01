using Autofac.Extras.DynamicProxy;
using WebAppCore.AutofacExtensions;


namespace WebAppCore.Service.Samples
{
    /// <summary>
    ///
    /// </summary>
    [Intercept(typeof(CustomClassInterceptor))]
    public class AOPClassPerson : IAOPClassPerson
    {
        /// <summary>
        ///
        /// </summary>
        public virtual void ProcessAOP()
        {
            Console.WriteLine("AOPClassPerson.ProcessAOP()");
        }

        /// <summary>
        ///
        /// </summary>
        public void Process()
        {
            Console.WriteLine("AOPClassPerson.Process()");
        }
    }
}