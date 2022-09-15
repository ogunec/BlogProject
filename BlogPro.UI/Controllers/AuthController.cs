using BlogPro.BLL.RepositoryPattern.Interfaces;
using BlogPro.DAL.Context;
using BlogPro.MODEL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogPro.UI.Controllers
{
	public class AuthController : Controller
	{
		private readonly IAuthorRepository _repoAuthor;
		private readonly MyDbContext _db;
		public AuthController(MyDbContext db, IAuthorRepository repoAuthor)
		{
			_db = db;
			_repoAuthor = repoAuthor;
		}
		public IActionResult Index()
		{
			List<Author> authors = _repoAuthor.GetAll();
			return View(authors);
		}
		public IActionResult MakeAdmin(int id)
		{
			_repoAuthor.ChangeToAdmin(id);
			return RedirectToAction("Index","Auth");
		}
		public IActionResult MakeUser(int id)
		{
			_repoAuthor.ChangeToUser(id);
			return RedirectToAction("UserLogOut", "Login");
		}
	}
}
