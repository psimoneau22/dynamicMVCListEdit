using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        private static List<TestModel> items = new List<TestModel>{
            new TestModel {CreateDate = DateTime.Now, Id =1, TestBool=true, TestString="value1xxxxxxxxxxx" },
            new TestModel {CreateDate = DateTime.Now.AddDays(-2), Id =2, TestBool=false, TestString="value2xxxxxxxxxx" }
        };

        private static List<TestModel> data = new List<TestModel>{
            new TestModel {CreateDate = DateTime.Now, Id =1, TestBool=true, TestString="value1xxxxxxxxxxxxx" },
            new TestModel {CreateDate = DateTime.Now.AddDays(-2), Id =2, TestBool=false, TestString="value2xxxxxxxxxxxxxxxx" }
        };

        private static List<TestModel2> list = new List<TestModel2> {
            new TestModel2 {Id =1, SomeNumber=345, SomeDescription="descxxxxxxxxxxxxxxxx", Child = new TestModel3 { xxx = "gdf", yyy = "hjfgh" } },
            new TestModel2 {Id =2, SomeNumber=2312, SomeDescription="descxxxxxxxxxxxxxxxx", Child = new TestModel3 { xxx = "gdf", yyy = "hjfgh" } }
        };

        [HttpGet]
        public ActionResult Index()
        {
            return View(new TestBaseModel
            {
                Name = "try me",
                Items = items,
                Data = data,
                List = list
            });
        }        

        [HttpPost]
        public ActionResult Index(TestBaseModel model)
        {            
            if (Validate(model, ModelState))
            {
                items = model.Items;
                data = model.Data;
                list = model.List;

                TempData["message"] = "updated";
                return PartialView("_TestForm", new TestBaseModel
                {
                    Name = model.Name,
                    Items = items,
                    Data = data,
                    List = list
                });
            };

            TempData["message"] = "failed";
            return PartialView("_TestForm", model);
        }

        [HttpGet]        
        public ActionResult GetRow(string collection)
        {
            ViewData["CollectionName"] = collection;

            if (collection == "List")
            {
                return PartialView("_TestRow2", new TestModel2());
            }
            else
            {
                return PartialView("_TestRow", new TestModel());
            }
        }

        private bool Validate(TestBaseModel model, ModelStateDictionary modelState)
        {
            var isValid = true;
            if(model.Name != "try me")
            {
                modelState.AddModelError("_", "say what?  try me");
            }

            return modelState.IsValid && isValid;
        }
    }
}
