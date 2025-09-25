using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P144NLayerApp.DAL.Context;
using P144NLayerApp.DAL.Entity;
using P144NLayerApp.DAL.Interface;

namespace P144NLayerApp.DAL.Impl
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private DbSet<TEntity> _table;

        public GenericRepository(AppDbContext context)
        {
            _table = context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _table.FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }


    }
}
