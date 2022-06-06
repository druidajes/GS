using Goal.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Application.Services
{
    public interface IItemService
    {
        Task<IEnumerable<ItemViewModel>> GetAll();
        Task<ItemViewModel> GetById(Guid id);
        Task<ItemViewModel> Create(ItemViewModel taskViewModel);
        Task Delete(Guid id);
    }
}
