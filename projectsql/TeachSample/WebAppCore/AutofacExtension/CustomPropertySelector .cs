using Autofac.Core;
using System.Reflection;
using WebAppCore.AutofacExtensions;

namespace WebAppCore.AutofacExtensions
{
    public sealed class CustomPropertySelector : IPropertySelector
    {
        public bool InjectProperty(PropertyInfo propertyInfo, object instance)
        {
            return propertyInfo.IsDefined(typeof(CustomPropertySelectorAttribute), false);
        }
    }
}