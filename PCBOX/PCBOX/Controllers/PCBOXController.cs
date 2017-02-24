using PCBOX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCBOX.Controllers
{
    public class PCBOXController : Controller
    {
        // GET: PCBOX
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index2()
        {
            PCBOXEntities db = new PCBOXEntities();
            ViewBag.Categorias = new SelectList(db.Categoria, "CategoriaId", "nomCategoria");
            ViewBag.SubCategorias = new SelectList(db.Subcategoria, "SubcategoriaId", "nomSubcategoria");
            ViewBag.Productos = new SelectList(db.Producto, "ProductoId", "nomProducto");
            ViewBag.Marcas = new SelectList(db.Marca, "MarcaId", "nomMarca");
            return View(db.Producto.ToList());
        }
        [HttpPost]
        public ActionResult Index2(int Productos)
        {
            PCBOXEntities db = new PCBOXEntities();
            ViewBag.Categorias = new SelectList(db.Categoria, "CategoriaId", "nomCategoria");
            ViewBag.SubCategorias = new SelectList(db.Subcategoria, "SubcategoriaId", "nomSubcategoria");
            ViewBag.Productos = new SelectList(db.Producto, "ProductoId", "nomProducto");
            ViewBag.Marcas = new SelectList(db.Marca, "MarcaId", "nomMarca");
            return View(db.Producto.Where(x => x.ProductoId == Productos).ToList());
        }
    }
}