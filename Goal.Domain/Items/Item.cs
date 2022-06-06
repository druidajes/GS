using Goal.Domain.Items.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Domain.Items
{
    public class Item : IAggregateRoot
    {
        public ItemId ItemId { get; set; }

        public Name Name { get; set; }

        public ValueObjects.Type Type { get; set; }

        public Expiration Expiration { get; set; }
    }
}
