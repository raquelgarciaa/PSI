using Modelo.Tabelas;
using Persistencia.Contexts;
using Servico.Tabelas;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace estudos.Controllers
{
    public class CategoriasController : Controller
    {
        private CategoriaServico categoriaServico = new CategoriaServico();
        private ActionResult ObterVisaoCategoriaPorId(long? id)//get
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Categoria categoria = categoriaServico.ObterCategoriaPorId((long)id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        private ActionResult GravarCategoria(Categoria categoria)//post
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }
        // GET: Fabricantes
        public ActionResult Index()
        {
            return View(categoriaServico.ObterCategoriasClassificadasPorNome());
        }
        // GET: Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }
        // GET: Edit
        public ActionResult Edit(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }
        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }
        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }
        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }
        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Categoria categoria =categoriaServico.EliminarCategoriaPorId(id);
                TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}