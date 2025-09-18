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
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Product createEntity)
        {
            await _context.Products.AddAsync(createEntity);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetById(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }
    }
}
