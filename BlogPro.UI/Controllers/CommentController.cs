using BlogPro.BLL.RepositoryPattern.Interfaces;
using BlogPro.DAL.Context;
using BlogPro.MODEL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BlogPro.UI.Controllers
{
    public class CommentController : Controller
    {
        MyDbContext _db;
        private readonly ICommentRepository _repoComment;
        private readonly IBlogRepository _repoBlog;
        private readonly IAuthorRepository _repoAuthor;
        public CommentController(ICommentRepository repoComment, MyDbContext db, IBlogRepository repoBlog, IAuthorRepository repoAuthor)
        {
            _db = db;
            _repoComment = repoComment;
            _repoBlog = repoBlog;
            _repoAuthor = repoAuthor;
        }
        public IActionResult CommentList()
        {
            
            return View();
        }
        
        public IActionResult LeaveComment()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult LeaveComment(Comment c)
        {
            _repoComment.Add(c);
            return RedirectToRoute(new {controller = "Blog", action = "BlogDetails", id = c.BlogID });
        }
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult DeleteComment(int id, int blogid)
		{
            _repoComment.Delete(id);
            return RedirectToRoute(new { controller = "Admin", action = "GetCommentsByBlog", id = blogid });
        }
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult AdminCommentList()
		{
            List<Comment> allComments = _repoComment.GetActiveComments().OrderByDescending(x => x.CommentID).ToList();
            return View(allComments);
		}
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult DeleteBlogComments(int id)
		{
            _repoComment.SpecialDelete(id);
            return RedirectToAction("AdminCommentList", "Comment");
		}
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult AdminDeletedComments()
		{
            List<Comment> deletedComments = _repoComment.GetPassiveComments().OrderByDescending(x => x.CommentID).ToList();
            return View(deletedComments);
		}
		[Authorize(Policy = "AdminPolicy")]
        public IActionResult ConfirmBlogComments(int id)
		{
            _repoComment.ConfirmMessage(id);
            return RedirectToAction("AdminDeletedComments", "Comment");
		}

        //For User

        public IActionResult DeleteUserComment(int id, int blogid)
		{
            _repoComment.Delete(id);
            return RedirectToRoute(new { controller = "User", action = "GetCommentsByBlog", id = blogid });
        }
    }
}
