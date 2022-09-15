using BlogPro.BLL.RepositoryPattern.Interfaces;
using BlogPro.MODEL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogPro.UI.Controllers
{
    public class AboutController : Controller
    {
        readonly IAuthorRepository _repoAuthor;
        readonly IAboutRepository _repoAbout;
        public AboutController(IAboutRepository repoAbout, IAuthorRepository repoAuthor)
        {
            _repoAuthor = repoAuthor;
            _repoAbout = repoAbout;
        }
        public IActionResult Index()
        {
            IEnumerable<Author> ourAuthors = _repoAuthor.GetAuthors();
            IEnumerable<About> aboutInfo = _repoAbout.GetAboutList();
            (IEnumerable<Author>, IEnumerable<About>) infopage = (ourAuthors, aboutInfo);
            return View(infopage);
        }
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult AdminAboutList()
		{
            IEnumerable<About> aboutList = _repoAbout.GetAboutList();
            return View(aboutList);
		}
        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            _repoAbout.Update(about);
            return RedirectToAction("AdminAboutList", "About");
        }

    }
}
