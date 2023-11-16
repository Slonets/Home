using DateAccess.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAccess.Models
{
    [EntityTypeConfiguration(typeof(CarConfiguration))]
    public class Car
    {
        public int Id { get; set; }
        public string? ModelCar { get; set; }
        public string? ColorCar { get; set; }
        public int? Price { get; set; }
        public string? Discription { get; set; }
        public string? ImagePath { get; set; }
        public int? Quantity { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Storage>? Storage { get; }      
    }
}
