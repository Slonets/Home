using AutoMapper;
using BusinessLogicLayer.DTOs;
using DateAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Helpers
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Car,CarDto>()
                .ForMember(carDto=> carDto.Image, opt=>opt.Ignore()) //коли перетворюємо Car,CarDto то поле Image ігнорується               
                .ReverseMap();

            CreateMap<Storage, StorageDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
