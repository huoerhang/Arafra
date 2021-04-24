namespace System.Reflection
{
    public static class MemberInfoExtensions
    {
        public static TAttribute GetAttributeOfTypeOrBaseTypesOrNull<TAttribute>(this Type type, bool inherit = true)
            where TAttribute:Attribute
        {
            var attribute = type.GetTypeInfo().GetCustomAttribute<TAttribute>(inherit);

            if (attribute != null)
            {
                return attribute;
            }

            var baseType = type.GetTypeInfo().BaseType;

            if (baseType == null)
            {
                return null;
            }

            return baseType.GetAttributeOfTypeOrBaseTypesOrNull<TAttribute>(inherit);
        }
    }
}
