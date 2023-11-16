using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfacaces;
using DateAccess.Data;
using DateAccess.Interfaces;
using DateAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLogicLayer.CarService
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Car> _carRepo;
        private readonly IRepository<Order> _orderRepo;
        private readonly IRepository<Storage> _storageRepo;
        private readonly IMapper _mapper;
        public OrderService(IRepository<Car> carRepo, IRepository<Order> orderRepo, IRepository<Storage> storageRepo, IMapper mapper)
        {
            _carRepo = carRepo;            
            _orderRepo = orderRepo;
            _storageRepo = storageRepo;
            _mapper = mapper;
        }

        public void Create(string userId, List<int> idList)
        {           
            List<Car> cars = idList.Select(id => _carRepo.GetByID(id)).ToList();
            

            Order newOrder = new Order()
            {
                OrderDate = DateTime.Now,
                IdCar = JsonSerializer.Serialize(idList),
                //рахуємо загальну суму вибраного
                TotalPrice = cars.Sum(x => x.Price),
                UserId = userId
            };

            // в idList айдішки машин
            for (int i = 0; i < idList.Count; i++)
            {
                ShangeQuantityOfCar(idList[i]);
            }

            _orderRepo.Insert(newOrder);
            _orderRepo.Save();
        }

        public IEnumerable<OrderDto> GetAll(string userId)
        {
            var ordeAll = _orderRepo.Get().Where(x => x.UserId == userId).ToList();

            return _mapper.Map<List<OrderDto>>(ordeAll);                     
        }

        public void ShangeQuantityOfCar(int Carid)
        {
           List<Car> ollcar = _carRepo.Get().ToList();

            Car seach = ollcar.FirstOrDefault(x => x.Id == Carid);

            if (seach != null)
            {
                seach.Quantity--;
            }

            //оновлює дані таблиці
            _carRepo.Update(seach);
            _carRepo.Save();
        }

    }
}
