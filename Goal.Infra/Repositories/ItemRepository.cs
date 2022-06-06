using Goal.Domain.Items;
using Goal.Domain.Items.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Infra.Repositories
{
    /*
    * Repository: Mediates between the domain and data mapping layers 
    * using a collection-like interface for accessing domain objects. 
    * https://martinfowler.com/eaaCatalog/repository.html
    * 
    * This is the implementation for IItemRepository which needs to
    * implement the generic IRepository actions. 
    * Both are located in Domain layer given that they are interfaces
    * attached to Item domain (these interfaces are called ports in
    * hexagonal architecture and the implementation in this class is
    * called adapter)
    * 
    * With this architecture pattern your data access code can be changed
    * easily only performing the changes in this class. 
    * You may want to use a MongoDB, SQL or whatever, you just need to 
    * change it here.
    */

    public class ItemRepository : IItemRepository
    {
        private readonly IItemFactory _itemFactory;

        public ItemRepository(IItemFactory itemFactory)
        {
            _itemFactory = itemFactory;
        }

        public Task<Item> Add(Item itemEntity)
        {
            return Task.FromResult(
                _itemFactory.CreateItemInstance(new Name("name test"), new Domain.Items.ValueObjects.Type("type test")));
        }

        public Task<List<Item>> FindAll()
        {
            var tasks = System.Threading.Tasks.Task.FromResult(new List<Item> {
                _itemFactory.CreateItemInstance(new Name("name test"), new Domain.Items.ValueObjects.Type("type test"))});

            return tasks;
        }

        public Task<Item> FindById(Guid id)
        {
            return Task.FromResult(
                _itemFactory.CreateItemInstance(new Name("name test"), new Domain.Items.ValueObjects.Type("type test")));
        }

        public Task Remove(Guid id)
        {
            return Task.CompletedTask;
        }
    }
}
