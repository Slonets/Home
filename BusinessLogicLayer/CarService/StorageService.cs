using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfacaces;
using DateAccess.Data;
using DateAccess.Interfaces;
using DateAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.CarService
{
    public class StorageService : IStorageService
    {
        private readonly IRepository<Storage> _storageRepo;
        private readonly IMapper _mapper;

        public StorageService(IRepository<Storage> storageRepo, IMapper mapper) 
        {
            _storageRepo=storageRepo;
            _mapper=mapper;
        }

        //OrderBy сортує машини у гаражі за зростанням у ціні. Від найменшого до більшого 
        //OrderByDescending сортує машини у гаражі від більшого до меншого у ціні
        public IEnumerable<StorageDto> GetAllStorage()
        {
            var Allstorage= _storageRepo.Get(orderBy: x => x.OrderBy(car => car.Car.Price), includeProperties: new[] { "Car" }).ToList();

            return _mapper.Map<List<StorageDto>>(Allstorage);
        }      

    }
}
