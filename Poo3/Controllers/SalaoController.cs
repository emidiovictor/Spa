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
    public class SalaoController : Controller
    {
        private readonly ISalaoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Context _context;

        public SalaoController()
        {
            _context = new Context();
            _unitOfWork = new UnitOfWork(_context);
            _repository = new SalaoRepository(_context);
        }
        // GET: SalaoViewModels
        public ActionResult Index()

        {
            var SalaoViewModel = Mapper.Map<IEnumerable<SalaoViewModel>>(_repository.GetAll());
            return View(SalaoViewModel.ToList());
        }

        // GET: SalaoViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Salao = _repository.Get(id);
            var SalaoViewModel = Mapper.Map<SalaoViewModel>(Salao);
            if (SalaoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(SalaoViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalaoViewModel salaoViewModel)
        {
            if (ModelState.IsValid)
            {
                var salao = Mapper.Map<Salao>(salaoViewModel);
                salao.Id = Guid.NewGuid();
                salao.Endereco.Id = Guid.NewGuid();
                _repository.Add(salao);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(salaoViewModel);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var salao = _repository.GetSalaoEndereco(id);
            var salaoViewModel = Mapper.Map<SalaoViewModel>(salao);
            if (salaoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(salaoViewModel);
        }

#warning edit não funciona
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SalaoViewModel salaoViewModel)
        {
            if (ModelState.IsValid)
            {

                var salao = Mapper.Map<Salao>(salaoViewModel);
                var entry = _context.Entry(salao);
                _context.Set<Salao>().Attach(salao);
                entry.State = EntityState.Modified;
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(salaoViewModel);
        }
        // GET: SalaoViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var salaoViewModel = Mapper.Map<SalaoViewModel>(_repository.Get(id));
            if (salaoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(salaoViewModel);
        }

        // POST: SalaoViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                var salao = _repository.Get(id);
                _repository.Remove(salao);
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
