using BusinessLogicLayer.Interfacaces;
using DateAccess.Data;
using DateAccess.Models;
using Garaje.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Garaje.Controllers
{
    [Authorize]
    
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {           
            _cartService = cartService;
        }

        //дозволяє бачити цю функцію без регістрації
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_cartService.GetAllCart());
        }

        //[Authorize(Roles = "User,Admin")]
        public IActionResult Add(int id)
        {
            _cartService.Add(id);
            return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult Remove(int id)
        {
            _cartService.Remove(id);
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
