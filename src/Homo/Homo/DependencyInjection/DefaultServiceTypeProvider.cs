using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Homo.DependencyInjection
{
    internal class DefaultServiceTypeProvider : ServiceTypeProviderBase
    {
        public override ServiceTypeDescriptor GetServiceTypeDescriptor(Type implementationType)
        {
            var typeInfo = implementationType.GetTypeInfo();
            var attribute = typeInfo.GetCustomAttribute<DependencyAttribute>(true);

            if (attribute == null)
            {
                return null;
            }

            List<Type> serviceTypes = null;

            if (!attribute.SpecifyServices.IsNullOrEmpty())
            {
                serviceTypes = attribute.SpecifyServices.ToList();
            }

            if (serviceTypes == null)
            {
                serviceTypes = serviceTypes ?? new List<Type>();
                var interfaceTypes = implementationType.GetInterfaces();
                serviceTypes.AddRange(interfaceTypes);
            }

            var lifetime = attribute.Lifetime;

            if (attribute.IncludeSelf)
            {
                serviceTypes = serviceTypes ?? new List<Type>();
                serviceTypes.Add(implementationType);
            }

            if (serviceTypes.IsNullOrEmpty())
            {
                return null;
            }

            return new ServiceTypeDescriptor(serviceTypes, implementationType, lifetime);
        }
    }
}
