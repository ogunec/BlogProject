using Microsoft.AspNetCore.Mvc;

namespace BlogPro.UI.Controllers
{
	public class ErrorController : Controller
	{
		public IActionResult Page404()
		{
			return View();
		}
	}
}
