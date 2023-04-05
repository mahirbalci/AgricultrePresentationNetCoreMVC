using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _ImagePartial:ViewComponent

	{
		private readonly IImageService _imageService;
		public _ImagePartial(IImageService imageService)
		{
				_imageService=imageService;
		}
		public IViewComponentResult Invoke()
		{
			var result = _imageService.GetListAll();
			return View(result);
		}

	}
}
