using System.Web.Mvc;
using MyTunes.Services;
using System.Collections.Generic;
using MyTunes.Models;
using System;
using MyTunes.Dominio;

namespace MyTunes.Controllers
{
    [Authorize]
    public class PlaylistController : Controller
    {
        // GET: Playlist
        public ActionResult Index()
        {
            var playListService = new PlayListService();

            try
            {
                var playlists = playListService.GetPlayLists(User.Identity.Name);
                ViewBag.Titulo = "My PlayList";
                return View(playlists);
            }
            catch (InvalidOperationException ex)
            {
                ViewBag.Titulo = "Error!!" + ex.Message;
                return View(new List<PlayListViewModel>());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //
        // GET: /Account/Register
        public ActionResult Create()
        {
            return View();
        }        
        
        // POST: /Account/Register
        [HttpPost]
        public JsonResult Create(PlayListViewModel playlist)
        {
            var playlistService = new PlayListService();
            var customerService = new CustomerService();

            var customer = customerService.GetByEmail(User.Identity.Name);

            playlistService.Create(playlist, customer.Id);

            // If we got this far, something failed, redisplay form
            return Json(true);
        }

        public ActionResult Details() {
            return View();
        }
    }
}