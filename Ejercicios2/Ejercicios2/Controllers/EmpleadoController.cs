using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;

namespace Ejercicios2.Controllers
{
    public class EmpleadoController : Controller
    {
        public ActionResult Index()
        {
            EmpleadoCapaNegocio empleadoCapaNegocio = new EmpleadoCapaNegocio();
            List<Empleado> empleados = empleadoCapaNegocio.Empleados.ToList();

            return View(empleados);
        }

        [HttpGet]
        public ActionResult Create()
        {
          
            return View();
        }

        /*[HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            Sacar valores del formulario por pantalla
            foreach(string Key in formCollection.AllKeys)
            {
                Response.Write("Clave = " + Key);
                Response.Write(formCollection[Key]);
                Response.Write("</br>");
            }

         Empleado empleado = new Empleado();
             empleado.Nombre = formCollection["Nombre"];
             empleado.Genero = formCollection["Genero"];
             empleado.Ciudad = formCollection["Ciudad"];
             empleado.FechaNacimiento = Convert.ToDateTime(formCollection["FechaNacimiento"]);
             EmpleadoCapaNegocio ecn = new EmpleadoCapaNegocio();
             ecn.AddEmpleado(empleado);

             return RedirectToAction("Index");
         }*/

        /*[HttpPost]
        public ActionResult Create(string nombre, string genero, string ciudad, DateTime fechaNacimiento)
        {
            Empleado empleado = new Empleado();
            empleado.Nombre = nombre;
            empleado.Genero = genero;
            empleado.Ciudad = ciudad;
            empleado.FechaNacimiento = fechaNacimiento;
            EmpleadoCapaNegocio ecn = new EmpleadoCapaNegocio();
            ecn.AddEmpleado(empleado);

            return RedirectToAction("Index");
        }*/

        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                EmpleadoCapaNegocio ecn = new EmpleadoCapaNegocio();
                ecn.AddEmpleado(empleado);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmpleadoCapaNegocio ecn = new EmpleadoCapaNegocio();
            Empleado empleado = ecn.SelectEmpleado(id);
            return View(empleado);
        }

        [HttpPost]
        public ActionResult Edit(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                EmpleadoCapaNegocio ecn = new EmpleadoCapaNegocio();
                ecn.UpdateEmpleado(empleado);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            EmpleadoCapaNegocio ecn = new EmpleadoCapaNegocio();
            ecn.DeleteEmpleado(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Shearch()
        {
            EmpleadoCapaNegocio empleadoCapaNegocio = new EmpleadoCapaNegocio();
            List<Empleado> empleados = empleadoCapaNegocio.Empleados.ToList();
            return View(empleados);
        }


        [HttpPost]
        public ActionResult Shearch(string nom)
        {
            EmpleadoCapaNegocio ecn = new EmpleadoCapaNegocio();
            List<Empleado> empleados = ecn.shearchEmpleado(nom).ToList();

            return View(empleados);
        }
    }
}