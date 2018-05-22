using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> Create(TEntity entity);

        Task<TEntity> Update(TEntity entity);

        Task<TEntity> Delete(TEntity entity);

        Task<TEntity> Get(int id);

        Task<List<TEntity>> All();       
    }
}
