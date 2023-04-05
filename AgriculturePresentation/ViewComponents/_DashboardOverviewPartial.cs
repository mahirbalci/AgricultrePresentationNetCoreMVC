using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardOverviewPartial:ViewComponent
    {
        AgricultureContext context = new AgricultureContext();
        public IViewComponentResult Invoke()
        {
            
            ViewBag.teamCount = context.Teams.Count();
            ViewBag.serviceCount = context.Services.Count();
            ViewBag.messageCount = context.Contacts.Count();
            ViewBag.currentMonthMessage = context.Contacts.Where(x => x.Date.Month == DateTime.Now.Month).Count();
            ViewBag.announcementTrue = context.Announcements.Where(x => x.Status == true).Count();
            ViewBag.announcementFalse = context.Announcements.Where(x => x.Status == false).Count();

            ViewBag.urunPazarlama = context.Teams.Where(x => x.Title == "Web geliştirici").Select(y => y.PersonName).FirstOrDefault();
            ViewBag.bakliyatYonetimi = context.Teams.Where(x => x.Title == " yazılım geliştirici .net c#").Select(y => y.PersonName).FirstOrDefault();
            return View();
        }
    }
}
