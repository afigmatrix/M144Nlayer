using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using P144NLayerApp.BusinessLayer.DTO;
using P144NLayerApp.DAL.Entity;

namespace P144NLayerApp.BusinessLayer.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductGetAllDto>().ReverseMap();
        }
    }
}
