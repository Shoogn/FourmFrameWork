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
        [HiddenInput(DisplayValue=false)]
        public int PostID { get; set; }
        public int ForumID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AddedBy { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ApprovedBy { get; set; }

        [HiddenInput(DisplayValue = false)]
        public Nullable<System.DateTime> ApprovedDate { get; set; }

        [HiddenInput(DisplayValue = false)]
        public System.DateTime AddedDate { get; set; }

        [Required]
        public string Abstract { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public int ViewCount { get; set; }

        // Administration propreties
        [Required]
        [HiddenInput(DisplayValue = false)]
        public bool Approved { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public bool closed { get; set; }

        // Relationship
        public  Forum Forum { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}