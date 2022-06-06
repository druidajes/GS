using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goal.Domain
{
    public interface IRepository<TEntity>
        where TEntity : IAggregateRoot
    {
        Task<TEntity> FindById(Guid id);
        Task<List<TEntity>> FindAll();
        Task<TEntity> Add(TEntity entity);
        Task Remove(Guid id);
    }
}
