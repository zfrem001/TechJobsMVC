using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        //  [HttpGet]
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        //  [HttpPost]
        public IActionResult Results(string searchType, string searchTerm) //under search i should find something based on category and also based on all.
        {
            ViewBag.columns = ListController.columnChoices;
            if (searchType.Equals("all") && string.IsNullOrEmpty(searchTerm))
            {
                ViewBag.jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
                return View("Index");
            }

            else if (searchType.Equals("all"))
            {
                ViewBag.jobs = JobData.FindByValue(searchTerm);
                ViewBag.title = "All Values";
                return View("Index");


            }
            else if (!string.IsNullOrEmpty(searchTerm))
            {
                ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);  //if im finding by a criteria, it should show things based on that
                ViewBag.column = searchType;
                ViewBag.title = "All " + ListController.columnChoices[searchType] + " Values";
                return View("Index");
            }
            return View("Index");


        }

    }
}