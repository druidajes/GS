using Goal.Application.ViewModels;
using Goal.Domain.Items;
using Goal.Domain.Items.Commands;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Application.Mappers
{
    public class ItemViewModelMapper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ItemViewModelMapper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<ItemViewModel> ConstructFromListOfEntities(IEnumerable<Item> items)
        {
            var itemsViewModel = items.Select(i => new ItemViewModel
            {
                Id = i.ItemId.ToGuid().ToString(),
                Name = i.Name.ToString(),
                Type = i.Type.ToString(),
                Expiration = i.Expiration.ToDatetime()
            }
            );

            return itemsViewModel;
        }

        public ItemViewModel ConstructFromEntity(Item item)
        {
            return new ItemViewModel
            {
                Id = item.ItemId.ToGuid().ToString(),
                Name = item.Name.ToString(),
                Type = item.Type.ToString(),
                Expiration = item.Expiration.ToDatetime()

            };
        }

        public CreateNewItemCommand ConvertToNewItemCommand(ItemViewModel itemViewModel)
        {
            return new CreateNewItemCommand(itemViewModel.Name, itemViewModel.Type);
        }

        public DeleteItemCommand ConvertToDeleteItemCommand(Guid id)
        {
            return new DeleteItemCommand(id);
        }
    }

}
