using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using P144NLayerApp.DAL.Context;
using P144NLayerApp.DAL.Impl;
using P144NLayerApp.DAL.Interface;

namespace P144NLayerApp.DAL
{
    public static class DALServiceInjection //static , this
    {
        public static void InjectDAL(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Data Source=AFIQ;Initial Catalog=M144NLayer;Integrated Security=true;Trusted_Connection=true;TrustServerCertificate=true;");
            });

            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
