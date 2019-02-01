using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;
using BlowOut.Models;
using BlowOut.DAL;
using System.Data.Entity;

namespace BlowOut.Controllers
{
    /*
     Author: Nicholas Mahe
     Description: A website for an instrument rental company
     */

    

    public class HomeController : Controller
    {
        private BlowOutContext db = new BlowOutContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Rentals()
        {
            return View(db.Instruments.ToList());
        }

        public ActionResult Create(int id)
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientID,FirstName,LastName,Address,City,State,Zip,Email,Phone")] Client client, int ID)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();

                Instrument instrument = db.Instruments.Find(ID);

                instrument.ClientID = client.ClientID;
                db.SaveChanges();

                return RedirectToAction("Summary", new { ClientID = client.ClientID, InstrumentID = instrument.InstrumentID });
            }

            return View(client);
        }

        public ActionResult Summary(int ClientID, int InstrumentID)
        {
            Client client = db.Clients.Find(ClientID);
            Instrument instrument = db.Instruments.Find(InstrumentID);

            ViewBag.Client = client;
            ViewBag.Instrument = instrument;
            ViewBag.ClientID = client.ClientID;
            ViewBag.FirstName = client.FirstName.ToUpper();
            ViewBag.LastName = client.LastName.ToUpper();
            ViewBag.InstrumentID = instrument.InstrumentID;
            ViewBag.Desc = instrument.Desc.ToUpper();
            ViewBag.Type = instrument.Type.ToUpper();
            ViewBag.Price = instrument.Price;
            ViewBag.EndPrice = Convert.ToDouble(instrument.Price)*18;
            

            return View();
        }

        




        //Instrument names and prices methods
        public ActionResult Saxophone()
        {
            ViewBag.Instrument = "Saxophone";
            ViewBag.Buy = "42";
            ViewBag.Rent = "30";
            return View("PriceListing");
        }

        public ActionResult Trumpet()
        {
            ViewBag.Instrument = "Trumpet";
            ViewBag.Buy = "55";
            ViewBag.Rent = "25";
            return View("PriceListing");
        }

        public ActionResult Flute()
        {
            ViewBag.Instrument = "Flute";
            ViewBag.Buy = "40";
            ViewBag.Rent = "25";
            return View("PriceListing");
        }

        public ActionResult Trombone()
        {
            ViewBag.Instrument = "Trombone";
            ViewBag.Buy = "60";
            ViewBag.Rent = "35";
            return View("PriceListing");
        }

        public ActionResult Tuba()
        {
            ViewBag.Instrument = "Tuba";
            ViewBag.Buy = "70";
            ViewBag.Rent = "50";
            return View("PriceListing");
        }

        public ActionResult Clarinet()
        {
            ViewBag.Instrument = "Clarinet";
            ViewBag.Buy = "35";
            ViewBag.Rent = "27";
            return View("PriceListing");
        }

        public ActionResult PriceListing()
        {
            return View();
        }
    }
}