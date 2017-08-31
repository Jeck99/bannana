using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity_Framework_test.Models
{
    public class InstructorOfCourse
    {
        public long Id { get; set; }//primary key
        public long Instructor_Id { get; set; }
        public long Course_Id { get; set; }
    }
}