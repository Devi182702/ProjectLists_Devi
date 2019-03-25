using System.Web.Mvc;

namespace MVCMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View();
        }

        public string Welcome()
        {
            return "this is from Welcome Hellowrold";
        }
    }
}