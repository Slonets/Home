﻿using BusinessLogicLayer.DTOs;
using DateAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfacaces
{
    public interface IStorageService
    {
        IEnumerable<StorageDto> GetAllStorage();        
    }
}
