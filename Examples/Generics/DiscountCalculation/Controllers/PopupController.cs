using System.Web.Mvc;
using bNesis.Examples.DiscountCalculationApp.Models;

namespace bNesis.Examples.DiscountCalculationApp.Controllers
{
    public class PopupController : Controller
    {

        // GET: Popup
        public ActionResult Index(string service)
        {
            ViewBag.Message = service;

            return View("Index", "_Layout_Popup");
        }

        // GET: Popup
        public ActionResult Bnp()
        {
            return View();
        }


        /// <summary>
        /// this method called if facebook authorization complet success
        /// the bNesis API server return bNesisToken to this method (is not Facebook service token, it located at bNesis API Server)
        /// this method do somthing data extraction method to demonstrate how using bNesis SDK API to get user data from Facebook
        /// </summary>
        /// <param name="token">bNesis token</param>
        /// <param name="service">Facebook service name</param>
        /// <returns>Index view to redirect user to index page</returns>
        public ActionResult Facebook(string token, string service, PopupModel recieverModel)
        {
            string resultCode = recieverModel.Facebook(token, service);
            //Faster redirect user to index page
            return RedirectToAction("Index", "Popup", new { service = "Facebook", result = resultCode });
        }

        /// <summary>
        /// this method called if Linkedin authorization complet success
        /// the bNesis API server return bNesisToken to this method (is not Linkedin service token, it located at bNesis API Server)
        /// this method do somthing data extraction method to demonstrate how using bNesis SDK API to get user data from Linkedin
        /// </summary>
        /// <param name="token">bNesis token</param>
        /// <param name="service">Linkedin service name</param>
        /// <param name="recieverModel"></param>
        /// <returns>Index view to redirect user to index page</returns>
        public ActionResult Linkedin(string token, string service, PopupModel recieverModel)
        {
            string resultCode = recieverModel.LinkedIn(token, service);
            //Faster redirect user to index page
            return RedirectToAction("Index", "Popup", new { service = "LinkedIn", result = resultCode });
        }

        /// <summary>
        /// this method called if GoogleDrive authorization complet success
        /// the bNesis API server return bNesisToken to this method (is not GoogleDrive service token, it located at bNesis API Server)
        /// this method do somthing data extraction method to demonstrate how using bNesis SDK API to get user data from GoogleDrive
        /// </summary>
        /// <param name="token">bNesis token</param>
        /// <param name="service">GoogleDrive service name</param>
        /// <returns>Index view to redirect user to index page</returns>
        public ActionResult GoogleDrive(string token, string service, PopupModel recieverModel)
        {
            string resultCode = recieverModel.GoogleDrive(token, service);
            //Faster redirect user to index page
            return RedirectToAction("Index", "Popup", new { service = "GoogleDrive", result = resultCode });
        }

        /// <summary>
        /// this method called if GoogleDrive authorization complet success
        /// the bNesis API server return bNesisToken to this method (is not GoogleDrive service token, it located at bNesis API Server)
        /// this method do somthing data extraction method to demonstrate how using bNesis SDK API to get user data from GoogleDrive
        /// </summary>
        /// <param name="token">bNesis token</param>
        /// <param name="service">Shopify service name</param>
        /// <returns>Index view to redirect user to index page</returns>
        public ActionResult Shopify(string token, string service, PopupModel recieverModel)
        {
            string resultCode = recieverModel.Shopify(token, service);
            //Faster redirect user to index page
            return RedirectToAction("Index", "Popup", new { service = "Shopify", result = resultCode });
        }

        /// <summary>
        /// this method called if GoogleDrive authorization complet success
        /// the bNesis API server return bNesisToken to this method (is not GoogleDrive service token, it located at bNesis API Server)
        /// this method do somthing data extraction method to demonstrate how using bNesis SDK API to get user data from GoogleDrive
        /// </summary>
        /// <param name="token">bNesis token</param>
        /// <param name="service">Box service name</param>
        /// <returns>Index view to redirect user to index page</returns>
        public ActionResult Box(string token, string service, PopupModel recieverModel)
        {
            string resultCode = recieverModel.Box(token, service);
            //Faster redirect user to index page
            return RedirectToAction("Index", "Popup", new { service = "Box", result = resultCode });
        }

        /// <summary>
        /// this method called if GoogleDrive authorization complet success
        /// the bNesis API server return bNesisToken to this method (is not GoogleDrive service token, it located at bNesis API Server)
        /// this method do somthing data extraction method to demonstrate how using bNesis SDK API to get user data from GoogleDrive
        /// </summary>
        /// <param name="token">bNesis token</param>
        /// <param name="service">Box service name</param>
        /// <returns>Index view to redirect user to index page</returns>
        public ActionResult Dropbox(string token, string service, PopupModel recieverModel)
        {
            string resultCode = recieverModel.Dropbox(token, service);
            //Faster redirect user to index page
            return RedirectToAction("Index", "Popup", new { service = "Dropbox", result = resultCode });
        }

        /// <summary>
        /// this method called if GoogleDrive authorization complet success
        /// the bNesis API server return bNesisToken to this method (is not GoogleDrive service token, it located at bNesis API Server)
        /// this method do somthing data extraction method to demonstrate how using bNesis SDK API to get user data from GoogleDrive
        /// </summary>
        /// <param name="token">bNesis token</param>
        /// <param name="service">VKontakte service name</param>
        /// <returns>Index view to redirect user to index page</returns>
        public ActionResult VKontakte(string token, string service, PopupModel recieverModel)
        {
            string resultCode = recieverModel.VKontakte(token, service);
            //Faster redirect user to index page
            return RedirectToAction("Index", "Popup", new { service = "VKontakte", result = resultCode });
        }


