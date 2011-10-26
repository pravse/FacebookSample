using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using SampleWebRole.Models;

namespace MvcWebRole1.Controllers
{

    [HandleError]
    public class PuzzleController : Controller
    {

        public IPuzzleService PuzzleService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (PuzzleService == null) { PuzzleService = new PuzzleService(); }

            base.Initialize(requestContext);
        }

        public ActionResult Puzzle()
        {
            ViewData["IsValid"] = false;
            return View();
        }

        [HttpPost]
        public ActionResult Check(PuzzleModel model)
        {
            if (ModelState.IsValid)
            {
                if (PuzzleService.CheckAnswer(model.Answer))
                {
                    model.Response = "Correct!";
                    model.Correct = true;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    model.Response = "Wrong!";
                    model.Correct = false;
                    ModelState.AddModelError("", "Wrong response");
                }
            }

            ViewData["IsValid"] = true;
            // redisplay form
            // return RedirectToAction("Puzzle");
            return View("Puzzle", model);
        }

/****
        [HttpPost]
        public ActionResult Puzzle(PuzzleModel model)
        {
            if (ModelState.IsValid)
            {
                if (PuzzleService.CheckAnswer(model.Answer))
                {
                    model.Response = "Correct!";
                    model.Correct = true;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    model.Response = "Wrong!";
                    model.Correct = false;
                    ModelState.AddModelError("", "Wrong response");
                }
            }

            ViewData["IsValid"] = true;
            // redisplay form
            return View(model);
        }
        ****/
    }
}
