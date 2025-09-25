using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P144NLayerApp.DAL.Context;
using P144NLayerApp.DAL.Interface;

namespace P144NLayerApp.DAL.Impl
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }

        public UnitOfWork(AppDbContext context, 
            IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _context = context;
            CategoryRepository = categoryRepository;
            ProductRepository = productRepository;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(true);
        }
    }
}
