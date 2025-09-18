using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P144NLayerApp.BusinessLayer.DTO;

namespace P144NLayerApp.BusinessLayer.Interface
{
    public interface IProductService
    {
        Task<List<ProductGetAllDto>> GetAll();
        Task Create(ProductPostDto product,string rootPath);
        Task<byte[]> GetFileById(int id,string root);
    }
}
