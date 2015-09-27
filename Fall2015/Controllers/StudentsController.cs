using Fall2015.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fall2015.Repositories;

namespace Fall2015.Controllers
{
    public class StudentsController : Controller
    {
        //quick and dirty - high coupling.
        //I'll fix this later.
        
        StudentsRepository studentsRepository = 
            new StudentsRepository();

        public ActionResult Index()
        {
            List<Student> students = studentsRepository.All.ToList();
            return View(students);
        }

        [HttpGet]
        public ActionResult Edit(int studentId)
        {
            //look up a student in the db
            Student student = studentsRepository.Find(studentId);
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student student, HttpPostedFileBase image)
        {
            //save to db.
            //if you edit student
            if (ModelState.IsValid)
            {
                studentsRepository.InsertOrUpdate(student);
                student.SaveImage(image, Server.MapPath("~"), "/ProfileImages/");
                studentsRepository.Save();
                return RedirectToAction("Index");
            }


            return View(student);


        }




        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student, 
            HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                studentsRepository.InsertOrUpdate(student);
                student.SaveImage(image, Server.MapPath("~"), "/ProfileImages/");
                studentsRepository.Save();
                
                return View("Thanks");
            }
            else
            {
                return View();
            }
        }



        public String WannaPlayDad()
        {
            return "No!";
        }

        public ActionResult WannaPlayDad2()
        {
            ViewBag.Dad = "Hi there sonny";
            return View();
        }
    }
}




