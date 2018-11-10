using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using MvcDemo.AbstractLayer;
using MvcDemo.Models;
using System.Security.Policy;
using System.Web.Routing;

namespace MvcDemo.Repository
{
    public class ForumRepository : IFourmRepository
    {
        private MvcForumEntities context = new MvcForumEntities();

        /* ===============
                            Manage Forum   ================== */

        public IQueryable<Forum> GetAllForums { get { return context.Forums; } }
        public Forum GetForum(int forumId)
        {
            return context.Forums.FirstOrDefault(f => f.ForumID == forumId);
        }


        public void SaveForum(Forum forum) 
        {
            if (forum.ForumID == 0)
            {
                context.Forums.Add(forum);
            }
            else 
            {
                Forum dbEntry = context.Forums.Find(forum.ForumID);
                if (dbEntry != null)
                {
                    dbEntry.Title = forum.Title;
                    dbEntry.AddedBy = "Mohammed";
                }
            }
            context.SaveChanges();
        }

        public Forum DeleteForum(int forumId) 
        {
            Forum dbEntry = context.Forums.Find(forumId);
            if (dbEntry != null)
            {
                context.Forums.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }


        /* ===============
                            Manage Post   ================== */

        public IQueryable<Post> GetAllPosts { get { return context.Posts; } }

        //public IQueryable<Post> NumberOfPosts
        //{
        //    get
        //    {
        //        var post = from p in context.Posts
        //                   group p by p.Forum into eachForumHas
        //                   select new { eachForumHas.Key.Title, Post = eachForumHas.Count() };
        //        return post;
        //}
        //}
        
                  

        public Post GetPost(int postId)
        {
            return context.Posts.FirstOrDefault(p => p.PostID == postId);
        }

        public void SavePost(Post post) 
        {
            if (post.PostID == 0)
            {
                // Here I moved customer field to the Forum Controller in SaveForum ActionResult method

                // Now Return It.
                post.ViewCount = 0;
                post.Approved = false;
                post.closed = false;
                post.AddedDate = DateTime.Now;
                post.ApprovedDate = null;
                context.Posts.Add(post);
            }
            else
            {
                Post dbEntry = context.Posts.Find(post.PostID);
                if (dbEntry != null)
                {
                    dbEntry.AddedBy = post.AddedBy;
                    dbEntry.AddedDate = post.AddedDate;
                    dbEntry.Approved = post.Approved;
                    dbEntry.ApprovedBy = post.ApprovedBy;
                    dbEntry.ApprovedDate = post.ApprovedDate;
                    dbEntry.Abstract = dbEntry.Abstract;
                    dbEntry.Body = post.Body;
                    dbEntry.closed = dbEntry.closed;
                    dbEntry.ForumID = post.ForumID;
                    dbEntry.Title = post.Title;
                    dbEntry.ViewCount = post.ViewCount;
                }
            }
            context.SaveChanges();
        }

        public Post DeletePost(int postId) 
        {
            Post dbEntry = context.Posts.Find(postId);
            if (dbEntry != null)
            {
                context.Posts.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public Post ApprovePost(int postId) 
        {
            Post p = (from a in context.Posts
                      where a.PostID == postId
                      select a).First();
            p.Approved = true;
            p.ApprovedDate = DateTime.Now;
            p.ApprovedBy = "Mohammed";
            context.SaveChanges();
            return p;
        }

        public Post ClosPost(int postId) 
        {
            Post p = (from a in context.Posts
                      where a.PostID == postId
                      select a).First();
            p.closed = true;
            context.SaveChanges();
            return p;
        }

        /* ================
         *                      Manage Comment ======================= */

        public void SaveComment(Comment comment) 
        {
            comment.AddedBy = "Mohammed";
            comment.AddedDate = DateTime.Now;
            comment.Approved = true;
            comment.ApprovedDate = DateTime.Now;
            context.Comments.Add(comment);
            context.SaveChanges();
        }

        public void AddViewCount(int postID)
        {
            Post viewSum = context.Posts.Find(postID);
            if (viewSum != null)
            {
                try
                {
                    viewSum.ViewCount++;
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
                
            }
        }

        public void SubmitChanges() 
        {
            context.SaveChanges();
        }
    }

}