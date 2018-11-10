using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using MvcDemo.Models;

namespace MvcDemo.AbstractLayer
{
   public interface IFourmRepository
    {
       IQueryable<Forum> GetAllForums { get; }
       Forum GetForum(int forumId);    

       IQueryable<Post> GetAllPosts { get; }
       Post GetPost(int postId);
      // IQueryable<Post> NumberOfPosts { get; }

       void SaveForum(Forum forum);
       Forum DeleteForum(int forumId);

       void SavePost(Post post);
       Post ApprovePost(int postId);
       Post ClosPost(int postId);
       Post DeletePost(int postId);

       void SaveComment(Comment comment);

       void AddViewCount(int postID);
       void SubmitChanges();
    }
}
