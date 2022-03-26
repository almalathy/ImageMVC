using ImageMVC.Data;
using ImageMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageMVC.Controllers
{
    public class StudentController : Controller
    {
        IList<Student> studentList = new List<Student>();
    //    static IList<Student> studentList = new List<Student>{
    //            new Student() { StudentId = 1, StudentName = "John", Age = 18 } ,
    //            new Student() { StudentId = 2, StudentName = "Steve",  Age = 21 } ,
    //            new Student() { StudentId = 3, StudentName = "Bill",  Age = 25 } ,
    //            new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 } ,
    //            new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 } ,
    //            new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 } ,
    //            new Student() { StudentId = 4, StudentName = "Rob" , Age = 19 }

        //};
        // GET: Student

        public ActionResult Index()
        {
            DBUtil dbUtil = new DBUtil();
            studentList = dbUtil.GetStudentList();
            return View(studentList.OrderBy(s => s.StudentId).ToList());
        }
        public ActionResult Edit(int id)
        {
            DBUtil dbUtil = new DBUtil();
           
            Student student = dbUtil.SingleStudent(id);
            // var std = studentList.Where(s => s.StudentId == id).FirstOrDefault();
            //return View(std);
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student st)
        {
            DBUtil dbUtil = new DBUtil();
            dbUtil.UpdateStudentDetails(st);
            //var student = studentlist.where(s => s.studentid == st.studentid).firstordefault();
            //studentlist.remove(student);
            //studentlist.add(st);
            return RedirectToAction("Index");
        }
        
       

       /* [HttpPost]
        public ActionResult Edit(Student std)
        {
            //update student in DB using EntityFramework in real-life application

            //update list by removing old student and adding updated student for demo purpose
           
            var student = studentList.Where(s => s.StudentId == std.StudentId).FirstOrDefault();
            studentList.Remove(student);
            studentList.Add(std);

            return RedirectToAction("Index");
        }*/
        
        public ActionResult Details(int id)
        {
            DBUtil dbUtil = new DBUtil();

            Student student = dbUtil.SingleStudent(id);
            return View(student);
            //var std = studentList.Where(s => s.StudentId == id).FirstOrDefault();
            //return View(std);
        }
        
        public ActionResult Delete(int id)
        {
            DBUtil dbUtil = new DBUtil();

            Student student = dbUtil.SingleStudent(id);
            //var std = studentList.Where(s => s.StudentId == id).FirstOrDefault();
            // return View(std);
            return View(student);
        }
        [HttpPost]
        public ActionResult Deletes(int id)
        {
           DBUtil dbUtil = new DBUtil();

          dbUtil.DeleteStudent(id);
         
        //    var std = studentList.Where(s => s.StudentId == objStudent.StudentId).FirstOrDefault();
        //    studentList.Remove(student);
           return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student st)
        {
           DBUtil dbUtil = new DBUtil();
            dbUtil.CreateStudentDetails(st);
            studentList.Add(st);    
            return RedirectToAction("Index");
        }

    }
    
}