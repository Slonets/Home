using AutoMapper;
using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Interfacaces;
using DateAccess.Data;
using DateAccess.Models;
using Garaje.Helper;
using Garaje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Xml.Linq;
using static Garaje.Seeder;
using static NuGet.Packaging.PackagingConstants;

namespace Garaje.Controllers
{
  
    public class HomeController : Controller
    {       
        private readonly ICarService _carService;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public HomeController(ICarService carService, IOrderService orderService, IMapper mapper)
        {            
            _carService= carService;
            _orderService= orderService;
            _mapper= mapper;
        }
        
        public IActionResult Index(int? category_id)
        {
            //List<Category> categories = _context.Categories.ToList();
            List<Category> categories = _carService.GetAllCategories();
            categories.Insert(0, new Category { Id = 0, Name = "All"});
            //виводить на View категорії
            ViewBag.ListCategories = categories;
            //ViewData["ListCategories"] = categories;

            //Показуємо усі категорії автомобілів
            //var cars = _context.Cars.Include(car => car.Category).ToList();
            var allCarDto = _carService.GetAll();

            var cars=_mapper.Map<List<Car>>(allCarDto);

            if (category_id != null && category_id > 0)
            {
                //якщо категорія вибрана, то показуємо авто з тієї категорії
                cars = cars.Where(p => p.CategoryId == category_id).ToList();
            }

            var carsCartViewModel = cars.Select(
                p => new CarCartViewModel
                {
                    Car = p,
                    IsCarChoose = IsCarCart(p.Id)
                }
               ).ToList();


            //Якщо категорія не вибрана, то показуємо усі авто
            if (category_id == null)
            {
                ViewBag.ActiveCategoryId = 0;
            }
            else
            {
                ViewBag.ActiveCategoryId = category_id;
            }


            //Показуємо ТОП 5


            //Витягти з ордер інформацію про машини,
            //підсумувати скільки кожної купили, відсортувати і вибрати перших 5

            List<CarDto> topCar= _carService.TopFiveCar();

            ViewBag.TopFive = topCar;


            return View(carsCartViewModel);
        }

        private bool IsCarCart(int id)
        {
            List<int> idList = HttpContext.Session.GetObject<List<int>>("mycart");

            if (idList == null)
            {
                return false;
            }

            return idList.Contains(id);
        }

        public IActionResult Details(int? id)
        {
            var chose = _carService.Get(id);
            if (chose == null)
            {
                return NotFound();
            }
            return View(chose);
        }

        //за замовчуванням усі методи формуються за методом Get
        public IActionResult Delete(int? id)
        {
            _carService.Delete(id);
            return RedirectToAction(nameof(Index), "Home");            
        }    

        //працює лише відображення даних.
        //Get відрізняється від пост тим, що коли формується запит
        //то Get отримує дані, а Post їх відправляє

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var seach = _carService.Get(id);

            //якщо знайдено, то надсилаємо його на View
            if (seach!=null)
            {
                //передаємо цілий ліст на сторінку Edit, щоб користувач зміг їх вибрати зі списку
                var catigories = _carService.GetAllCategories();
                //як значення передаватиметься на View Id,
                //а Name категорії буде відображатися як value у списку
                ViewBag.ListCategory = new SelectList(catigories, "Id", "Name", seach.CategoryId);
                return View(seach);
            }

            //якщо не знайдено, то помилка
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CarDto carDto)
        {
            if (!ModelState.IsValid)
            {
                var catigories = _carService.GetAllCategories();
                //як значення передаватиметься на View Id,
                //а Name категорії буде відображатися як value у списку
                ViewBag.ListCategory = new SelectList(catigories, "Id", "Name");

                return View(carDto);
            }

            _carService.Edit(carDto);

            //після виправлення переходить на метод індекс контролера
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {           
            //var catigories = _context.Categories.ToList();
            
            var catigories = _carService.GetAllCategories();
            //як значення передаватиметься на View Id,
            //а Name категорії буде відображатися як value у списку
            ViewBag.ListCategory = new SelectList(catigories, "Id", "Name");

             return View();             
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarDto createCarDto)
        {

         if (!ModelState.IsValid)
         {
                //var catigories = _context.Categories.ToList();

                var catigories = _carService.GetAllCategories();
                //як значення передаватиметься на View Id,
                //а Name категорії буде відображатися як value у списку
                ViewBag.ListCategory = new SelectList(catigories, "Id", "Name");                

                return View(createCarDto);
         }            

            _carService.Create(createCarDto);         

         //після виправлення переходить на метод індекс контролера
         return RedirectToAction("Index");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}