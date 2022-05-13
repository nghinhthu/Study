using Microsoft.AspNetCore.Mvc;
using Study.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Study.Controllers
{
    public class ClassController : Controller
    {
        List<ClassModel> classList;

        public ClassController()
        {
            classList = new List<ClassModel>()
            {
                new ClassModel(){ ID = 1, ClassName = "Anh Van", Students = new List<StudentModel>()
                {
                    new StudentModel(){ID = 1, Name = "Bak Bak", Address = "Binh Tan", City = "Ho Chi Minh" },
                    new StudentModel(){ID = 2, Name = "Meo Meo", Address = "Binh Tan", City = "Ho Chi Minh" },

                }
                },
                new ClassModel(){ ID = 2, ClassName = "Tin Hoc", Students = new List<StudentModel>()
                {
                    new StudentModel(){ID = 1, Name = "Bak Bak", Address = "Binh Tan", City = "Ho Chi Minh" },
                    new StudentModel(){ID = 2, Name = "Meo Meo", Address = "Binh Tan", City = "Ho Chi Minh" },

                }
                },
            };
        }
        public IActionResult Index()
        {
            return View(classList);
        }
        public ActionResult Details()
        {
            ClassModel model = new ClassModel();
            model.ID = 1;
            model.ClassName = "Anh Van";
            model.Students = new List<StudentModel>() {
                new StudentModel()
                    {
                        ID = 1,
                        Name = "Chichay",
                        Address = "BT",
                        City = "Ho Chi Minh"
                    },
                new StudentModel()
                    {
                        ID = 2,
                        Name = "Joaquin",
                        Address = "BT",
                        City = "Ho Chi Minh"
                    },
            };
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            ClassModel model = new ClassModel();
            model.ID = 1;
            model.ClassName = "Anh Van";
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            ClassModel model = new ClassModel();
            model.ID = 1;
            model.ClassName = "Anh Van";
            return View(model);
        }

        public IActionResult Create()
        {
            ClassModel model = new ClassModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ClassModel classModel)
        {
            ClassModel model = new ClassModel();
            model.ID = classModel.ID;
            model.ClassName = classModel.ClassName;
            model.Students = classModel.Students;
            return RedirectToAction("Index");
        }
    }
}
