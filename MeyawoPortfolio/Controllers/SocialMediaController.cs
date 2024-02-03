using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblSocialMedia.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSocial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSocial(TblSocialMedia p)
        {
            db.TblSocialMedia.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocial(int id)
        {
            var value = db.TblSocialMedia.Find(id);
            db.TblSocialMedia.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSocial(int id)
        {
            var value = db.TblSocialMedia.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSocial(TblSocialMedia p)
        {
            var value = db.TblSocialMedia.Find(p.SocialMediaID);
            value.Title = p.Title;
            value.SocialMediaUrl = p.SocialMediaUrl;
            value.İcon = p.İcon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}