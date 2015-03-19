using MyTunes.Repository;
using MyTunes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTunes.Controllers
{
    public class TrackController : Controller
    {
        // GET: Track
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetTracks(string name)
        {
            using (TrackService _trackService = new TrackService())
            {
                return Json(_trackService.GetAutofiltered(name), JsonRequestBehavior.AllowGet);
            }
        }
    }
}