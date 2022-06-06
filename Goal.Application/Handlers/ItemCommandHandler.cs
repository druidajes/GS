using Goal.Domain.Items;
using FluentMediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Goal.Domain.Items.Commands;
using Goal.Domain.Items.Events;

namespace Goal.Application.Handlers
{
    public class ItemCommandHandler
    {
        private readonly IItemFactory _itemFactory;
        private readonly IItemRepository _itemRepository;
        private readonly IMediator _mediator;

        public ItemCommandHandler(IItemRepository itemRepository, IItemFactory itemFactory, IMediator mediator)
        {
            _itemRepository = itemRepository;
            _itemFactory = itemFactory;
            _mediator = mediator;
        }

        public async Task<Domain.Items.Item> HandleNewItem(CreateNewItemCommand createNewItemCommand)
        {
            var item = _itemFactory.CreateItemInstance(
                name: new Domain.Items.ValueObjects.Name(createNewItemCommand.Name),
                type: new Domain.Items.ValueObjects.Type(createNewItemCommand.Type)
            );

            var itemCreated = await _itemRepository.Add(item);

            // You may raise an event in case you need to propagate this change to other microservices
            await _mediator.PublishAsync(new ItemCreatedEvent(itemCreated.ItemId.ToGuid(),
                itemCreated.Name.ToString(), itemCreated.Type.ToString(), itemCreated.Expiration.ToDatetime()));

            return itemCreated;
        }

        public async System.Threading.Tasks.Task HandleDeleteItem(DeleteItemCommand deleteItemCommand)
        {
            await _itemRepository.Remove(deleteItemCommand.Id);

            // You may raise an event in case you need to propagate this change to other microservices
            await _mediator.PublishAsync(new ItemDeletedEvent(deleteItemCommand.Id));
        }
    }

}
