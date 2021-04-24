using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andef.Ddd.Domain.Entities
{
    internal class EntityEqualizerContainer : List<IEntityEqualizer>
    {
        private static EntityEqualizerContainer _entityEqualizers = new EntityEqualizerContainer();

        public static EntityEqualizerContainer Instance => _entityEqualizers;

        private EntityEqualizerContainer()
        {

        }

        public bool EntityEquals(IEntity self, IEntity other)
        {
            if (this.IsNullOrEmpty())
            {
                return true;
            }

            foreach(var item in this)
            {
                bool isEquals= item.EntityEquals(self, other);

                if (isEquals)
                {
                    return isEquals;
                }
            }

            return false;
        }
    }
}
