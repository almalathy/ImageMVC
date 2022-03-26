using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImageMVC.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Display(Name = "Name")]
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string Degree { get; set; }
        public int Marks { get; set; }

        /*  internal void DeleteStudent(int id)
          {
              throw new NotImplementedException();
          }
          //public Standard standard { get; set; }
      }
     ( public class Standard
      {
          public int StandardId { get; set; }
          public string StandardName { get; set; }
      }*/
    }
}
