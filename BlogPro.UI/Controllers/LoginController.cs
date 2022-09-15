using BlogPro.BLL.RepositoryPattern.Interfaces;
using BlogPro.DAL.Context;
using BlogPro.MODEL.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogPro.UI.Controllers
{
	public class LoginController : Controller
	{
		readonly MyDbContext _db;
		readonly IAuthorRepository _repoAuthor;
		public LoginController(MyDbContext db, IAuthorRepository repoAuthor)
		{
			_db = db;
			_repoAuthor = repoAuthor;
		}
		public IActionResult UserLogin()
		{
			
			if (User.Identity.IsAuthenticated)
			{
				string role = HttpContext.User.FindFirst("role").Value.ToString();
				if (role == "Admin")
				{
					return RedirectToAction("AdminBlogList", "Admin");
				}
				else if (role == "User")
				{
					return RedirectToAction("UserBlogList", "User");
				}
			}
			return View();			
		}
		[HttpPost]
		public async Task<IActionResult> UserLogin(Author author)
		{
			if (_repoAuthor.Any(x => x.AuthorMail == author.AuthorMail && x.Status != false))
			{
				Author selectedAuthor = _repoAuthor.Default(x => x.AuthorMail == author.AuthorMail && x.Status != false);
				bool isValid = selectedAuthor.Password == author.Password ? true : false;
				if (isValid)
				{
					List<Claim> claims = new List<Claim>()
					{
						new Claim("authorMail",selectedAuthor.AuthorMail),
						new Claim("userID",selectedAuthor.AuthorID.ToString()),
						new Claim("role",selectedAuthor.Role)
					};
					ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					ClaimsPrincipal principal = new ClaimsPrincipal(identity);
					await HttpContext.SignInAsync(principal);
					if (selectedAuthor.Role == "Admin")
					{
						return RedirectToAction("AdminBlogList", "Admin");
					}
					else if(selectedAuthor.Role == "User")
					{
						return RedirectToAction("UserBlogList", "User");
					}
				}
			}
			return View();
		}

		public async Task<IActionResult> UserLogOut()
		{
			await HttpContext.SignOutAsync();
			return RedirectToAction("UserLogin", "Login");
		}
	}
}
