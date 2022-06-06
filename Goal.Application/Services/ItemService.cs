using FluentMediator;
using Goal.Application.Mappers;
using Goal.Application.ViewModels;
using Goal.Domain.Items;
using OpenTracing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IItemFactory _itemFactory;
        private readonly ItemViewModelMapper _itemViewModelMapper;
        private readonly ITracer _tracer;
        private readonly IMediator _mediator;

        public ItemService(IItemRepository itemRepository, ItemViewModelMapper itemViewModelMapper, ITracer tracer, IItemFactory itemFactory, IMediator mediator)
        {
            _itemRepository = itemRepository;
            _itemViewModelMapper = itemViewModelMapper;
            _tracer = tracer;
            _itemFactory = itemFactory;
            _mediator = mediator;
        }

        public async Task<ItemViewModel> Create(ItemViewModel itemViewModel)
        {
            using (var scope = _tracer.BuildSpan("Create_ItemService").StartActive(true))
            {
                var newItemCommand = _itemViewModelMapper.ConvertToNewItemCommand(itemViewModel);

                var itemResult = await _mediator.SendAsync<Item>(newItemCommand);

                return _itemViewModelMapper.ConstructFromEntity(itemResult);
            }
        }

        public async Task Delete(Guid id)
        {
            using (var scope = _tracer.BuildSpan("Delete_ItemService").StartActive(true))
            {
                var deleteItemCommand = _itemViewModelMapper.ConvertToDeleteItemCommand(id);
                await _mediator.PublishAsync(deleteItemCommand);
            }
        }

        public async Task<IEnumerable<ItemViewModel>> GetAll()
        {
            using (var scope = _tracer.BuildSpan("GetAll_ItemService").StartActive(true))
            {
                var itemsEntities = await _itemRepository.FindAll();

                return _itemViewModelMapper.ConstructFromListOfEntities(itemsEntities);
            }
        }

        public async Task<ItemViewModel> GetById(Guid id)
        {
            using (var scope = _tracer.BuildSpan("GetById_ItemService").StartActive(true))
            {
                var itemEntity = await _itemRepository.FindById(id);

                return _itemViewModelMapper.ConstructFromEntity(itemEntity);
            }
        }
    }

}
