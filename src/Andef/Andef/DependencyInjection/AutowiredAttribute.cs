using AspectCore.DependencyInjection;
using System;

namespace Andef.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class AutowiredAttribute : FromServiceContextAttribute
    {
    }
}
