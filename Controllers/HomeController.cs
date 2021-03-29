using FinalMidterm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FinalMidterm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private QuotesDBContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, QuotesDBContext con)
        {
            _logger = logger;
            context = con;
        }

        public IActionResult Index()
        {
            return View(context.Quotes);
        }

        [HttpGet("AddQuote")]
        public IActionResult AddQuote()
        {
            return View();
        }

        [HttpPost("AddQuote")]
        public IActionResult AddQuote(QuoteResponse quoteInfo)
        {
            if (ModelState.IsValid)
            {
                context.Quotes.Add(quoteInfo);

                context.SaveChanges();

                return View("Confirmation", quoteInfo);
            }
            else
            {
                //return back to the same page if not all required inputs are enetered
                return View();
            }
        }

        //go to the edit quote page for the movie with the id that we pass in
        [HttpPost]
        public IActionResult EditQuote(int quoteid)
        {
            var EditedQuote = context.Quotes.Where(m => m.QuoteID == quoteid).FirstOrDefault();

            return View(EditedQuote);
        }

        //save the changes to the database after they've been updated
        [HttpPost]
        public IActionResult SaveChanges(QuoteResponse q, int quoteid)
        {
            //match up the quote ids 
            var UpdatedQuote = context.Quotes.Where(q => q.QuoteID == quoteid).FirstOrDefault();

            //makes sure the input is valid
            if (ModelState.IsValid)
            {

                UpdatedQuote.Quote = q.Quote;
                UpdatedQuote.Author = q.Author;
                UpdatedQuote.Date = q.Date;
                UpdatedQuote.Subject = q.Subject;
                UpdatedQuote.Citation = q.Citation;



                context.SaveChanges();


                return View("Index", context.Quotes);
            }


            return View("EditQuote", q);
        }

        //delete the entry by matching up the quote ids and then saving the changes to the database
        [HttpPost]
        public IActionResult DeleteQuote(int quoteid)
        {

            var QuoteToDelete = context.Quotes.Where(q => q.QuoteID == quoteid).FirstOrDefault();

            context.Remove(QuoteToDelete);
            context.SaveChanges();

            return View("Index", context.Quotes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
