using BlogPro.MODEL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BlogPro.DAL.Context;
using BlogPro.BLL.RepositoryPattern.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BlogPro.UI.Controllers
{
	[Authorize(Policy = "UserPolicy")]
	public class UserController : Controller
	{
		readonly MyDbContext _db;
		readonly IAuthorRepository _repoAuthor;
		readonly IBlogRepository _repoBlog;
		readonly ICommentRepository _repoComment;
		public UserController(MyDbContext db, IAuthorRepository repoAuthor, IBlogRepository repoBlog, ICommentRepository repoComment)
		{
			_db = db;
			_repoAuthor = repoAuthor;
			_repoBlog = repoBlog;
			_repoComment = repoComment;
		}
		
		public IActionResult UserProfile()
		{
			var usermail = HttpContext.User.FindFirst("authorMail").Value.ToString();
			Author loggedAuthor = _repoAuthor.GetByAuthorMail(usermail);
			ViewData["user"] = loggedAuthor;
			return View(loggedAuthor);
		}
		public IActionResult UserUpdate(Author author)
		{
			_repoAuthor.Update(author);
			return RedirectToAction("UserProfile", "User");
		}
		public IActionResult UserBlogList()
		{
			var usermail = HttpContext.User.FindFirst("authorMail").Value.ToString();
			Author loggedAuthor = _repoAuthor.GetByAuthorMail(usermail);
			ViewData["user"] = loggedAuthor;
			IEnumerable<Blog> userBlogs = _repoBlog.GetBlogList().Where(x => x.AuthorID == loggedAuthor.AuthorID).OrderByDescending(x => x.BlogID).ToList();
			return View(userBlogs);
		}
		public IActionResult NewBlog()
		{
			var usermail = HttpContext.User.FindFirst("authorMail").Value.ToString();
			Author loggedAuthor = _repoAuthor.GetByAuthorMail(usermail);
			ViewData["user"] = loggedAuthor;
			ViewBag.CategoryList = _db.Categories.ToList();
			ViewBag.AuthorID = loggedAuthor.AuthorID;
			return View();
		}
		[HttpPost]
		public IActionResult NewBlog(Blog blog)
		{
			var usermail = HttpContext.User.FindFirst("authorMail").Value.ToString();
			Author loggedAuthor = _repoAuthor.GetByAuthorMail(usermail);
			ViewData["user"] = loggedAuthor;
			_repoBlog.Add(blog);
			return RedirectToAction("UserBlogList", "User");
		}
		public IActionResult DeleteBlog(int id)
		{
			_repoBlog.Delete(id);
			return RedirectToAction("UserBlogList", "User");
		}
		public IActionResult UpdateBlog(int id)
		{
			var usermail = HttpContext.User.FindFirst("authorMail").Value.ToString();
			Author loggedAuthor = _repoAuthor.GetByAuthorMail(usermail);
			ViewData["user"] = loggedAuthor;
			ViewBag.CategoryList = _db.Categories.ToList();
			ViewBag.AuthorID = loggedAuthor.AuthorID;
			Blog blog = _repoBlog.GetById(id);
			return View(blog);
		}
		[HttpPost]
		public IActionResult UpdateBlog(Blog blog)
		{
			_repoBlog.Update(blog);
			return RedirectToAction("UserBlogList", "User");
		}
		public IActionResult GetCommentsByBlog(int id)
		{
			var usermail = HttpContext.User.FindFirst("authorMail").Value.ToString();
			Author loggedAuthor = _repoAuthor.GetByAuthorMail(usermail);
			ViewData["user"] = loggedAuthor;
			List<Comment> comments = _repoComment.GetCommentsById(id);
			return View(comments);
		}
	}
}
