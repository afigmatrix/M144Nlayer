using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using P144NLayerApp.BusinessLayer.DTO;
using P144NLayerApp.BusinessLayer.Interface;
using P144NLayerApp.DAL.Entity;
using P144NLayerApp.DAL.Interface;

namespace P144NLayerApp.BusinessLayer.Impl
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memory;

        public ProductService(IProductRepository productRepository, IMapper mapper, IMemoryCache memory)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _memory = memory;
        }

        public async Task Create(ProductPostDto product, string rootPath)
        {
            var fileImage = product.Image;
            var fileName = Guid.NewGuid().ToString() + fileImage.FileName;
            var folderPath = Path.Combine("Images", fileName);
            var fullPath = Path.Combine(rootPath, folderPath);
            using (var fs = new FileStream(fullPath, FileMode.Create))
            {
                await fileImage.CopyToAsync(fs);
            }

            var productEntity = new Product()
            {
                Name = product.Name,
                isActive = product.isActive,
                ImagePath = folderPath
            };

            await _productRepository.Create(productEntity);
            await _productRepository.Save();


        }

        public async Task<List<ProductGetAllDto>> GetAll()
        {
            var cacheName = "productList";

            if (!_memory.TryGetValue(cacheName, out List<Product> productEntityList))
            {
                Thread.Sleep(4000);
                productEntityList = await _productRepository.GetAll();
                _memory.Set(cacheName, productEntityList, TimeSpan.FromMinutes(1));
            }

         //   var data = (List<Product>)_memory.Get(cacheName);
            var response = _mapper.Map<List<ProductGetAllDto>>(productEntityList);
            throw new NullReferenceException("User data is null!");
            return response;
        }

        public async Task<byte[]> GetFileById(int id, string root)
        {
            var product = await _productRepository.GetById(id);
            if (product is null)
            {
                throw new Exception("Product Not Found");
            }

            var filePath = Path.Combine(root, product.ImagePath);
            var fileByte = await File.ReadAllBytesAsync(filePath);
            // var base64 = Convert.ToBase64String(fileByte);
            return fileByte;

        }
    }
}