        /// <summary>
        /// this method called if GoogleDrive authorization complet success
        /// the bNesis API server return bNesisToken to this method (is not GoogleDrive service token, it located at bNesis API Server)
        /// this method do somthing data extraction method to demonstrate how using bNesis SDK API to get user data from GoogleDrive
        /// </summary>
        /// <param name="token">bNesis token</param>
        /// <param name="service">PayPal service name</param>
        /// <returns>Index view to redirect user to index page</returns>
        public ActionResult PayPal(string token, string service, PopupModel recieverModel)
        {
            string resultCode = recieverModel.PayPal(token, service);
            //Faster redirect user to index page
            return RedirectToAction("Index", "Popup", new { service = "PayPal", result = resultCode });
        }

        /// <summary>
        /// this method called if GoogleDrive authorization complet success
        /// the bNesis API server return bNesisToken to this method (is not GoogleDrive service token, it located at bNesis API Server)
        /// this method do somthing data extraction method to demonstrate how using bNesis SDK API to get user data from GoogleDrive
        /// </summary>
        /// <param name="token">bNesis token</param>
        /// <param name="service">Stripe service name</param>
        /// <returns>Index view to redirect user to index page</returns>
        public ActionResult Stripe(string token, string service, PopupModel recieverModel)
        {
            string resultCode = recieverModel.Stripe(token, service);
            //Faster redirect user to index page
            return RedirectToAction("Index", "Popup", new { service = "Stripe", result = resultCode });
        }

        /// <summary>
        /// this method called if GoogleDrive authorization complet success
        /// the bNesis API server return bNesisToken to this method (is not GoogleDrive service token, it located at bNesis API Server)
        /// this method do somthing data extraction method to demonstrate how using bNesis SDK API to get user data from GoogleDrive
        /// </summary>
        /// <param name="token">bNesis token</param>
        /// <param name="service">BaiduBCS service name</param>
        /// <returns>Index view to redirect user to index page</returns>
        public ActionResult BaiduBCS(string token, string service, PopupModel recieverModel)
        {
            string resultCode = recieverModel.BaiduBCS(token, service);
            //Faster redirect user to index page
            return RedirectToAction("Index", "Popup", new { service = "BaiduBCS", result = resultCode });
        }

        /// <summary>
        /// this method called if GoogleDrive authorization complet success
        /// the bNesis API server return bNesisToken to this method (is not GoogleDrive service token, it located at bNesis API Server)
        /// this method do somthing data extraction method to demonstrate how using bNesis SDK API to get user data from GoogleDrive
        /// </summary>
        /// <param name="token">bNesis token</param>
        /// <param name="service">BaiduBCS service name</param>
        /// <returns>Index view to redirect user to index page</returns>
        public ActionResult LiqPay(string token, string service, PopupModel recieverModel)
        {
            string resultCode = recieverModel.LiqPay(token, service);
            //Faster redirect user to index page
            return RedirectToAction("Index", "Popup", new { service = "LiqPay", result = resultCode });
        }

        /// <summary>
        /// this method called if GoogleDrive authorization complet success
        /// the bNesis API server return bNesisToken to this method (is not GoogleDrive service token, it located at bNesis API Server)
        /// this method do somthing data extraction method to demonstrate how using bNesis SDK API to get user data from GoogleDrive
        /// </summary>
        /// <param name="token">bNesis token</param>
        /// <param name="service">PrestaShop service name</param>
        /// <returns>Index view to redirect user to index page</returns>
        public ActionResult PrestaShop(string token, string service, PopupModel recieverModel)
        {
            string resultCode = recieverModel.PrestaShop(token, service);
            //Faster redirect user to index page
            return RedirectToAction("Index", "Popup", new { service = "PrestaShop", result = resultCode });
        }


        /// <summary>
        /// this method called if GoogleDrive authorization complet success
        /// the bNesis API server return bNesisToken to this method (is not GoogleDrive service token, it located at bNesis API Server)
        /// this method do somthing data extraction method to demonstrate how using bNesis SDK API to get user data from GoogleDrive
        /// </summary>
        /// <param name="token">bNesis token</param>
        /// <param name="service">GooglePlus service name</param>
        /// <returns>Index view to redirect user to index page</returns>
        public ActionResult GooglePlus(string token, string service, PopupModel recieverModel)
        {
             string resultCode = recieverModel.GooglePlus(token, service);
            //Faster redirect user to index page
            return RedirectToAction("Index", "Popup", new { service = "GooglePlus", result = resultCode });
        }

        //        /// <summary>
        //        /// this method called if GooglePlus authorization complet success
        //        /// the bNesis API server return bNesisToken to this method (is not GooglePlus service token, it located at bNesis API Server)
        //        /// this method do somthing data extraction method to demonstrate how using bNesis SDK API to get user data from GooglePlus
        //        /// </summary>
        //        /// <param name="token">bNesis token</param>
        //        /// <param name="service">GooglePlus service name</param>
        //        /// <returns>Index view to redirect user to index page</returns>
        //        public ActionResult GooglePlus(string token, string service, PopupModel recieverModel)
        //        {
        //            string resultCode = recieverModel.GooglePlus(token, service);
        //            //Faster redirect user to index page
        //            return RedirectToAction("Index", "Popup", new { service = "GooglePlus", result = resultCode });
        //        }
    }
}