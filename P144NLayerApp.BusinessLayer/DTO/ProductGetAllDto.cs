using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P144NLayerApp.BusinessLayer.DTO
{
    public class ProductGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
        public string ImagePath { get; set; }
    }
}
