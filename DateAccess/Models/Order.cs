using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAccess.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string IdCar { get; set; } = string.Empty;
       
        public int? TotalPrice { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
