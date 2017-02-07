using Ejercicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejercicios.Controllers
{
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        public ActionResult Index()
        {
            EmpleadoContext empleadoContext = new EmpleadoContext();
            List<Departamento> departamentos = empleadoContext.Departamentos.ToList();

            return View(departamentos);
        }
    }
}