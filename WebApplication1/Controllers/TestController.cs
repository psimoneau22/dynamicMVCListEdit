﻿using System;
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
            new TestModel {CreateDate = DateTime.Now, Id =1, TestBool=true, TestString="value1" },
            new TestModel {CreateDate = DateTime.Now.AddDays(-2), Id =2, TestBool=false, TestString="value2" }
        };
        
        [HttpGet]
        public ActionResult Index()
        {
            return View(new TestBaseModel
            {
                Name = "try me",
                Items = items
            });
        }        

        [HttpPost]
        public ActionResult Index(TestBaseModel model)
        {            
            if (Validate(model, ModelState))
            {
                items = model.Items;
                TempData["message"] = "updated";
                return PartialView("_TestForm", new TestBaseModel
                {
                    Name = model.Name,
                    Items = items
                });
            };

            TempData["message"] = "failed";
            return PartialView("_TestForm", model);
        }

        [HttpGet]        
        public ActionResult GetRow()
        {
            return PartialView("_TestRow", new TestModel());
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
