using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ejercicio4.Models;

namespace Ejercicio4.Controllers
{
    public class EmpleadoController : Controller
    {
        DBConexion db = new DBConexion();

        // GET: Empleado
        public ActionResult Index()
        {
            return View(db.Empleado.ToList());
        }

        [HttpPost]
        public ActionResult Borrar(IEnumerable<int> empleadoIdsBorrar)
        {
            db.Empleado.Where(x => empleadoIdsBorrar.Contains(x.EmpleadoId)).ToList().ForEach(db.Empleado.deleteObject());

            return RedirectToAction("Index");
        }
    }
}