using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andef.Ddd.Domain.Entities
{
    public static class EntityExtensions
    {
        public static bool EntityEquals(this IEntity self, IEntity other)
        {
            if (self == null || other == null)
            {
                return false;
            }

            if (ReferenceEquals(self, other))
            {
                return true;
            }

            var selfType = self.GetType();
            var otherType = other.GetType();

            if (!selfType.IsAssignableTo(otherType) && !otherType.IsAssignableTo(selfType))
            {
                return false;
            }

            var equalizeResult = EntityEqualizerContainer.Instance.EntityEquals(self, other);

            if (equalizeResult)
            {
                return true;
            }

            if (self.HasDefaultKey() && other.HasDefaultKey())
            {
                return false;
            }

            var selfKeys = self.GetKeys();
            var otherKeys = other.GetKeys();

            if (selfKeys.Length != otherKeys.Length)
            {
                return false;
            }

            for (var i = 0; i < selfKeys.Length; i++)
            {
                var selfKey = selfKeys[i];
                var otherKey = otherKeys[i];

                if (selfKey == null)
                {
                    if (otherKey == null)
                    {
                        continue;
                    }

                    return false;
                }

                if (otherKey == null)
                {
                    return false;
                }

                if (selfKey.IsDefaultValue() && otherKey.IsDefaultValue())
                {
                    return false;
                }

                if (!selfKey.Equals(otherKey))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool HasDefaultKey(this IEntity entity)
        {
            entity.CheckNotNull(nameof(entity));

            foreach (var key in entity.GetKeys())
            {
                if (!key.IsDefaultValue())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
