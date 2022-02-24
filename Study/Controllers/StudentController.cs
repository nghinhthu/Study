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
        List<StudentModel> studentModels = new List<StudentModel>();

        public IActionResult Index()
        {
            studentModels.Add(new StudentModel { ID = 1, Name = "Nghinh Thu", Address = "Binh Tan", City = "Ho Chi Minh" });
            return View(studentModels);
        }

        public IActionResult Create()
        {
            StudentModel student = new StudentModel();
            return View(student);
        }

        [HttpPost]
        public IActionResult Create(StudentModel student)
        {
            studentModels.Add(student);
            return View("Index");
        }

        public IActionResult Edit(int id)
        {
            StudentModel model = new StudentModel();
            model.ID = 1;
            model.Name = "Nghinh Thu";
            model.Address = "BT";
            model.Address = "Ho Chi Minh";
            return View(model);
        }

        public IActionResult Details()
        {
            StudentModel model = new StudentModel();
            model.ID = 1;
            model.Name = "Nghinh Thu";
            model.Address = "BT";
            model.City = "Ho Chi Minh";
            return View(model);
        }
    }
}
