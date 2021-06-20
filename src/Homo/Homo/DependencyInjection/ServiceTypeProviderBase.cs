using System;

namespace Homo.DependencyInjection
{
    public abstract class ServiceTypeProviderBase : IServiceTypeProvider
    {
        public abstract ServiceTypeDescriptor GetServiceTypeDescriptor(Type implementationType);
    }
}
