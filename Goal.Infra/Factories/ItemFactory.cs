using Goal.Domain.Items;
using Goal.Domain.Items.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Infra.Factories
{
    public class ItemFactory : Item
    {
        public ItemFactory()
        {

        }

        public ItemFactory(Name name, Domain.Items.ValueObjects.Type type)
        {
            ItemId = new ItemId(Guid.NewGuid());
            Name = name;
            Type = type;
            Expiration = new Expiration(DateTime.Now.AddDays(180));
        }
    }
}
