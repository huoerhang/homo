using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Homo.DependencyInjection
{
    public class ServiceTypeDescriptor
    {
        public IReadOnlyList<Type> ServiceTypes { get; private set; }

        public Type ImplementType { get; private set; }

        public ServiceLifetime Lifetime { get; private set; }

        public ServiceTypeDescriptor(IEnumerable<Type> serviceTypes, Type implementType, ServiceLifetime lifetime)
        {
            serviceTypes.CheckNotNull(nameof(serviceTypes));
            implementType.CheckNotNull(nameof(implementType));
            ServiceTypes = serviceTypes.ToImmutableList();
            ImplementType = implementType;
            Lifetime = lifetime;
        }

        internal List<ServiceDescriptor> BuildServiceDescriptors()
        {
            return ServiceTypes.Select(c => new ServiceDescriptor(c, ImplementType, Lifetime)).ToList();
        }
    }
}
