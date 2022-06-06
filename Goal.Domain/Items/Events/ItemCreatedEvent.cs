using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Domain.Items.Events
{
    public class ItemCreatedEvent : ItemEvent
    {
        public ItemCreatedEvent(Guid id, string name, string type, DateTime expiration)
        {
            Id = id;
            Name = name;
            Type = type;
            Expiration = expiration;
        }
    }
}
