using AgriculturePresentation.Models;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService= serviceService; 
        }
        public IActionResult Index()
        {
           var result= _serviceService.GetListAll();
            return View(result);
        }

        [HttpGet]
        public IActionResult AddService()
        {

            return View(new ServiceAddViewModel());
        }

        [HttpPost]
        public IActionResult AddService(ServiceAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _serviceService.Insert(new Service
                {
                    Title = model.Title,
                    Description = model.Description,
                    Image = model.Image

                });
                return RedirectToAction("Index");
            }
            return View(model);
            
        }

        public IActionResult DeleteService(int id)
        {
            var value = _serviceService.GetById(id);
            _serviceService.Delete(value);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var result = _serviceService.GetById(id);
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
             _serviceService.Update(service);
            return RedirectToAction("Index");
        }

        public IActionResult Deneme()
        {
            return View();
        }

    }
}
