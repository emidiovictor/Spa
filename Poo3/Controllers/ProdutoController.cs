using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using InfraData.Repositories;
using InfraData.ViewModels;
using UoW;

namespace Poo3.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly IProdutoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Context _context;

        public ProdutoController()
        {
            _context = new Context();
            _unitOfWork = new UnitOfWork(_context);
            _repository = new ProdutoRepository(_context);
        }
        // GET: ProdutoViewModels
        public ActionResult Index()

        {
            var ProdutoViewModel = Mapper.Map<IEnumerable<ProdutoViewModel>>(_repository.GetAll());
            return View(ProdutoViewModel.ToList());
        }

        // GET: ProdutoViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Produto = _repository.Get(id);
            var ProdutoViewModel = Mapper.Map<ProdutoViewModel>(Produto);
            if (ProdutoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(ProdutoViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = Mapper.Map<Produto>(produtoViewModel);
                _repository.Add(produto);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(produtoViewModel);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var produto = _repository.Get(id);
            var produtoViewModel = Mapper.Map<ProdutoViewModel>(produto);
            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {

                var produto = Mapper.Map<Produto>(produtoViewModel);
                var entry = _context.Entry(produto);
                _context.Set<Produto>().Attach(produto);
                entry.State = EntityState.Modified;
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(produtoViewModel);
        }
        // GET: ProdutoViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var produtoViewModel = _repository.Get(id);
            if (produtoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(produtoViewModel);
        }

        // POST: ProdutoViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                var produto = _repository.Get(id);
                _repository.Remove(produto);
                _unitOfWork.Commit();
                return RedirectToAction("Index");


            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
