using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace AgriculturePresentation.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            var result = _announcementService.GetListAll();
            return View(result);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(Announcement announcement)
        {
            announcement.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            announcement.Status = false;
            _announcementService.Insert(announcement);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAnnouncement(int id)
        {
           var result = _announcementService.GetById(id);
            _announcementService.Delete(result);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var result = _announcementService.GetById(id);
            return View(result);
            
        }

        [HttpPost]
        public IActionResult UpdateAnnouncement(Announcement announcement)
        {
            _announcementService.Update(announcement);
            return RedirectToAction("Index");

        }
        

        public IActionResult ChangeStatusToTrue(int id)
        {
            _announcementService.AnnouncementStatusToTrue(id);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusToFalse(int id)
        {
            _announcementService.AnnouncementStatusToFalse(id);
            return RedirectToAction("Index");
        }

    }
}
