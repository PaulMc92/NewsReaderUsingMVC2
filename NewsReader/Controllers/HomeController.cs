using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using NewsReader.Models;
using PagedList;
using NewsApp.Utils;

namespace NewsReader.Controllers
{
    public class HomeController : Controller
    {
        private string url = "https://newsapi.org/v2/top-headlines?" +
                              "sources=bbc-news&" +
                              "apiKey=ac1bcac1b94d47b5933fb9430ef4e254";
        

        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(ViewBag.NameSortParm) && sortOrder != "name_asc" ? "name_asc" : "name_desc";
            ViewBag.DateSortParm = String.IsNullOrEmpty(ViewBag.DateSortParm) && sortOrder != "date_desc" ? "date_desc" : "date_asc";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(url);
                JsonModels root = JsonConvert.DeserializeObject<JsonModels>(json);

                if (!String.IsNullOrEmpty(searchString))
                {
                    root.Articles = root.Articles.Where(s => s.Author.Contains(searchString)
                                           || s.Description.Contains(searchString)
                                           || s.Title.Contains(searchString));
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        root.Articles = root.Articles.OrderByDescending(s => s.Title).ToList();
                        break;
                    case "name_asc":
                        root.Articles = root.Articles.OrderBy(s => s.Title).ToList();
                        break;
                    case "date_desc":
                        root.Articles = root.Articles.OrderByDescending(s => s.PublishedAt).ToList();
                        break;
                    case "date_asc":
                        root.Articles = root.Articles.OrderBy(s => s.PublishedAt).ToList();
                        break;
                }

                int pageSize = 3;
                int pageNumber = (page ?? 1);
                return View(root.Articles.ToPagedList(pageNumber, pageSize));
            }
        }

        public ActionResult ViewDetails(string title)
        {
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(url);
                var root = JsonConvert.DeserializeObject<JsonModels>(json).Articles.Where(x => x.Title == title);

                ArticleModels temp = Helpers.JsonToArticleModel(root, true);

                return PartialView("_ArticlePartial", temp);
            }
        }
        [HttpPost]
        public ActionResult Details()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}