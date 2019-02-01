using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using BlowOut.Models;
using BlowOut.DAL;
using System.Data.Entity;
using System.Net;
using System.Web.Security;

namespace BlowOut.Controllers
{
    public class UpdateController : Controller
    {

        private BlowOutContext db = new BlowOutContext();
        // GET: Update
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String username = form["Username"].ToString();
            String password = form["Password"].ToString();

            if (String.Equals(username,"Missouri") && String.Equals(password,"ShowMe"))
            {
                FormsAuthentication.SetAuthCookie(username, rememberMe);
                return View("UpdateData", db.Instruments.ToList());
            }
            else
            {
                ViewBag.LogError = "Incorrect username and/or password";
            }

                return View("Login");
            
        }

        [Authorize]
        public ActionResult UpdateData()
        {
            return View(db.Instruments.ToList());
        }

        // GET: Instruments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrument instrument = db.Instruments.Find(id);
            if (instrument == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "FirstName", instrument.ClientID);
            return View(instrument.Client);
        }

        // POST: Instruments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientID,FirstName,LastName,Address,City,State,Zip,Email,Phone")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UpdateData");
            }
            return View(client);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instrument instrument = db.Instruments.Find(id);
            if (instrument == null)
            {
                return HttpNotFound();
            }
            if (instrument.Client == null)
            {
                ViewBag.Error = "Client information not found";
                String errormsg = ViewBag.Error;
                return RedirectToAction("Error");
            }
            return View(instrument.Client);
        }

        // POST: Instruments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instrument instrument = db.Instruments.Find(id);
            Client client = db.Clients.Find(instrument.ClientID);
            db.Clients.Remove(instrument.Client);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("UpdateData");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Error()
        {
            ViewBag.Error = "Client information not found";
            return View();
        }
    }
}