using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejercicios.Controllers
{
    public class HomeController : Controller
    {
        //Pasasmos el parametro asi localhost:52103/Home/index/Jaime localhost:52103/Home/index/?nombre=Jaime&saludo=Felicidades
        /* public String Index(string nombre, string saludo)
        {
            return "Feliz Año 2017 " + nombre + " - " + saludo;
        }*/

        public ActionResult Index()
        {
            ViewBag.Paises = new List<string>()
            {
                "España",
                "India",
                "Estados Unidos",
                "Francia"
            };
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}