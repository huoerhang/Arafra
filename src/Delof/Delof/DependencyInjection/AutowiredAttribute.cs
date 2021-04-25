using AspectCore.DependencyInjection;
using System;

namespace Delof.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class AutowiredAttribute : FromServiceContextAttribute
    {
    }
}
