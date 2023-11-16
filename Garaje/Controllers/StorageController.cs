using BusinessLogicLayer.Interfacaces;
using BusinessLogicLayer.CarService;
using Microsoft.AspNetCore.Mvc;

namespace Garaje.Controllers
{
    public class StorageController : Controller
    {
        private readonly IStorageService _storageService;

        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public IActionResult Index()
        {
            var storage = _storageService.GetAllStorage();

            return View(storage);
        }
    }
}
