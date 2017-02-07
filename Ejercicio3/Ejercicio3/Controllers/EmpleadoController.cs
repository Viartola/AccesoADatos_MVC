using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ejercicio3.Models;
using PagedList;
using PagedList.Mvc;

namespace Ejercicio3.Controllers
{
    public class EmpleadoController : Controller
    {
        EjemploGeneral db = new EjemploGeneral();

        // GET: Empleado
        public ActionResult Index(string buscarPor, string buscar, int? pagina)//int? es que admite nulos
        {
            if(buscarPor == "Genero")
            {
                return View(db.Empleado.Where(x => x.Genero == buscar).ToList().ToPagedList(pagina ?? 1,3));
            }else if(buscarPor == "Nombre")
            {
                return View(db.Empleado.Where(x => x.Nombre.Contains(buscar)).ToList().ToPagedList(pagina ?? 1, 3));
            }
            return View(db.Empleado.ToList().ToPagedList(pagina ?? 1, 3));
        }

        public ActionResult Index2(string buscarPor, string buscar, int? pagina, string ordenadoPor)
        {
            ViewBag.OrdenNombre = string.IsNullOrEmpty(ordenadoPor) ? "Nombre desc" : "";//Guardamos en OrdenNombre la ordenacion contraria a la que tiene actualmente
            ViewBag.OrdenGenero = (ordenadoPor == "Genero") ? "Genero desc" : "Genero";//Guardamos en OrdenNombre la ordenacion contraria a la que tiene actualmente

            var empleados = db.Empleado.AsQueryable();

            if (buscarPor == "Genero")
            {
                empleados = empleados.Where(x => x.Genero == buscar || buscar == null);
            }
            else if (buscarPor == "Nombre")
            {
                empleados = empleados.Where(x => x.Nombre.Contains(buscar) || buscar == null);
            }

            switch (ordenadoPor)
            {
                case "Nombre desc":
                    empleados = empleados.OrderByDescending(x => x.Nombre);
                    break;
                case "Genero desc":
                    empleados = empleados.OrderByDescending(x => x.Genero);
                    break;
                case "Genero":
                    empleados = empleados.OrderBy(x => x.Genero);
                    break;
                default:
                    empleados = empleados.OrderBy(x => x.Nombre);
                    break;
            }

            //empleados.ToList().ToPagedList(pagina ?? 1, 3);
            return View(empleados.ToPagedList(pagina ?? 1, 3));
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpleadoId,Nombre,Genero,Ciudad,DepartamentoId,FechaNacimiento")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpleadoId,Nombre,Genero,Ciudad,DepartamentoId,FechaNacimiento")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
