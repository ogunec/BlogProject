using BlogPro.BLL.RepositoryPattern.Concrete;
using BlogPro.BLL.RepositoryPattern.Interfaces;
using BlogPro.DAL.Context;
using BlogPro.MODEL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace BlogPro.UI.Controllers
{
    public class BlogController : Controller
    {
        ICommentRepository _repoComment;
        IBlogRepository _repoBlog;
        MyDbContext _db;
        public BlogController(MyDbContext db, IBlogRepository repoBlog, ICommentRepository repoComment)
        {
            _db = db;
            _repoBlog = repoBlog;
            _repoComment = repoComment;
        }
        public IActionResult Index(int page = 1)
        {
            IEnumerable<Blog> recentPost = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).ToPagedList(page, 9);
            Post featuredPost = new Post();
            
            //Post 1 Sol-Üst Kısım Yazılım Kategorisi
            featuredPost.postTitle1 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 5).Select(x => x.BlogTitle).FirstOrDefault().ToString();
            featuredPost.postImage1 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 5).Select(x => x.BlogImage).FirstOrDefault().ToString();
            featuredPost.postDate1 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 5).Select(x => x.BlogDate).FirstOrDefault().ToShortDateString();
            featuredPost.id1 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 5).Select(x => x.BlogID).FirstOrDefault();

            //Post 2 Sol-Alt Kısım Sinema Kategorisi
            featuredPost.postTitle2 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 2).Select(x => x.BlogTitle).FirstOrDefault().ToString();
            featuredPost.postImage2 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 2).Select(x => x.BlogImage).FirstOrDefault().ToString();
            featuredPost.postDate2 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 2).Select(x => x.BlogDate).FirstOrDefault().ToShortDateString();
            featuredPost.id2 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 2).Select(x => x.BlogID).FirstOrDefault();

            //Post 3 Orta Kısım Teknoloji Kategorisi
            featuredPost.postTitle3 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 1).Select(x => x.BlogTitle).FirstOrDefault().ToString();
            featuredPost.postImage3 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 1).Select(x => x.BlogImage).FirstOrDefault().ToString();
            featuredPost.postDate3 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 1).Select(x => x.BlogDate).FirstOrDefault().ToShortDateString();
            featuredPost.id3 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 1).Select(x => x.BlogID).FirstOrDefault();

            //Post 4 Sağ-Üst Kısım Seyahat Kategorisi
            featuredPost.postTitle4 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 4).Select(x => x.BlogTitle).FirstOrDefault().ToString();
            featuredPost.postImage4 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 4).Select(x => x.BlogImage).FirstOrDefault().ToString();
            featuredPost.postDate4 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 4).Select(x => x.BlogDate).FirstOrDefault().ToShortDateString();
            featuredPost.id4 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 4).Select(x => x.BlogID).FirstOrDefault();

            //Post 5 Sağ-Alt Kısım Dizi Kategorisi
            featuredPost.postTitle5 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 3).Select(x => x.BlogTitle).FirstOrDefault().ToString();
            featuredPost.postImage5 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 3).Select(x => x.BlogImage).FirstOrDefault().ToString();
            featuredPost.postDate5 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 3).Select(x => x.BlogDate).FirstOrDefault().ToShortDateString();
            featuredPost.id5 = _repoBlog.GetBlogList().OrderByDescending(x => x.BlogID).Where(x => x.CategoryID == 3).Select(x => x.BlogID).FirstOrDefault();


            (IEnumerable<Blog>,Post) recentAndFeaturedPost = (recentPost, featuredPost);
            return View(recentAndFeaturedPost);
        }
        public IActionResult FeaturedPost()
        {
     
            return View();
        }
        public IActionResult BlogDetails(int id)
        {
            List<Blog> selectedBlog = _repoBlog.GetSelectedBlog().FindAll(x => x.BlogID == id);
            List<Comment> blogComments = _repoComment.GetCommentsById(id);
            int BlogId = id;
            int AuthorID = _repoBlog.GetAll().Where(x => x.BlogID == id).Select(x => x.AuthorID).FirstOrDefault();
            List<Blog> authorPopularPost = _repoBlog.GetAll().Where(x => x.AuthorID == AuthorID).Take(3).ToList();
            Post Categories = new Post();
            Categories.TechNumbers = _repoBlog.GetAll().Where(x => x.CategoryID == 1).Count();
            Categories.MovieNumbers = _repoBlog.GetAll().Where(x => x.CategoryID == 2).Count();
            Categories.SeriesNumbers = _repoBlog.GetAll().Where(x => x.CategoryID == 3).Count();
            Categories.TravelNumbers = _repoBlog.GetAll().Where(x => x.CategoryID == 4).Count();
            Categories.SoftwareNumbers = _repoBlog.GetAll().Where(x => x.CategoryID == 5).Count();
            (List<Blog>,List<Comment>, int, List<Blog>, Post) selectedBlogDetails = (selectedBlog,blogComments, BlogId, authorPopularPost, Categories);
            return View(selectedBlogDetails);
        }
        public IActionResult BlogByCategory()
        {
            return View();
        }
        
    }
}
