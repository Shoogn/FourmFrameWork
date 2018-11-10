using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.AbstractLayer;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class JobsController : Controller
    {
        private IJobRepository _repository;
        public JobsController(IJobRepository repository)
        {
            this._repository = repository;
        }
        //
        // GET: /Jobs/

        public ActionResult Index()
        {
            return View(_repository.GetAllJobs.Where(j => j.IsActive == true));
        }

        public ActionResult JobDetails(int jobID)
        {
            Job job = _repository.GetJob(jobID);
            if (job != null)
            {
                return View(job);
            }
            return View("Error");
        }

        public ActionResult ManageJobs()
        {
            var job = _repository.GetAllJobs;
            return View(job);
        }

        [HttpGet]
        public ActionResult CreateJob()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateJob(Job job)
        {
            if (Request.IsAjaxRequest())
            {
                _repository.SaveJob(job);
                return PartialView("_Message");
            }
            return View();
        }

        [HttpPost]
        public ActionResult RemoveJob(int jobID)
        {
            Job job = _repository.DeleteJob(jobID);
            if (job != null)
            {
                TempData["message"] = String.Format("{0} is deleted Successfully", job.Name);
                return RedirectToAction("ManageJobs");
            }
            return View();
        }

        [HttpPost]
        public ActionResult CloseJob(int jobID)
        {
            Job job = _repository.CloseJob(jobID);
             if (job != null)
            {
                TempData["message"] = String.Format("{0} is closed Successfully", job.Name);
                return RedirectToAction("ManageJobs");
            }
            return View();
        }
        
        [ChildActionOnly]
        public ActionResult GetLastestjobs()
        {
            var jobs = _repository.GetAllJobs.Where(j => j.IsActive == true).OrderBy(j => j.Name).Take(5);
            return PartialView("_LatestJobs", jobs);
        }
    }
}
