using System.Collections.Generic;
using System.Threading.Tasks;
using SharedGrocery.Common.Model;

namespace SharedGrocery.Common.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : AbstractEntity
    {
        TEntity FindOne(int id);

        Task<TEntity> FindOneAsync(int id);

        ICollection<TEntity> FindAll();

        TEntity Save(TEntity entity);

        void Delete(TEntity entity);
    }
}