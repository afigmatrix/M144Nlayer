using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P144NLayerApp.DAL.Entity;

namespace P144NLayerApp.DAL.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
