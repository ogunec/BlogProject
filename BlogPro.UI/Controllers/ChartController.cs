using BlogPro.BLL.RepositoryPattern.Interfaces;
using BlogPro.DAL.Context;
using BlogPro.MODEL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlogPro.UI.Controllers
{
    public class ChartController : Controller
    {
        readonly MyDbContext _db;
        readonly ICategoryRepository _repoCategory;
        readonly IBlogRepository _repoBlog;
        readonly IAuthorRepository _repoAuthor;
        public ChartController(MyDbContext db, ICategoryRepository repoCategory, IBlogRepository repoBlog, IAuthorRepository repoAuthor)
        {
            _db = db;
            _repoCategory = repoCategory;
            _repoBlog = repoBlog;
            _repoAuthor = repoAuthor;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult VisualizeCategoryResult()
		{
            return Json(CategoryChart());
		}
        public List<Chart> CategoryChart()
		{
            List<Category> categories = _repoCategory.GetCategories();
            List<Chart> chart1 = new List<Chart>();
			for (int i = 1; i <= categories.Count; i++)
			{
                chart1.Add(new Chart()
                {
                    CategoryName = _repoCategory.GetCategories().Where(x => x.CategoryID == i).Select(x => x.CategoryName).FirstOrDefault(),
                    BlogCount = _repoBlog.GetBlogList().Where(x => x.CategoryID ==i).Count(),
                });
            }
            return chart1;
        }
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Chart1()
		{
            return View();
		}
        public IActionResult VisualizeAuthorResult()
        {
            return Json(AuthorChart());
        }
        public List<Chart> AuthorChart()
        {
            List<Author> authors = _repoAuthor.GetAll();
            List<Chart> chart2 = new List<Chart>();
            for (int i = 1; i <= authors.Count; i++)
            {
                chart2.Add(new Chart()
                {
                    AuthorName = _repoAuthor.GetAll().Where(x => x.AuthorID == i).Select(x => x.AuthorName).FirstOrDefault(),
                    BlogCount = _repoBlog.GetBlogList().Where(x => x.AuthorID == i).Count(),
                });
            }
            return chart2;
        }
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Chart2()
		{
            return View();
		}

        //For User

        
        [Authorize(Policy = "UserPolicy")]
        public IActionResult Chart3()
        {
            var usermail = HttpContext.User.FindFirst("authorMail").Value.ToString();
            Author loggedAuthor = _repoAuthor.GetByAuthorMail(usermail);
            ViewData["user"] = loggedAuthor;
            return View();
        }
        
        [Authorize(Policy = "UserPolicy")]
        public IActionResult Chart4()
        {
            var usermail = HttpContext.User.FindFirst("authorMail").Value.ToString();
            Author loggedAuthor = _repoAuthor.GetByAuthorMail(usermail);
            ViewData["user"] = loggedAuthor;
            return View();
        }
    }
}
