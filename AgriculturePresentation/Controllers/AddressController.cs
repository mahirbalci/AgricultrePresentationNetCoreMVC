using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            var result = _addressService.GetListAll();
            return View(result);
        }



        [HttpGet]
        public IActionResult UpdateAddress(int id)
        {
            var result = _addressService.GetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateAddress(Address address)
        {
            _addressService.Update(address);
            return RedirectToAction("Index");

        }



    }
}
