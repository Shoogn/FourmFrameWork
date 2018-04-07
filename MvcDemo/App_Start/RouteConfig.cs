using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcDemo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
           
            routes.MapRoute(
                name:  "Forum",
                url: "forum/{forumId}",
                defaults: new { controller = "Forum", action = "ViewForum", forumId = (int?)null }
                );
            

            routes.MapRoute(
                name: "ForumPost",
                url: "forums/posts/{postId}",
                defaults: new { controller = "Forum", action = "ViewPost", postId = (int?)null }
                );

            routes.MapRoute(
                 "PostsManager",
                 "admin/forums/posts",
                 new { controller = "Forum", action = "ManagePosts" }
                );

            routes.MapRoute(
                name: "ForumCreate",
                url: "admin/forums/create",
                defaults: new { controller = "Forum", action = "CreateForum" }
                );

            routes.MapRoute(
                name: "ForumEdit",
                url: "admin/forums/edit/{forumId}",
                defaults: new { controller = "Forum", action = "EditForum",forumId=(int?)null }
                );

            routes.MapRoute(
                name: "PostCreate",
                url: "user/forum/create",
                defaults: new { controller = "Forum", action = "CreatePost" }
                );

            routes.MapRoute(
                name: "Postapprove",
                url: "post/approve/{postId}",
                defaults: new { controller = "Forum", action = "ApprovePost", postId = (int?)null }
                );

            routes.MapRoute(
                name: "PostRemove",
                url: "post/remove/{postId}",
                defaults: new { controller = "Forum", action = "RemovePost", postId = (int?)null }
                );

            routes.MapRoute(
                name: "CommentCreate",
                url: "user/post/comment/create",
                defaults: new { controller = "Forum", action = "CreateComment" }
                );
           
            routes.MapRoute(
                name: "ForumsIndex",
                url: "forums",
                defaults:  new { controller = "Forum", action = "Index" }
                );

            //routes.MapRoute(
            //    name: "Default2",
            //    url: "{controller}/{action}",
            //    defaults: new { controller = (string)null, action = (string)null }
            //    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Forum", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}