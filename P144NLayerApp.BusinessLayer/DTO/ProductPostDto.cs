using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P144NLayerApp.BusinessLayer.DTO
{
    public class ProductPostDto
    {
        public string Name { get; set; }
        public bool isActive { get; set; }
        public IFormFile Image { get; set; }

        public override string ToString()
        {
            return "Name = " + Name;
        }

        override 
    }
}
