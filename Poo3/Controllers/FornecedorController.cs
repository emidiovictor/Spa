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

    public class FornecedorController : Controller
    {


        private readonly IFornecedorRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Context _context;

        public FornecedorController()
        {
            _context = new Context();
            _unitOfWork = new UnitOfWork(_context);
            _repository = new FornecedorRepository(_context);
        }
        // GET: FornecedorViewModels
        public ActionResult Index()

        {
            var FornecedorViewModel = Mapper.Map<IEnumerable<FornecedorViewModel>>(_repository.GetAll());
            return View(FornecedorViewModel.ToList());
        }

        // GET: FornecedorViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Fornecedor = _repository.Get(id);
            var FornecedorViewModel = Mapper.Map<FornecedorViewModel>(Fornecedor);
            if (FornecedorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(FornecedorViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FornecedorViewModel fornecedorViewModel)
        {
            if (ModelState.IsValid)
            {
                var fornecedor = Mapper.Map<Fornecedor>(fornecedorViewModel);
                fornecedor.Id = Guid.NewGuid();
                fornecedor.Endereco.Id = Guid.NewGuid();

                _repository.Add(fornecedor);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(fornecedorViewModel);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var fornecedor = _repository.GetFornecedorEndereco(id);
            var fornecedorViewModel = Mapper.Map<FornecedorViewModel>(fornecedor);
            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FornecedorViewModel fornecedorViewModel)
        {
            if (ModelState.IsValid)
            {
                var fornecedor = Mapper.Map<Fornecedor>(fornecedorViewModel);
                var entry = _context.Entry(fornecedor);
                _context.Set<Fornecedor>().Attach(fornecedor);
                entry.State = EntityState.Modified;
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(fornecedorViewModel);
        }
        // GET: FornecedorViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var fornecedorViewModel = Mapper.Map<FornecedorViewModel>(_repository.Get(id));
            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorViewModel);
        }

        // POST: FornecedorViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                var fornecedor = _repository.Get(id);
                _repository.Remove(fornecedor);
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
