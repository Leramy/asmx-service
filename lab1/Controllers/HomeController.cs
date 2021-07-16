using lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace lab1.Controllers
{
    public class HomeController : Controller
    {
        private static HockeyPlayerParams hockeyPlayerParams;
        HockeyPlayerContext db;
        public int k = 0;

        BasicHttpsBinding binding = new BasicHttpsBinding();


        private static MyService.WebService1SoapClient client;

        public HomeController(HockeyPlayerContext context)
        {
            //db = context;
           
        }
        [HttpGet]
        public IActionResult Index()
        {
            HockeyPlayerParams hpp = new HockeyPlayerParams
            {
                positions = new SelecList(new List<string>()
                {
                    "",
                    "C",
                    "D",
                    "G",
                    "LW",
                    "RW"
                })
            };
            return View(hpp);
        }
        [HttpPost]
        public string Index(HockeyPlayerParams @params)
        {
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.MaxBufferSize = int.MaxValue;
            client = new MyService.WebService1SoapClient(binding,new EndpointAddress("https://localhost:44319/WebService1.asmx"));
            MyService.HockeyPlayerParams hp = new MyService.HockeyPlayerParams();
            hp.position = @params.position;
            hp.birthdayFrom = @params.birthdayFrom;
            hp.birthdayTo = @params.birthdayTo;
            hp.weightFrom = @params.weightFrom;
            hp.weightTo = @params.weightTo;
            hp.heightFrom = @params.heightFrom;
            hp.heightTo = @params.heightTo;
            client.CreateParams(hp);
            return "Done!";
        }

        
        [HttpGet]
        public IActionResult Table()
        {
            return View(client.SelectPlayers().ToList());
        }
        
        [HttpGet]
        public IActionResult Photo(string ID)
        {
            Photo p = new Photo();
            p.Name = ID.ToString();
            p.Data = client.Image(ID);
            return View(p);
        }
        public ActionResult GetImage(string ID)
        {
            return File(client.Image(ID), "image/jpg");
        }
    }
}

