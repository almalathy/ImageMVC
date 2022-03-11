using ImageMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageMVC.Controllers
{
    public class StudentController : Controller
    {
        static IList<Student> studentList = new List<Student>{
                new Student() { StudentId = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentId = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentId = 3, StudentName = "Bill",  Age = 25 } ,
                new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
                new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
                new Student() { StudentId = 4, StudentName = "Rob" , Age = 19 }
               
    };
        // GET: Student
        
        public ActionResult Index()
        {

            return View(studentList.OrderBy(s => s.StudentId).ToList());
        }
        public ActionResult Edit(int id)
        {
            var std=studentList.Where(s=>s.StudentId==id).FirstOrDefault();
            return View(std);
            
        }
        [HttpPost]
        public ActionResult Edit(Student std)
        {
            //update student in DB using EntityFramework in real-life application

            //update list by removing old student and adding updated student for demo purpose
            var student = studentList.Where(s => s.StudentId == std.StudentId).FirstOrDefault();
            studentList.Remove(student);
            studentList.Add(std);

            return RedirectToAction("Index");
        }
        
        public ActionResult Details(int id)
        {
            var std = studentList.Where(s => s.StudentId == id).FirstOrDefault();
            return View(std);
        }
        
        public ActionResult Delete(int id)
        {
            var std = studentList.Where(s => s.StudentId == id).FirstOrDefault();
            return View(std);
        }
        [HttpPost]
        public ActionResult Delete(Student objStudent)
        {
            var std = studentList.Where(s => s.StudentId == objStudent.StudentId).FirstOrDefault();
            studentList.Remove(std);
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student objStudent)
        {
            studentList.Add(objStudent);    
            return RedirectToAction("Index");
        }

    }
    
}