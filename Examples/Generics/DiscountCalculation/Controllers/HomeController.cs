using System.Web.Mvc;
using bNesis.Examples.DiscountCalculationApp.DAL;
using Newtonsoft.Json;

namespace bNesis.Examples.DiscountCalculationApp.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// return example index page view
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// return page view about this example
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "About bNesis discount calculation example";

            return View();
        }

        /// <summary>
        /// contact page view
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "bNesis contact";

            return View();
        }

        /// <summary>
        /// contact page view
        /// </summary>
        /// <returns></returns>
        public ActionResult Services()
        {
            ViewBag.Message = "bNesis contact";

            return View();
        }

        /// <summary>
        /// contact page view
        /// </summary>
        /// <returns></returns>
        public ActionResult LoanType(string type)
        {
            ViewBag.Type = type;

            return View();
        }

        /// <summary>
        /// contact page view
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowData(string code)
        {
            if (code != "demo")
            {
                return RedirectToAction("Index", "Home");
            }
            
            ViewBag.Responses = JsonConvert.SerializeObject(Repository.Instance.GetApiResponses().Result);

            return View();
        }

        /// <summary>
        /// contact page view
        /// </summary>
        /// <returns></returns>
        public ActionResult Done()
        {
            return View();
        }

    }
}