using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var result = _contactService.GetListAll();
            return View(result);
        }

        public IActionResult DeleteContact(int id)
        {
            var result = _contactService.GetById(id);
            _contactService.Delete(result);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult MessageDetails(int id) 
        {
            var result = _contactService.GetById(id);
            return View(result);
        }

  

       
    }
}
