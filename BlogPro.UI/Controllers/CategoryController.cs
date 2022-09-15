using BlogPro.BLL.RepositoryPattern.Interfaces;
using BlogPro.MODEL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace BlogPro.UI.Controllers
{
    public class CategoryController : Controller
    {
        readonly ICategoryRepository _repoCategory;
        readonly IBlogRepository _repoBlog;
        readonly IAuthorRepository _repoAuthor;
        public CategoryController(IBlogRepository repoBlog, ICategoryRepository repoCategory, IAuthorRepository repoAuthor)
        {
            _repoCategory = repoCategory;
            _repoBlog = repoBlog;
            _repoAuthor = repoAuthor;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BlogByCategory(int id, int page = 1)
        {
            IEnumerable<Blog> selectedCategory = _repoBlog.GetBlogList().Where(x => x.CategoryID == id).OrderByDescending(x => x.BlogID).ToPagedList(page, 9);

            return View(selectedCategory);
        }
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult AdminCategoryList()
		{
            List<Category> categoryList = _repoCategory.GetCategories();
            Blog category1 = _repoBlog.GetBlog1();
            Blog category2 = _repoBlog.GetBlog2();
            Blog category3 = _repoBlog.GetBlog3();
            Blog category4 = _repoBlog.GetBlog4();
            Blog category5 = _repoBlog.GetBlog5();
			ViewData["lastBlog1"] = category1;
			ViewData["lastBlog2"] = category2;
			ViewData["lastBlog3"] = category3;
			ViewData["lastBlog4"] = category4;
			ViewData["lastBlog5"] = category5;
            return View(categoryList);
		}
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult AddCategory()
		{
            return View();
		}
		[HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _repoCategory.Add(category);
            return RedirectToAction("AdminCategoryList", "Category");
        }
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult EditCategory(int id)
        {
            Category category = _repoCategory.GetById(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            _repoCategory.Update(category);
            return RedirectToAction("AdminCategoryList", "Category");
        }
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult DeleteCategory(int id)
		{
            _repoCategory.SpecialDelete(id);
            return RedirectToAction("AdminCategoryList", "Category");
		}
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult ConfirmCategory(int id)
		{
            _repoCategory.ConfirmCategory(id);
            return RedirectToAction("AdminCategoryList", "Category");
		}
    }
}
