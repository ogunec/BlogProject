using BlogPro.BLL.RepositoryPattern.Interfaces;
using BlogPro.MODEL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogPro.UI.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _repoAuthor;
		public AuthorController(IAuthorRepository repoAuthor)
		{
            _repoAuthor = repoAuthor;
		}
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult AuthorList()
		{
            List<Author> blogAuthors = _repoAuthor.GetAll(); 
            return View(blogAuthors);
		}
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult AddAuthor()
		{
            return View();
		}
		[HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }    
            _repoAuthor.Add(author);
            return RedirectToAction("AuthorList", "Author");
        }
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult EditAuthor(int id)
		{
            Author author = _repoAuthor.GetById(id);
            return View(author);
		}
		[HttpPost]
        public IActionResult EditAuthor(Author author)
        {
            _repoAuthor.Update(author);
            return RedirectToAction("AuthorList", "Author");
        }

    }
}
