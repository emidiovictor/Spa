using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Domain.Interfaces;
using InfraData.Repositories;
using InfraData.ViewModels;

namespace Poo3.Controllers
{
    public class AgendaController : Controller
    {
        private Context db = new Context();

        private readonly IClienteRepository clienteRepository = new ClienteRepository(new Context());
        private readonly IServicoRepository sevicoRepository = new ServicoRepository(new Context());

        // GET: Agenda/Create
        public ActionResult Create()
        {
            var cliente = clienteRepository.GetAll();
            var select = new SelectList(cliente, "Id", "Nome");
            ViewBag.ClienteId = select;

            var servicos = sevicoRepository.GetAll();
            var selectServices = new SelectList(servicos, "Id", "Descricao");
            ViewBag.ServicoId = selectServices;
            return View();
        }
        [HttpPost]
        public JsonResult GetData(String json)
        {
            return null;
        }



        // POST: Agenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Data,IdFuncionario,IdCliente")] AgendaViewModel agendaViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agendaViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agendaViewModel);
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
