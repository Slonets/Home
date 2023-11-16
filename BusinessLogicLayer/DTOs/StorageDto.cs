﻿using DateAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs
{
    public class StorageDto
    {
        public int Id { get; set; }       
        public int CarId { get; set; }
        public Car? Car { get; set; }
    }
}
