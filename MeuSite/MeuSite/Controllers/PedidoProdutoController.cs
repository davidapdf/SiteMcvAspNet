using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeuSite;
using MeuSite.Models;

namespace MeuSite.Controllers
{
    public class PedidoProdutoController : Controller
    {
        private BancoContext db = new BancoContext();

        // GET: PedidoProduto
        public ActionResult Index()
        {
            var pedidoProdutos = db.PedidoProdutos.Include(p => p.Pedido).Include(p => p.Produto);
            return View(pedidoProdutos.ToList());
        }

        // GET: PedidoProduto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoProduto pedidoProduto = db.PedidoProdutos.Find(id);
            if (pedidoProduto == null)
            {
                return HttpNotFound();
            }
            return View(pedidoProduto);
        }

        // GET: PedidoProduto/Create
        public ActionResult Create()
        {
            ViewBag.PedidoId = new SelectList(db.Pedidos, "id", "Descricao");
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Descricao");
            return View();
        }

        // POST: PedidoProduto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PedidoId,ProdutoId")] PedidoProduto pedidoProduto)
        {
            if (ModelState.IsValid)
            {
                db.PedidoProdutos.Add(pedidoProduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PedidoId = new SelectList(db.Pedidos, "id", "Descricao", pedidoProduto.PedidoId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Descricao", pedidoProduto.ProdutoId);
            return View(pedidoProduto);
        }

        // GET: PedidoProduto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoProduto pedidoProduto = db.PedidoProdutos.Find(id);
            if (pedidoProduto == null)
            {
                return HttpNotFound();
            }
            ViewBag.PedidoId = new SelectList(db.Pedidos, "id", "Descricao", pedidoProduto.PedidoId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Descricao", pedidoProduto.ProdutoId);
            return View(pedidoProduto);
        }

        // POST: PedidoProduto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PedidoId,ProdutoId")] PedidoProduto pedidoProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidoProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PedidoId = new SelectList(db.Pedidos, "id", "Descricao", pedidoProduto.PedidoId);
            ViewBag.ProdutoId = new SelectList(db.Produtos, "Id", "Descricao", pedidoProduto.ProdutoId);
            return View(pedidoProduto);
        }

        // GET: PedidoProduto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoProduto pedidoProduto = db.PedidoProdutos.Find(id);
            if (pedidoProduto == null)
            {
                return HttpNotFound();
            }
            return View(pedidoProduto);
        }

        // POST: PedidoProduto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoProduto pedidoProduto = db.PedidoProdutos.Find(id);
            db.PedidoProdutos.Remove(pedidoProduto);
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
