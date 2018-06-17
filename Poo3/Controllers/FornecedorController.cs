using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aplication.Interfaces;
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

        private readonly IFornecedorAppService _appService;
      

        public FornecedorController(IFornecedorAppService appService)
        {
            _appService = appService;
        }
        // GET: FornecedorViewModels
        public ActionResult Index()

        {

            return View(_appService.GetAll());
        }

        // GET: FornecedorViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var fornecedorViewModel = _appService.Get(id);
            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorViewModel);
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
                _appService.Add(fornecedorViewModel);
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
            var fornecedorViewModel = _appService.Get(id);
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
                _appService.Update(fornecedorViewModel);
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
            var fornecedorViewModel = _appService.Get(id);
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
                _appService.Delete(id);
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
                _appService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
