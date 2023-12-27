using Microsoft.AspNetCore.Mvc;

namespace HastaneProjesi.Controllers
{
	public class DefaultController : Controller
	{
		public PartialViewResult Partial1()
		{
			return PartialView();
		}
	}
}
