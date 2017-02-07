﻿using EFDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFDemo.Controllers {
    public class VehiculoController : Controller {
        // GET: Vehiculo
        public ActionResult Index() {
            ViewBag.Marcas = GetMarcas();
            return View();
        }

        // GET: Vehiculo/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Vehiculo/Create
        public ActionResult Create() {
            return View();
        }

        private List<MarcaModelo> GetMarcas(){
            using(var bd = new Contexto()){
                return bd.Marcas.ToList();
            }
        }

        // POST: Vehiculo/Create
        [HttpPost]
        public ActionResult Create(VehiculoModelo vehiculo) {
            try{
                using (var bd = new Contexto()) {
                    bd.Vehiculos.Add(vehiculo);
                    bd.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch {
                return View("Index");
            }
        }

        // GET: Vehiculo/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Vehiculo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Vehiculo/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Vehiculo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}