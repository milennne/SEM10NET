using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class ProductController : Controller
    {
        // Inicializa la sesión solo si no existe
        private List<ProductModel> ObtenerProductos()
        {
            if (Session["productos"] == null)
            {
                List<ProductModel> productos = new List<ProductModel>();
                productos.Add(new ProductModel { Id = 1, Nombre = "Laptop Lenovo", Descripcion = "Laptop Ryzen 5, 16GB RAM", Precio = 2899.90m, Stock = 10 });
                productos.Add(new ProductModel { Id = 2, Nombre = "Mouse Logitech", Descripcion = "Mouse inalámbrico M185", Precio = 49.90m, Stock = 50 });
                productos.Add(new ProductModel { Id = 3, Nombre = "Teclado Redragon", Descripcion = "Teclado mecánico Kumara", Precio = 159.00m, Stock = 25 });
                Session["productos"] = productos;
            }
            return (List<ProductModel>)Session["productos"];
        }

        // GET: Product
        public ActionResult Index()
        {
            return View(ObtenerProductos());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            ProductModel model = ObtenerProductos().Where(x => x.Id == id).FirstOrDefault();
            return View(model);
        }






        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductModel model)
        {
            try
            {
                List<ProductModel> productos = ObtenerProductos();
                model.Id = productos.Count > 0 ? productos.Max(x => x.Id) + 1 : 1;
                productos.Add(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }












        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            ProductModel model = ObtenerProductos().Where(x => x.Id == id).FirstOrDefault();
            return View(model);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductModel model)
        {
            try
            {
                ProductModel producto = ObtenerProductos().Where(x => x.Id == id).FirstOrDefault();
                producto.Nombre = model.Nombre;
                producto.Descripcion = model.Descripcion;
                producto.Precio = model.Precio;
                producto.Stock = model.Stock;
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }









        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            ProductModel model = ObtenerProductos().Where(x => x.Id == id).FirstOrDefault();
            return View(model);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                List<ProductModel> productos = ObtenerProductos();
                ProductModel producto = productos.Where(x => x.Id == id).FirstOrDefault();
                productos.Remove(producto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}