using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAccess.Models
{
    public class Storage
    {
        public int Id { get; set; }        

        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car? Car { get; set; }
    }
}
