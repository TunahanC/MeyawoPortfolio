using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Controllers;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
    public class ContactController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblContact.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateContact(TblContact p)
        {
            db.TblContact.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteContact(int id)
        {
            var value = db.TblContact.Find(id);
            db.TblContact.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var value = db.TblContact.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateContact(TblContact p)
        {
            var value = db.TblContact.Find(p.ContactID);
            value.NameSurname = p.NameSurname;
            value.Email = p.Email;
            value.Message = p.Message;
            value.SendDate = p.SendDate;
            value.isRead = p.isRead;
            value.MessageCategory = p.MessageCategory;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}