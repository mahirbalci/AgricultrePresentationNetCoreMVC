using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _MapPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			AgricultureContext context = new AgricultureContext();
			var result = context.Adresses.Select(x => x.MapInfo).FirstOrDefault();
			ViewBag.v = result;
			return View();
		}
	}
}
