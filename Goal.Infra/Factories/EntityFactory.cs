using Goal.Domain.Items;
using Goal.Domain.Items.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Infra.Factories
{
    public class EntityFactory : IItemFactory
    {
        public Item CreateItemInstance(Name name, Domain.Items.ValueObjects.Type type)
        {
            return new ItemFactory(name, type);
        }
    }
}
