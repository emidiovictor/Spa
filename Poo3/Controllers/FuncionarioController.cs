using Aplication.AppService;
using Aplication.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Interfaces;
using InfraData.Repositories;
using InfraData.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using UoW;

namespace Poo3.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioAppService _appService;

        public FuncionarioController(IFuncionarioAppService appService)
        {
            _appService = appService;
        }

        // GET: Funcionario
        public ActionResult Index()
        {

            return View(_appService.GetAll());
        }

        // GET: Funcionario/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var funcionarioViewModel = _appService.Get(id);
            if (funcionarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(funcionarioViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FuncionarioViewModel funcionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                _appService.Add(funcionarioViewModel);
                return RedirectToAction("Index");
            }

            return View(funcionarioViewModel);
        }

        // GET: Funcionario/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var funcionarioViewModel = _appService.Get(id);
            if (funcionarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(funcionarioViewModel);
        }

        // POST: Funcionario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FuncionarioViewModel funcionarioViewModel)
        {
            if (ModelState.IsValid)
            {
                _appService.Update(funcionarioViewModel);
            }
            return View(funcionarioViewModel);
        }

        // GET: Funcionario/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var funcionarioViewModel = _appService.Get(id);
            if (funcionarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(funcionarioViewModel);
        }

        // POST: Funcionario/Delete/5
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
