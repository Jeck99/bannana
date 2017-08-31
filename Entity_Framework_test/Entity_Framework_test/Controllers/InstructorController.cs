using Entity_Framework_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entity_Framework_test.Controllers
{
    public class InstructorController : Controller
    {
        ApplicationDbContext m_db = new ApplicationDbContext();
        // GET: post
        public ActionResult Index()
        {
            IEnumerable<Instructor> InstructorData = m_db.instructors;
            return View(InstructorData);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing) { m_db.Dispose(); }
            base.Dispose(disposing);
        }

        [HttpGet] public ActionResult Create() { return View(); }
        [HttpPost]
        public ActionResult Create(string Name, string Email, string Password)
        {
            if (!string.IsNullOrEmpty(Name) || !string.IsNullOrEmpty(Email) || !string.IsNullOrEmpty(Password))
            {  // simple validation
                Instructor InstructorData = new Instructor { Name = Name, Email = Email, Password = Password };
                m_db.instructors.Add(InstructorData);
                m_db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            Instructor postE = m_db.instructors.Find(id);
            return View(postE);
        }

        [HttpPost]
        public ActionResult Edit(long id, string Name, string Email, string Password)
        {
            if (!string.IsNullOrEmpty(Name) || !string.IsNullOrEmpty(Email) || !string.IsNullOrEmpty(Password))
            {
                Instructor InstructorEdit = m_db.instructors.FirstOrDefault(pos => pos.Id == id);
                if (InstructorEdit == null) { return HttpNotFound(); }
                InstructorEdit.Name = Name;
                InstructorEdit.Email = Email;
                InstructorEdit.Password = Password;
                m_db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete() { return View(); }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            Instructor InstructorDelete = m_db.instructors.FirstOrDefault(pos => pos.Id == id);
            if (InstructorDelete == null) { return HttpNotFound(); }
            m_db.instructors.Remove(InstructorDelete);
            m_db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}