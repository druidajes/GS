using Goal.Domain.Items.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Application.Handlers
{
    public class ItemEventHandler
    {
        public async Task HandleItemCreatedEvent(ItemCreatedEvent itemCreatedEvent)
        {
            // Here you can do whatever you need with this event, you can propagate the data using a queue, calling another API or sending a notification or whatever
            // With this scenario, you are building a event driven architecture with microservices and DDD
        }

        public async Task HandleItemDeletedEvent(ItemDeletedEvent itemDeletedEvent)
        {
            // Here you can do whatever you need with this event, you can propagate the data using a queue, calling another API or sending a notification or whatever
            // With this scenario, you are building a event driven architecture with microservices and DDD
        }

        public async Task HandleItemExpireEvent(ItemExpiredEvent itemExpiredEvent)
        {
            // Here you can do whatever you need with this event, you can propagate the data using a queue, calling another API or sending a notification or whatever
            // With this scenario, you are building a event driven architecture with microservices and DDD
        }
    }
}
