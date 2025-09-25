using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P144NLayerApp.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository{ get; }
        Task Save();
    }
}
