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

        public IActionResult Index()
        {
            List<ClassModel> classModels = new List<ClassModel>(); ;

            classModels.Add(new ClassModel
            {
                ID = 1,
                ClassName = "Anh Van",
            });

            classModels.Add(new ClassModel
            {
                ID = 2,
                ClassName = "Tin Hoc",
                Students = new List<StudentModel>()
                {
                    new StudentModel()
                    {
                        ID = 1,
                        Name = "Nghinh Thu",
                        Address = "BT",
                        City = "Ho Chi Minh"
                    }
                }

            });


            return View(classModels);
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

        public IActionResult Edit(int ID)
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
            return View("Index");
        }
    }
}
