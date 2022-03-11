using ImageMVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageMVC.Controllers
{
    public class IMGController : Controller
    {
       
        // GET: IMG
        public ActionResult Index()
        {            
           return View(ImageRetrieve());
           
        }

        public ActionResult ShowIMG(string fileName)
        {
            ViewBag.fileName = fileName;
            return View();
        }

        [HttpPost]
        public ActionResult ShowIMG(IMG img)
        {
            if (ModelState.IsValid)
            {
                ViewBag.fileName = img.Search + ".jpg";
            }
            return View();
        }

        [HttpPost]
        public ActionResult UploadFiles(HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (file != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/UploadedFiles"), Path.GetFileName(file.FileName));

                        if (!System.IO.File.Exists(path)) //Equavalent to == false
                        {
                            file.SaveAs(path);
                            ViewBag.FileStatus = "File uploaded successfully.";                            
                        }
                        else
                        {
                            ViewBag.FileStatus = "File is already exist.";
                        }
                    }                               
                    else 
                    {
                        ViewBag.FileStatus = "Please Upload File.";
                    }


                }
                catch (Exception)
                {
                    ViewBag.FileStatus = "Error while file uploading.";
                }

            }
            return View("Index", ImageRetrieve());
          
        }



        private IMG ImageRetrieve()
        {
            IMG img = new Models.IMG();
            img.Search = "";
            img.imgList = Directory.GetFiles(Server.MapPath("~/UploadedFiles")).ToList();
            return img;
        }
    }
}   
    
