using BusinessLogicLayer.Interfacaces;
using DateAccess.Models;
using Microsoft.EntityFrameworkCore;
using Garaje.Helper;
using BusinessLogicLayer.DTOs;

namespace Garaje.ServiceCart
{
    public class CartService : ICartService
    {
        //HttpContent
        //HttpContext

        private readonly HttpContext? _httpContext;        
        private readonly ICarService _carService;

        //конструктор щоб доступитися до Http
        public CartService(IHttpContextAccessor httpContextAccessor, ICarService carService) 
        {
            _httpContext = httpContextAccessor.HttpContext;            
            _carService = carService;
        }

        public IEnumerable<CarDto> GetAllCart()
        {
            List<int> listId = _httpContext.Session.GetObject<List<int>>("mycart");

            if (listId == null)
            {
                listId = new List<int>();
            }

            //вибірка обєктів Car лише тих, що відповідають id вибраних.           
            List<CarDto> cars = listId.Select(id => _carService.Get(id)).ToList();

            return cars;
        }

        public void Add(int id)
        {
            if (_carService.Get(id) == null)
            {
                return;
            }
            //Дивимося, що уже додано в корзину
            List<int>? idList = _httpContext.Session.GetObject<List<int>>("mycart");

            //Якщо корзина порожня, то створюємо
            if (idList == null)
            {
                idList = new List<int>();
            }

            //Додаємо в корзину вибрану Id
            idList.Add(id);

            _httpContext.Session.SetObject<List<int>>("mycart", idList);
        }   

        public void Remove(int id)
        {
            if (_carService.Get(id) == null)
            {
                return;
            }

            List<int>? idsList = _httpContext.Session.GetObject<List<int>>("mycart");

            if (idsList == null)
            {
                idsList = new List<int>();
            }

            idsList.Remove(id); //delete id of product to cart
            _httpContext.Session.SetObject<List<int>>("mycart", idsList);
        }
    }
}
