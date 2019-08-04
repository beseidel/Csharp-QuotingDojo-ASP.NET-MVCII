using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quoting()
        {
            List<Dictionary<string, object>> AllQuoting = DbConnector.Query("SELECT * FROM QuoteTable");

            ViewBag.Quote = AllQuoting;
            return View("Result");
        }


        [Route("quotes")]
        [HttpPost]
        public IActionResult Result(Quote submitted_quote)
        {
            if(ModelState.IsValid)
            {
                string query = $"INSERT INTO QuoteTable (Name, QuoteString) VALUES ('{submitted_quote.Name}', '{submitted_quote.QuoteString}')";
                DbConnector.Execute(query);
                return RedirectToAction("Result");
            }
            else
            {
                return View("Index");
            }

        }



    }
}
