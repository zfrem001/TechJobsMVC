using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        {
            List<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);

            ViewBag.columns = ListController.columnChoices;
            ViewBag.fields = ListController.jobFields;
            ViewBag.title = "";
            ViewBag.columnChoice = searchType;
            ViewBag.jobs = jobs;
                        
            return View("Index");

    }
}
