using BlogPro.BLL.RepositoryPattern.Interfaces;
using BlogPro.DAL.Context;
using BlogPro.MODEL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogPro.UI.Controllers
{
    public class SubscribeMailController : Controller
    {
        MyDbContext _db;
        ISubscribeMailRepository _repoMail;
        public SubscribeMailController(ISubscribeMailRepository repoMail, MyDbContext db)
        {
            _db = db;
            _repoMail = repoMail;
        }
        [HttpGet]
        public IActionResult AddMail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMail(SubscribeMail p)
        {
            _repoMail.AddMails(p);
            _repoMail.Save();
            return RedirectToAction("Index","Blog");
        }
    }
}
