using RestaurantRATER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRATER.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDBContext db = new RestaurantDBContext();
        // GET: Restaurant
        public ActionResult Index()
        {
            return View(db.Restaurants.ToList());
        }
        //Get: Restaurant/create
        public ActionResult Create()
        {

            return View();
        }

        //Post: restaurant/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }
                // GET: Restaurant/Delete/id
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if(restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCofimred (int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
            return RedirectToAction("index");
        }

    }
}