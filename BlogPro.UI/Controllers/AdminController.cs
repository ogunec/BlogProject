using BlogPro.BLL.RepositoryPattern.Interfaces;
using BlogPro.DAL.Context;
using BlogPro.MODEL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlogPro.UI.Controllers
{
	[Authorize(Policy = "AdminPolicy")]
	public class AdminController : Controller
	{
		readonly MyDbContext _db;
		readonly IBlogRepository _repoBlog;
        readonly ICommentRepository _repoComment;
        readonly IAuthorRepository _repoAuthor;
		public AdminController(MyDbContext db, IBlogRepository repoBlog, ICommentRepository repoComment, IAuthorRepository repoAuthor)
		{
			_db = db;
			_repoBlog = repoBlog;
            _repoComment = repoComment;
            _repoAuthor = repoAuthor;
		}
        public IActionResult AdminBlogList()
        {
            IEnumerable<Blog> blogList = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID);
            return View(blogList);
        }
        
        public IActionResult AddNewBlog()
        {
            ViewBag.CategoryList = _db.Categories.ToList();
            ViewBag.AuthorList = _db.Authors.ToList();
            return View();
        }
		[HttpPost]
        public IActionResult AddNewBlog(Blog b)
        {
            _repoBlog.Add(b);
            return RedirectToAction("AdminBlogList", "Admin");
        }

        public IActionResult DeleteBlog(int id)
        {
            _repoBlog.Delete(id);
            return RedirectToAction("AdminBlogList","Admin");
        }
        public IActionResult UpdateBlog(int id)
        {
            ViewBag.CategoryList = _db.Categories.ToList();
            ViewBag.AuthorList = _db.Authors.ToList();
            Blog blog = _repoBlog.GetById(id);
            return View(blog);
        }
        [HttpPost]
        public IActionResult UpdateBlog(Blog blog)
        {
            _repoBlog.Update(blog);
            return RedirectToAction("AdminBlogList","Admin");
        }
        public IActionResult GetCommentsByBlog(int id)
        {
            List<Comment> comments = _repoComment.GetCommentsById(id);
            return View(comments);
        }
        public IActionResult UserBlogList()
        {
            var usermail = HttpContext.User.FindFirst("authorMail").Value.ToString();
            Author loggedAuthor = _repoAuthor.GetByAuthorMail(usermail);
            IEnumerable<Blog> userBlogs = _repoBlog.GetBlogList().Where(x => x.AuthorID == loggedAuthor.AuthorID).OrderByDescending(x => x.BlogID).ToList();
            return View(userBlogs);
        }
    }
}
