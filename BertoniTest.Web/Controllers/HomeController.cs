using Bertoni.Domain.Abstraction;
using Bertoni.Domain.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BertoniTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private IService<Album> svcAlbum;
        private IService<Photo> svcPhoto;

        public HomeController(IService<Album> serviceAlbum, IService<Photo> servicePhoto)
        {
            svcAlbum = serviceAlbum;
            svcPhoto = servicePhoto;
        }

        public PartialViewResult Photos(int albums)
        {
            var _photos = svcPhoto.QueryBy(p => p.AlbumId == albums).ToList();
            return PartialView(_photos);
        }

        public ActionResult Index()
        {
            var _albums = svcAlbum.GetAll().OrderBy(a => a.Title).ToList();
            return View(_albums);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Prueba técnica para Bertoni Solutions.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}