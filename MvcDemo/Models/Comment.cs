using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class Comment
    {
        
        public int CommentID { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int PostID { get; set; }
        public System.DateTime AddedDate { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string AddedBy { get; set; }

        // Administartion
        public bool Approved { get; set; }
        public System.DateTime ApprovedDate { get; set; }
        public virtual Post Post { get; set; }
    }
}