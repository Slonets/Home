using BusinessLogicLayer.DTOs;
using DateAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfacaces
{
    public interface ICarService
    {
        List<Category> GetAllCategories();
        List<CarDto> GetAll();
        CarDto? Get(int? id);
        void Create(CarDto carDto);
        void Edit(CarDto carDto);
        void Delete(int? id);
        List<CarDto> TopFiveCar();
    }

}
