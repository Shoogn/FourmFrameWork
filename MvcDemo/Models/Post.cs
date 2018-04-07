using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class Post
    {

        public int PostID { get; set; }
        public int ForumID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AddedBy { get; set; }
        public System.DateTime AddedDate { get; set; }
        [Required]
        public string Body { get; set; }
        public int ViewCount { get; set; }

        // Administration propreties
        public bool Approved { get; set; }
        public bool closed { get; set; }

        // Relationship
        public  Forum Forum { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}