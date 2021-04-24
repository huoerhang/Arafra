using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Andef.DependencyInjection
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

        public bool IncludeSelf { get; set; } = false;

        public ServiceLifetime Lifetime
            => _lifetime;
    }
}
