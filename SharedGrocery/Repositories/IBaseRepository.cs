using System.Collections.Generic;
using SharedGrocery.Models;

namespace SharedGrocery.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : AbstractEntity
    {
        TEntity FindOne(int id);

        ICollection<TEntity> FindAll();

        TEntity Save(TEntity entity);

        void Delete(TEntity entity);
    }
}