﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _20160513_autenticacao.Models;

namespace _20160513_autenticacao.Controllers {

    // este anotador 'protege' os dados de todas as acções
    [Authorize]

    public class ConsultasController : Controller {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Consultas
        [Authorize(Roles = "Veterinarios,Donos")]
        public ActionResult Index() {
            var consultas = db.Consultas.
                Include(c => c.Animal).
                Include(c => c.Veterinario).
                Where(c => c.Veterinario.NomeDoUserName == User.Identity.Name).
                OrderByDescending(c => c.DataConsulta);
            return View(consultas.ToList());
        }

        // GET: Consultas/Details/5
        [Authorize(Roles = "Veterinarios,Donos")]
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultas consultas = db.Consultas.Find(id);
            if (consultas == null) {
                return HttpNotFound();
            }
            return View(consultas);
        }

        // GET: Consultas/Create
        [Authorize(Roles = "Veterinarios")]
        public ActionResult Create() {
            ViewBag.AnimalFK = new SelectList(db.Animais, "AnimalID", "Nome");
            //ViewBag.VeterinarioFK = new SelectList(db.Veterinarios, "VeterinarioID", "Nome");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Veterinarios")]
        public ActionResult Create([Bind(Include = "DataConsulta,AnimalFK")] Consultas consulta) {

            // adicionar o Veterinário em Falta
            consulta.Veterinario = db.Veterinarios.FirstOrDefault(v => v.NomeDoUserName == User.Identity.Name);

            if (ModelState.IsValid) {
                db.Consultas.Add(consulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AnimalFK = new SelectList(db.Animais, "AnimalID", "Nome", consulta.AnimalFK);
            ViewBag.VeterinarioFK = new SelectList(db.Veterinarios, "VeterinarioID", "Nome", consulta.VeterinarioFK);
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        [Authorize(Roles = "Veterinarios")]
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultas consultas = db.Consultas.Find(id);
            if (consultas == null) {
                return HttpNotFound();
            }
            ViewBag.AnimalFK = new SelectList(db.Animais, "AnimalID", "Nome", consultas.AnimalFK);
            ViewBag.VeterinarioFK = new SelectList(db.Veterinarios, "VeterinarioID", "Nome", consultas.VeterinarioFK);
            return View(consultas);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConsultaID,DataConsulta,VeterinarioFK,AnimalFK")] Consultas consultas) {
            if (ModelState.IsValid) {
                db.Entry(consultas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimalFK = new SelectList(db.Animais, "AnimalID", "Nome", consultas.AnimalFK);
            ViewBag.VeterinarioFK = new SelectList(db.Veterinarios, "VeterinarioID", "Nome", consultas.VeterinarioFK);
            return View(consultas);
        }

        // GET: Consultas/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultas consultas = db.Consultas.Find(id);
            if (consultas == null) {
                return HttpNotFound();
            }
            return View(consultas);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Consultas consultas = db.Consultas.Find(id);
            db.Consultas.Remove(consultas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
