using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Domain.Items.Events
{
   public class ItemDeletedEvent : ItemEvent
    {
        public ItemDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}
