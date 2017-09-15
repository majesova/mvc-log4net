using AppFramework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMvc.Controllers
{
    public class HomeController : Controller
    {
        ILogger logger = new LoggerFileImplementation();
        public HomeController()
        {
            //inicializar en el constructor
            logger.EnsureInitialized();
        }

        public ActionResult Index()
        {
            //Un info
            logger.Info(this, "Este es un info de Index iniciado");
            //tiene sobrecargas
            logger.Info(this.GetType(), "Esta es otra info");
            logger.Info(this.GetType(), "Otra info con exception", new Exception("Ah nu ma"));

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            try
            {
                int zero = 0;
                int i = 1 / zero;
            }
            catch (Exception ex) {
                //Un error no controlado
                logger.Error(this, ex);
            }

            return View();
        }

        public ActionResult Contact()
        {
            //Se esaa misma orma chambean Warn y Fatal.
            logger.Warn(this, "WARNING");
            return View();
        }
    }
}