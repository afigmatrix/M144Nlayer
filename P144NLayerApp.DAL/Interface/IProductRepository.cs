using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P144NLayerApp.DAL.Entity;

namespace P144NLayerApp.DAL.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task Create(Product createEntity);
        Task Save();
        Task<Product> GetById(int id);
    }
}
