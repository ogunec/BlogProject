using BlogPro.BLL.RepositoryPattern.Interfaces;
using BlogPro.DAL.Context;
using BlogPro.MODEL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlogPro.UI.Controllers
{
    public class ContactController : Controller
    {
        readonly MyDbContext _db;
        readonly IContactRepository _repoContact;
        public ContactController(IContactRepository repoContact, MyDbContext db)
        {
            _db = db;
            _repoContact = repoContact;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Contact c)
        {
            _repoContact.Add(c);
            return RedirectToAction("Index", "Contact");
        }
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult MailBox()
		{
            List<Contact> allMessages = _repoContact.GetMessages();
            return View(allMessages);
		}
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult MessageDetails(int id)
		{
            Contact selectedMessage = _repoContact.GetById(id);
            return View(selectedMessage);
		}

    }
}
