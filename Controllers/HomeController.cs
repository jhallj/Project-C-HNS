using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using TPLOCAL1.Models;
using System.Collections.Generic;

namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidationForm(FormModel model)
        {
            if (ModelState.IsValid)
            {
                return View("ValidationPage", model);
            }
            return View("Form", model);
        }

        public IActionResult AvisList()
        {
            string xmlFilePath = Path.Combine(_hostingEnvironment.ContentRootPath, "XmlFile", "DataAvis.xml");

            OpinionReader reader = new OpinionReader();
            List<Opinion> model = reader.GetOpinions(xmlFilePath);
            return View("AvisList", model);
        }
    }
}