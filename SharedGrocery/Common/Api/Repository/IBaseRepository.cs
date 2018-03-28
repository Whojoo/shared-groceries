using System.Collections.Generic;
using System.Threading.Tasks;
using SharedGrocery.Common.Model;

namespace SharedGrocery.Common.Api.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : AbstractEntity
    {
        /// <summary>
        /// Find an entity by id.
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity or null of none was found</returns>
        TEntity FindOne(int id);

        /// <summary>
        /// Find an entity by id.
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity or null of none was found</returns>
        Task<TEntity> FindOneAsync(int id);

        /// <summary>
        /// Find all entities.
        /// </summary>
        /// <returns>All entities</returns>
        ICollection<TEntity> FindAll();

        /// <summary>
        /// Save or update an entity.
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Saved entity</returns>
        TEntity Save(TEntity entity);

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        void Delete(TEntity entity);
    }
}