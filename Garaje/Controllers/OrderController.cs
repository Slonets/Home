using BusinessLogicLayer.CarService;
using BusinessLogicLayer.Interfacaces;
using DateAccess.Data;
using DateAccess.Models;
using Garaje.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;

namespace Garaje.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService) 
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            string userId=User.FindFirstValue(ClaimTypes.NameIdentifier);

            var orders = _orderService.GetAll(userId);

            return View(orders);
        }

        public IActionResult CreateOrder()
        {
            //витагуємо авторизованого на сайті користувача за допомогою команди User
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<int> idList = HttpContext.Session.GetObject<List<int>>("mycart");

            _orderService.Create(userId, idList);

            //очищаємо сесію. Тобто усі дії користувача на сторінці
            HttpContext.Session.Remove("mycart");

            return RedirectToAction(nameof(Index));
        }
    }
}
