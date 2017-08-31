using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entity_Framework_test.Models
{
    public class Course
    {
        public long Id { get; set; }//primary key
        public string Name { get; set; }
        public string Description { get; set; }
    }
}