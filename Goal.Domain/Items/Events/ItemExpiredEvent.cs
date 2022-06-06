using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Domain.Items.Events
{
   public class ItemExpiredEvent : ItemEvent
    {
        public ItemExpiredEvent(Guid id)
        {
            Id = id;
        }
    }
}
