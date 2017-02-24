using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ejercicio5.Models;
using System.Text;

namespace Ejercicio5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Cargar dropdownList desde base de datos por medio de una ViewBag
        public ActionResult Index2()
        {
            EjemploDBContext db = new EjemploDBContext();
            ViewBag.departamentos = new SelectList(db.Departamento, "DepartamentoId", "NomDepartamento");
            return View();
        }

        [HttpGet]
        public ActionResult Index3()
        {
            Compania compania = new Compania();
            return View(compania);
        }


        [HttpPost]
        public String Index3(Compania compania)
        {
            if (string.IsNullOrEmpty(compania.deptSeleccionado))
            {
                return "No has seleccionado ningun depratamento";
            }
            else
            {
                return "Has seleccionado el departamento con id: "+compania.deptSeleccionado;
            }
        }

        [HttpGet]
        public ActionResult Index4()
        {
            EjemploDBContext db = new EjemploDBContext();
            List<SelectListItem> listSelectItem = new List<SelectListItem>();
            foreach(Departamento dep in db.Departamento)
            {
                SelectListItem selectListItem = new SelectListItem()
                {
                    Text = dep.NomDepartamento,
                    Value = dep.DepartamentoId.ToString()
                };
                listSelectItem.Add(selectListItem);
            }
            DepartamentoViewModel depViewModel = new DepartamentoViewModel();
            depViewModel.apartamentos = listSelectItem;
            return View(depViewModel);
        }


        [HttpPost]
        public String Index4(IEnumerable<string> apartamentos)
        {
            if (apartamentos == null)
            {
                return "No has seleccionado ningun depratamento";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Elementos seleccionados: " + string.Join(", ", apartamentos));
                return sb.ToString();
            }
        }

        [HttpGet]
        public ActionResult Index5()
        {
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