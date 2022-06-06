using Goal.Domain.Items;
using Goal.Domain.Items.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Tests.UnitTests.Helpers
{

    public static class ItemHelper
    {
        public static Item GetItem()
        {
            return new Item()
            {
                ItemId = new ItemId(Guid.NewGuid()),
                Name = new Name("Name"),
                Type = new Domain.Items.ValueObjects.Type("Name"),
                Expiration = new Expiration(DateTime.Now.AddDays(180))
            };
        }

        public static IEnumerable<Item> Getitems()
        {
            return new List<Item>()
            {
                GetItem()
            };
        }

    }
}
