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

        public Post NumberOfPosts() 
        {
            return null;
        }

        public Post GetPost(int postId)
        {
            return context.Posts.FirstOrDefault(p => p.PostID == postId);
        }

        public void SavePost(Post post) 
        {
            if (post.PostID == 0)
            {
                post.Approved = false;
                post.closed = false;
                post.AddedDate = DateTime.Now;
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
            if (comment.CommentID == 0) 
            {
                comment.Approved = true;
                comment.PostID = 9;
                comment.AddedDate = DateTime.Now.ToUniversalTime();
                context.Comments.Add(comment);
            }           
            context.SaveChanges();
        }

        public void SubmitChanges() 
        {
            context.SaveChanges();
        }
    }

}