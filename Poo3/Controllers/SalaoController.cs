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
    public class SalaoController : Controller
    {
        private readonly ISalaoAppService _appService;

    
        public SalaoController(ISalaoAppService salaoAppService)
        {
            _appService = salaoAppService;        
        }
        // GET: SalaoViewModels
        public ActionResult Index()

        {
            var salaoViewModel = _appService.GetAll();
            return View(salaoViewModel.ToList());
        }

        // GET: SalaoViewModels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var salaoViewModel = _appService.Get(id);
            if (salaoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(salaoViewModel);
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
                _appService.Update(salaoViewModel);
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
            var salaoViewModel = _appService.Get(id);
            if (salaoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(salaoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SalaoViewModel salaoViewModel)
        {
            if (ModelState.IsValid)
            {

                _appService.Update(salaoViewModel);
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
            var salaoViewModel = _appService.Get(id);
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
