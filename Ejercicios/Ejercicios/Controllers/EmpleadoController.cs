
using Ejercicios.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ejercicios.Controllers
{
    public class EmpleadoController : Controller
    {
        public ActionResult Index()//Sacando el empleado de la base de datos
        {
            EmpleadoContext empleadoContext = new EmpleadoContext();
            List<Empleado> empleados = empleadoContext.Empleados.ToList();

            return View(empleados);
        }

        public ActionResult Index2(int depId)//Sacando el empleado filtrando por departamento
        {
            EmpleadoContext empleadoContext = new EmpleadoContext();
            List<Empleado> empleados = empleadoContext.Empleados.Where(emp => emp.DepartamentoId == depId).ToList();

            return View(empleados);
        }

        public ActionResult Details () //Creando un emplead aqui
         {
             Empleado empleado = new Empleado()
             {
                 EmpleadoId = 6,
                 Nombre = "Julio",
                 Genero = "Masculino",
                 Ciudad = "Madrid",
                 DepartamentoId = 4
             };
             return View(empleado);
         }

        public ActionResult Details2(int id)//Sacando el empleado de la base de datos
        {
            EmpleadoContext empleadoContext = new EmpleadoContext();
            Empleado empleado = empleadoContext.Empleados.Single(emp => emp.EmpleadoId == id);

            return View(empleado);
        }

    }
}