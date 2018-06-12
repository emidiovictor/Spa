using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using InfraData.Repositories;
using InfraData.ViewModels;
using UoW;

namespace Poo3.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Context _context;
        
        public ClienteController()
        {
            _context = new Context();
            _unitOfWork = new UnitOfWork(_context);
            _repository = new ClienteRepository(_context);
        }
        // GET: Cliente
        public ActionResult Index()

        {
            var clienteViewModel = Mapper.Map<IEnumerable<ClienteViewModel>>(_repository.GetAll());
            return View(clienteViewModel.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = _repository.Get(id);
            var clienteViewModel = Mapper.Map<ClienteViewModel>(cliente);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var cliente = Mapper.Map<Clientes>(clienteViewModel);
                cliente.Id = Guid.NewGuid();
                cliente.Endereco.Id = Guid.NewGuid();
                _repository.Add(cliente);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(clienteViewModel);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = _repository.GetClienteEndereco(id);
            var clienteViewModel = Mapper.Map<ClienteViewModel>(cliente);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {

                var cliente = Mapper.Map<Clientes>(clienteViewModel);
                var entry = _context.Entry(cliente);
                var entry2 = _context.Entry(cliente.Endereco);

                
                _context.Set<Clientes>().Attach(cliente);
                entry2.State = EntityState.Modified;
                entry.State = EntityState.Modified;
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }
        // GET: Cliente/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var clienteViewModel = Mapper.Map<ClienteViewModel>(_repository.Get(id));
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {

            var cliente = _repository.Get(id);
            _repository.Remove(cliente);
            _unitOfWork.Commit();
            return RedirectToAction("Index");

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
