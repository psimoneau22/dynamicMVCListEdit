using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            Menu root =
                new Menu("Root", "root",
                    new Menu("Menu1", "url1"),
                    new Menu("Menu2", "url2"),
                    new Menu("Menu3", "url3"),
                    new Menu("Menu4", "url4",
                        new Menu("Menu5", "url5"),
                        new Menu("Menu6", "url6",
                            new Menu("Menu36", "url6"),
                            new Menu("Menu3", "url3"),
                            new Menu("Menu4", "url4",
                                new Menu("Menu5", "url5"),
                                new Menu("Menu6", "url6",
                                    new Menu("Menu36", "url6"),
                                    new Menu("Menu37", "url7")
                                ),
                                new Menu("Menu7", "url7")
                            ),
                            new Menu("Menu37", "url7")
                        ),
                        new Menu("Menu7", "url7")
                    ),
                    new Menu("Menu8", "url8"),
                    new Menu("Menu9", "url9",
                        new Menu("Menu10", "url10"),
                        new Menu("Menu11", "url11")
                    ),
                    new Menu("Menu12", "url12")
                );

            return View(root);
        }
    }
}