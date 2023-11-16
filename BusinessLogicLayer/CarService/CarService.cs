using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfacaces;
using DateAccess.Data;
using DateAccess.Interfaces;
using DateAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BusinessLogicLayer.CarService
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> _carRepo;
        private readonly IRepository<Category> _categoryRepo;        
        private readonly IRepository<Order> _orderRepo;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        public CarService(IRepository<Car> carRepo, IRepository<Category> categoryRepo, IRepository<Order> orderRepo, IMapper mapper, IFileService fileService) 
        {            
            _carRepo = carRepo;
            _categoryRepo= categoryRepo;            
            _orderRepo = orderRepo;
            _mapper = mapper;
            _fileService = fileService;
        }
        public void Create(CarDto carDto)
        {
            //Коли отримуємо файл фото то зберігаємо
            //якщо функція не асинхронна, то треба брати Result. Повертаємо результат виконання 
            //Task що був реалізований асинхронним методом
            string imagePath = _fileService.SaveCarImage(carDto.Image).Result;
            carDto.ImagePath= imagePath;

            var car = _mapper.Map<Car>(carDto);
            _carRepo.Insert(car);
            _carRepo.Save();
        }

        public void Delete(int? id)
        {
            //шукаємо у базі даних
            var car = _carRepo.GetByID(id);

            _fileService.DeleteCarImage(car.ImagePath);

            if (car != null)
            {
                _carRepo.Delete(car);
                _carRepo.Save();
            }
        }

        public void Edit(CarDto carDto)
        {
            //отримати обєкт з серверу за цим Id, який раніше зберігався
            var carOld = Get(carDto.Id);

            if (carOld != null)
            {
                if (carOld.Image != null)
                {
                    //видаляємо старий файл
                    _fileService.DeleteCarImage(carOld.ImagePath);

                    //зберігаємо новий файл
                    string imagePath = _fileService.SaveCarImage(carDto.Image).Result;
                    carDto.ImagePath = imagePath;
                }

                var car = _mapper.Map<Car>(carDto);
                _carRepo.Update(car);
                _carRepo.Save();
            }
        }

        public CarDto? Get(int? id)
        {
            var car = _carRepo.GetByID(id);
            
            return _mapper.Map<CarDto>(car);
        }      

        public List<CarDto> GetAll()
        {
           var car = _carRepo.Get(includeProperties: new[] { "Category" }).ToList();

            return _mapper.Map<List<CarDto>>(car);
        }     
        public List<Category> GetAllCategories()
        {
            return _categoryRepo.Get().ToList();               
        }

        public List<CarDto> TopFiveCar()
        {
            int lastMonth = DateTime.Now.AddMonths(-1).Month;

            List<Order> orders = _orderRepo.Get().
                Where(order => order.OrderDate.Month.Equals(lastMonth)).ToList();


            Dictionary<int, int> carDictionary = new Dictionary<int, int>();

            for (int i = 0; i < orders.Count; i++)
            {
                //перетворюємо string(Json) у список Id в форматі int
                List<int> idcars = JsonSerializer.Deserialize<List<int>>(orders[i].IdCar);

                //Беремо список перетворених id та додаємо їх у словник
                foreach (var idcar in idcars)
                {
                    //якщо ключ з такою Id уже є, то ми збільшуємо кількість проданих машин на 1
                    if (carDictionary.ContainsKey(idcar))
                    {
                        carDictionary[idcar] += 1;                        
                    }
                    else
                    {
                        //якщо машина куплена у замовленні 1 раз, то ми її ініціалізуємо
                        carDictionary.Add(idcar, 1);
                    }
                }
            }

            //сортуємо за кількістю куплених машин
            Dictionary<int, int> topFiveIdCar = carDictionary.OrderBy(carSolt => carSolt.Value).Take(5).ToDictionary(item=>item.Key, item=> item.Value);

            List<CarDto> topCar= new List<CarDto>();

            foreach (var carId in topFiveIdCar)
            {
                CarDto seach = Get(carId.Key);

                topCar.Add(seach);
            }

            return topCar;
        }

     
    } 
}
