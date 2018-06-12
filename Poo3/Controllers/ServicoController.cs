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
    public class ServicoController : Controller
    {

        private readonly IServicoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Context _context;

        public ServicoController()
        {
            _context = new Context();
            _unitOfWork = new UnitOfWork(_context);
            _repository = new ServicoRepository(_context);
        }
        // GET: ServicoViewModels
        public ActionResult Index()

        {
            var ServicoViewModel = Mapper.Map<IEnumerable<ServicoViewModel>>(_repository.GetAll());
            return View(ServicoViewModel.ToList());
        }

        // GET: ServicoViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Servico = _repository.Get(id);
            var ServicoViewModel = Mapper.Map<ServicoViewModel>(Servico);
            if (ServicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(ServicoViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServicoViewModel servicoViewModel)
        {
            if (ModelState.IsValid)
            {
                var servico = Mapper.Map<Servico>(servicoViewModel);
                _repository.Add(servico);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(servicoViewModel);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var servico = _repository.Get(id);
            var servicoViewModel = Mapper.Map<ServicoViewModel>(servico);
            if (servicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(servicoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServicoViewModel servicoViewModel)
        {
            if (ModelState.IsValid)
            {

                var servico = Mapper.Map<Servico>(servicoViewModel);
                var entry = _context.Entry(servico);
                _context.Set<Servico>().Attach(servico);
                entry.State = EntityState.Modified;
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(servicoViewModel);
        }
        // GET: ServicoViewModels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var servicoViewModel = _repository.Get(id);
            if (servicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(servicoViewModel);
        }

        // POST: ServicoViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                var servico = _repository.Get(id);
                _repository.Remove(servico);
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
