using Entity_Framework_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Entity_Framework_test.Controllers.api
{
    public class InstructorController : ApiController
    {
        ApplicationDbContext m_db = new ApplicationDbContext();

        // simple validation
        bool validationIsOk(string title)
        {
            return !string.IsNullOrEmpty(title);
        }

        [HttpGet]
        public IEnumerable<Instructor> GetCustomers()
        {
            return m_db.instructors;
        }

        [HttpGet]
        public IHttpActionResult Get_Instructors(long id)
        {
            Instructor InstructorD = m_db.instructors.Find(id);
            if (InstructorD == null)
            {
                return NotFound();
            }
            return Ok(InstructorD);
        }

        [HttpPost]
        public IHttpActionResult Create_Instructor(Instructor instructor)
        {
            if (!validationIsOk(instructor.Name) || !validationIsOk(instructor.Email)|| !validationIsOk(instructor.Password))
            {
                return BadRequest();
            }
            Instructor instructorObj = new Instructor { Name = instructor.Name, Email = instructor.Email, Password = instructor.Password };
            m_db.instructors.Add(instructorObj);
            m_db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = instructorObj.Id }, instructorObj);
        }

        [HttpPut]
        public IHttpActionResult Update_Instructor(long id, Instructor instructor)
        {
            if (!validationIsOk(instructor.Name) || !validationIsOk(instructor.Email) || !validationIsOk(instructor.Password))
            { return BadRequest(); }
            Instructor instructorObj = m_db.instructors.Find(id);
            if (instructorObj == null) { return NotFound(); }
            instructorObj.Name = instructor.Name;
            instructorObj.Email = instructor.Email;
            instructorObj.Password = instructor.Password;
            m_db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(long id)
        {
            Instructor instructorObj = m_db.instructors.Find(id);
            if (instructorObj == null)
            {
                return NotFound();
            }
            m_db.instructors.Remove(instructorObj);
            m_db.SaveChanges();
            return Ok(instructorObj);
        }
    }
}
