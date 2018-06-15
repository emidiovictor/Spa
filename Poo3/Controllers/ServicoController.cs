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
    public class ServicoController : Controller
    {
        private readonly IServicoAppService _appService;
        public ServicoController(IServicoAppService appService)

        {
            _appService = appService;
        }
        // GET: ServicoViewModels
        public ActionResult Index()

        {
            return View(_appService);
        }

        // GET: ServicoViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var servicoViewModel = _appService.Get(id);
            if (servicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(servicoViewModel);
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
                _appService.Add(servicoViewModel);
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
            var servicoViewModel = _appService.Get(id);
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

                _appService.Update(servicoViewModel);
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
            var servicoViewModel = _appService.Get(id);
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
