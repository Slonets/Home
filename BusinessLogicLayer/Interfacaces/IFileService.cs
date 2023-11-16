using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfacaces
{
    public interface IFileService
    {
        //одночасно завантажує файл і повертає рядок імя файлу
        Task<string> SaveCarImage(IFormFile file);
        Task DeleteCarImage(string imagePath);        
    }
}
