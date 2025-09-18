using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using P144NLayerApp.BusinessLayer.Impl;
using P144NLayerApp.BusinessLayer.Interface;

namespace P144NLayerApp.BusinessLayer
{
    public static class BusinessLayerServiceInjection
    {
        public static void InjectBusinessLayer(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddScoped<IProductService, ProductService>();
        }
    }
}
