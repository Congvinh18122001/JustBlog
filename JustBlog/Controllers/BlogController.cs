using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using JustBlog.core;
using JustBlog.Models;

namespace JustBlog.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        private readonly BlogRepository blog = new BlogRepository();

        public ActionResult Posts(int page = 1)
        {
            var ListViewModel = new ListViewModel(blog,page);
            return View("List",ListViewModel);
        }
        public ActionResult List()
        {

            return View();
        }
        public ActionResult Category(int? id,int page = 1)
        {
            if (id.HasValue)
            {
                var ViewModel = new ListViewModel(blog,"Category", id.Value, page);
                ViewBag.Title = string.Format($"Lastest posts on category{ViewModel.Category.Name}");
                return View("List",ViewModel);

            }
            return RedirectToAction("Posts");
        }
        public ActionResult Tag(int? id , int page=1)
        {
            if (id.HasValue)
            {
                var ViewModel = new ListViewModel(blog, "Tag", id.Value, page);
                ViewBag.Title = string.Format($"Lastest posts on Tag {ViewModel.Tag.Name}");
                return View("List", ViewModel);
            }
            return RedirectToAction("Posts");
        }
        public ActionResult Search(string search, int page = 1)
        {
                ViewBag.Title = string.Format($"Lastest posts found for search text \" {search}\"");
            var ViewModel = new ListViewModel(blog,search,page);
            return View("List",ViewModel);


        }
        public ActionResult Post(int? id)
        {
            if (id.HasValue)
            {
                var post = blog.Post(id.Value);
                if (post != null)
                {
                    return View(post);
                }
            }
            return RedirectToAction("Posts");
        }
        [ChildActionOnly]
        public PartialViewResult Sidebars()
        {
            var widget = new WidgetViewModel(blog);
            return PartialView("_sidebars",widget);
        }
    }
}