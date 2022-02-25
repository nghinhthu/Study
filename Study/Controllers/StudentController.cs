using Microsoft.AspNetCore.Mvc;
using Study.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Study.Controllers
{
    public class StudentController : Controller
    {
        //List<StudentModel> studentModels = new List<StudentModel>();

        List<StudentModel> studentList;

        public StudentController()
        {
            studentList = new List<StudentModel>()
            {
                new StudentModel(){ ID = 1, Name = "Bak Bak", Address = "Binh Tan", City = "Ho Chi Minh" },
                new StudentModel(){ ID = 2, Name = "Meo Meo", Address = "Binh Tan", City = "Ho Chi Minh" },
                new StudentModel(){ ID = 3, Name = "Cow Cow", Address = "Binh Tan", City = "Ho Chi Minh" },
            };
        }

        public IActionResult Index()
        {
            return View(studentList);
        }

        public IActionResult Create()
        {
            StudentModel student = new StudentModel();
            return View(student);
        }

        [HttpPost]
        public IActionResult Create(StudentModel student)
        {
            studentList.Add(student);
            return View("Index");
        }

        public IActionResult Edit(int id)
        {
            StudentModel model = new StudentModel();
            model.ID = 1;
            model.Name = "Meo Meo";
            model.Address = "BT";
            model.Address = "Ho Chi Minh";
            return View(model);
        }

        public IActionResult Details()
        {
            StudentModel model = new StudentModel();
            model.ID = 1;
            model.Name = "Meo Meo";
            model.Address = "BT";
            model.City = "Ho Chi Minh";
            return View(model);
        }
    }
}
