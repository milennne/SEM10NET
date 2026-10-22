using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class PersonController : Controller
    {

        // GET: Person
        public ActionResult Index()
        {
            if (Session["people"]==null)
            {
                List<PersonModel> people = new List<PersonModel>();

                people.Add(new PersonModel { Id = 1, FirstName = "Milene", LastName = "Fuentes", Age = 18 });
                people.Add(new PersonModel { Id = 2, FirstName = "Almendra", LastName = "Olarte", Age = 19 });
                Session["people"] = people;

            }
            
            return View(Session["people"]);
        }


        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonModel model)
        {
            try
            {
                List<PersonModel> people = (List<PersonModel>)Session["people"];
                model.Id = people.Count > 0 ? people.Max(x => x.Id) + 1 : 1;
                people.Add(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            PersonModel model = ((List<PersonModel>)Session["people"]).Where(x => x.Id == id).FirstOrDefault();
            return View(model);
        }



        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {

            PersonModel model=((List<PersonModel>)Session["people"]).Where(x => x.Id == id).FirstOrDefault();
            return View(model);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PersonModel model)
        {
            try
            {
                // TODO: Add update logic here
                PersonModel person = ((List<PersonModel>)Session["people"]).Where(x => x.Id == id).FirstOrDefault();
                person.FirstName = model.FirstName;
                person.LastName = model.LastName;
                person.Age = model.Age;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            PersonModel model = ((List<PersonModel>)Session["people"]).Where(x => x.Id == id).FirstOrDefault();
            return View(model);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                List<PersonModel> people = (List<PersonModel>)Session["people"];
                PersonModel person = people.Where(x => x.Id == id).FirstOrDefault();
                people.Remove(person);

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}
