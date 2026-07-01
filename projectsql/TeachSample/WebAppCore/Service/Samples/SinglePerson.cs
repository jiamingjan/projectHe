using Autofac.Extras.DynamicProxy;
using WebAppCore.AutofacExtensions;


namespace WebAppCore.Service.Samples
{
    /// <summary>
    ///
    /// </summary>
    public class SinglePerson : IPerson
    {
        /// <summary>
        ///
        /// </summary>
        public virtual void Eat(string con)
        {
            Console.WriteLine(con);
        }

        
    }
}