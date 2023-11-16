using BusinessLogicLayer.Interfacaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.CarService
{
    public class FileService : IFileService
    {
        //наша папка, де знайхлдяться усі фотографії
        private const string imageFolder = "Images";

        //поле для доступу до папки
        private readonly IWebHostEnvironment _enviroment;

        public FileService(IWebHostEnvironment enviroment)
        {
            _enviroment = enviroment;
        }

        public async Task DeleteCarImage(string imagePath)
        {
            string root = _enviroment.WebRootPath;

            var oldFile = Path.Combine(root, imagePath);
            
            if (File.Exists(oldFile) && !imagePath.Contains("NoImage.jpg"))
            {
                File.Delete(oldFile);
            }
        }

        public async Task<string> SaveCarImage(IFormFile file)
        {
           //рядок доступу до реальної паки Images у root
           string root = _enviroment.WebRootPath;

           //генерує рандомне імя файлу
           string newNameFile= Guid.NewGuid().ToString();

           //витягаємо з імя файлу його тип .jpg  .png
           string extansionFile = Path.GetExtension(file.FileName);

            //створюємо імя фото яке буде зберігатися
            string fullFileName = newNameFile + extansionFile;

            //формуємо імя файлу для бази даних
            string imagePath= Path.Combine(imageFolder, fullFileName);

            //тепер формуємо повну адресу до попки у базі даних
            string imageFullPath = Path.Combine(root, imagePath);

            //створюємо і зберігаємо у базі даних
            //Create якщо файл уже існує, то він його перезапише
            //CreateNew якщо файл уже такий є то буде давати помилку
            using (FileStream fileStream=new FileStream(imageFullPath, FileMode.Create))
            {
                //асинхронне копіювання файлу до визначеного потоку imageFullPath
                await file.CopyToAsync(fileStream);
            }

            return fullFileName ?? "NoImage.jpg";
        }        
    }
}
