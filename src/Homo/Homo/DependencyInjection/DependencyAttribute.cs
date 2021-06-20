using System;
using Microsoft.Extensions.DependencyInjection;

namespace Homo.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class DependencyAttribute : Attribute
    {
        private readonly ServiceLifetime _lifetime;

        public DependencyAttribute()
        {
            _lifetime = ServiceLifetime.Transient;
        }

        public DependencyAttribute(ServiceLifetime lifetime)
        {
            _lifetime = lifetime;
        }

        public Type[] SpecifyServices { get; set; }

        public bool IncludeSelf { get; set; }

        public ServiceLifetime Lifetime
            => _lifetime;
    }
}
