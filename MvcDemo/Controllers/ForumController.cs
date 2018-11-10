using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;
using MvcDemo.Repository;
using MvcDemo.AbstractLayer;


namespace MvcDemo.Controllers
{
    public class ForumController : Controller
    {
        private IFourmRepository repository;
        public ForumController(IFourmRepository forumRepository)
        {
            repository = forumRepository;
        }

        // ============== general action =========================
        //
        // GET: /Forum/

        public ViewResult Index()
        {
            return View(repository.GetAllForums);
        }

        [HttpGet]
        public ActionResult ViewForum(int forumId)
        {
            var forum = repository.GetForum(forumId);
            if (forum == null)
                throw new HttpException(404, "The forum could not be found");
            return View(forum);
        }

        [HttpGet]
        public ActionResult ViewPost(int postId)
        {
            var viewPost = repository.GetPost(postId);
            repository.AddViewCount(postId);
            //viewPost.ViewCount++;
            //repository.SubmitChanges();
           
            if (viewPost == null)
                throw new HttpException(404, "The post you search about could not be found!!");
            return View(viewPost);
        }

        // ================ Manage Forum ==================================
        [HttpGet]
        public ViewResult EditForum(int? forumId)
        {
            Forum forum = repository.GetAllForums.FirstOrDefault(f => f.ForumID == forumId);
            return View(forum);
        }

        [HttpPost]
        public ActionResult EditForum(Forum forum)
        {
            if (ModelState.IsValid)
            {
                repository.SaveForum(forum);
                return RedirectToAction("Index");
            }
            else
            {
                return View(forum);
            }
        }

        public ViewResult CreateForum()
        {
            return View("EditForum", new Forum());
        }

        public ActionResult RemoveForum(int forumId)
        {
            Forum deleteForum = repository.DeleteForum(forumId);
            if (deleteForum != null)
            {
                TempData["messageDelete"] = string.Format("{0} was deleted", deleteForum.Title);
            }
            return RedirectToAction("Index");
        }

        // ================= Manage Post ====================

        [HttpGet]
        public ActionResult CreatePost()
        {
          ViewBag.ForumID = new SelectList(repository.GetAllForums, "ForumID", "Title");
           return View();
       
        }

        [HttpPost]
        public ActionResult CreatePost(Post post)
        {
          if(Request.IsAjaxRequest())
          {                         
              repository.SavePost(post);
          }
          ViewBag.ForumID = new SelectList(repository.GetAllForums, "ForumID", "Title", post.ForumID);
          return PartialView("_Message");

        }

        public ActionResult ManagePosts()
        {
            var viewData = repository.GetAllPosts.Where(p => p.Approved == false);
            return View(viewData);
        }
     
        [HttpGet]
        public ActionResult ApprovePost(int postId)
        {
            Post  post = repository.ApprovePost(postId);
            if (post == null)
            {
                throw new HttpException(404, "Sorry there is no post has this ID");
            }
            return View(post);
        }

        [HttpPost]
        public ActionResult ApprovePost(int postId,FormCollection form) 
        {
            Post approvePost = repository.ApprovePost(postId);
            if (approvePost != null)
            {
                TempData["message"] = string.Format("{0} was approved", approvePost.Title);
                return RedirectToAction("ManagePosts");
            }
            else 
            {
                throw new HttpException(404, "Sorry there is no post has this ID");
            }
            
        }

        [HttpGet]
        public ActionResult RemovePost(int postId)
        {
            Post post = repository.GetPost(postId);
            if (post == null)
            {
                throw new HttpException(404, "Sorry there is no post has this ID");
            }
            return View(post);
        }

        [HttpPost]
        public ActionResult RemovePost(int postId,FormCollection form)
        {
            Post deletePost = repository.DeletePost(postId);
            if (deletePost != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletePost.Title);
                return RedirectToAction("ManagePosts");
            }
            else
            {
                throw new HttpException(404, "Sorry there is no post has this ID");
            }
        }

        // =================== Manage Comments ==================

        [HttpGet]
        public ActionResult CreateComment() 
        {
            return View();
        }

        [HttpPost]        
        public ActionResult CreateComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                repository.SaveComment(comment);
                
                return RedirectToAction("Index");
            }
            return View();
        }

        [ChildActionOnly]
        public ActionResult GetLastestPost()
        {
            var post = repository.GetAllPosts.Where(p=>p.Approved==true).OrderBy(p => p.Title).Take(5);
            return PartialView("_LastContents", post);
        }

        [ChildActionOnly]
        public ActionResult GetMuchMoreViewPost()
        {
            var postView = repository.GetAllPosts
                .OrderByDescending(x => x.ViewCount).Take(5);                                       
            return PartialView("_GetMuchMoreViewPostContents",postView);
        }
        
    }
}
