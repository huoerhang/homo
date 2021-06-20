using System;

namespace Homo.DependencyInjection
{
    public interface IServiceTypeProvider
    {
        ServiceTypeDescriptor GetServiceTypeDescriptor(Type implementationType);
    }
}
