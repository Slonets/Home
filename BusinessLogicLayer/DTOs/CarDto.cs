using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class CarDto
    {
        public int Id { get; set; }
        public string? ModelCar { get; set; }
        public string? ColorCar { get; set; }
        public int? Price { get; set; }
        public string? Discription { get; set; }
        public string? ImagePath { get; set; }

        public IFormFile Image { get; set; }
        public int? Quantity { get; set; }

        public int CategoryId { get; set; }
    }
}
