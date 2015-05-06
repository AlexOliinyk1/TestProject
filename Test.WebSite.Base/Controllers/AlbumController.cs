using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Test.WebSite.Base.ViewModels;
using Test.WebSite.Domain.EntityModel;
using Test.WebSite.Service.Service;

namespace Test.WebSite.Base.Controllers
{
    public class AlbumController : Controller
    {
        IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public ActionResult Index()
        {
            var model = new AlbumViewModel { Albums = _albumService.GetAll() };

            return PartialView("_Index", model);
        }

        [ChildActionOnly]
        public ActionResult List()
        {
            var model = new AlbumViewModel { Albums = _albumService.GetAll() };

            return PartialView("_List", model);
        }

        public ActionResult Create()
        {
            var model = new AlbumViewModel { Year = DateTime.Now };
            return PartialView("_Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlbumViewModel album)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<AlbumViewModel, Album>(album);
                _albumService.Create(model);

                string url = Url.Action("Index", "Album", null);
                return Json(new { success = true, url = url });
            }

            return PartialView("_Create", album);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Album album = _albumService.GetById(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }

            var model = Mapper.Map<Album, AlbumViewModel>(album);
            return PartialView("_Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AlbumViewModel album)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<AlbumViewModel, Album>(album);
                _albumService.Update(model);
                string url = Url.Action("Index", "Album", null);
                return Json(new { success = true, url = url });
            }

            return PartialView("_Edit", album);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Album album = _albumService.GetById(id.Value);

            if (album == null)
            {
                return HttpNotFound();
            }
            var model = Mapper.Map<Album, AlbumViewModel>(album);
            return PartialView("_Delete", model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album address = _albumService.GetById(id);
            _albumService.Delete(address);

            string url = Url.Action("Index", "Album", null);
            return Json(new { success = true, url = url });
        }
    }
}