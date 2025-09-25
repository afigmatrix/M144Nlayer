using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P144NLayerApp.DAL.Context;
using P144NLayerApp.DAL.Entity;
using P144NLayerApp.DAL.Interface;

namespace P144NLayerApp.DAL.Impl
{
    public class CategoryRepository : GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
