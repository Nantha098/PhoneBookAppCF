using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhoneBookAppCF.DAL;
using PhoneBookAppCF.Models;

namespace PhoneBookAppCF.Controllers
{
    public class PeopleController : Controller
    {
        private PersonContext db = new PersonContext();

        // GET: People
        public ActionResult Index(String SearchString)
        {
            if (!String.IsNullOrEmpty(SearchString))
            {
                var people = db.Person.Where(p => (p.FirstName.Contains(SearchString) ||
                                                   p.LastName.Contains(SearchString) ||
                                                   p.PhoneNumber.Contains(SearchString)) &&
                                                   p.IsActive);
                return View(people.ToList());
            }
            var person = db.Person.Include(p => p.City).Include(p => p.Country).Include(p => p.State);
            person = person.Where(p => p.IsActive.Equals(true));
            return View(person.ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.City, "CityID", "CityName");
            ViewBag.CountryID = new SelectList(db.Country, "CountryID", "CountryName");
            ViewBag.StateID = new SelectList(db.State, "StateID", "StateName");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,PhoneNumber,Email,AddressLine1,AddressLine2,CityID,StateID,PinCode,CountryID,IsActive")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Person.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.City, "CityID", "CityName", person.CityID);
            ViewBag.CountryID = new SelectList(db.Country, "CountryID", "CountryName", person.CountryID);
            ViewBag.StateID = new SelectList(db.State, "StateID", "StateName", person.StateID);
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.City, "CityID", "CityName", person.CityID);
            ViewBag.CountryID = new SelectList(db.Country, "CountryID", "CountryName", person.CountryID);
            ViewBag.StateID = new SelectList(db.State, "StateID", "StateName", person.StateID);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,PhoneNumber,Email,AddressLine1,AddressLine2,CityID,StateID,PinCode,CountryID,IsActive")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.City, "CityID", "CityName", person.CityID);
            ViewBag.CountryID = new SelectList(db.Country, "CountryID", "CountryName", person.CountryID);
            ViewBag.StateID = new SelectList(db.State, "StateID", "StateName", person.StateID);
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Person.Find(id);
            db.Person.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
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
