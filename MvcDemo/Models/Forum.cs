using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcDemo.Models
{
    [Table("Forums")]
    public class Forum
    {
        [HiddenInput(DisplayValue=false)]
        public int ForumID { get; set; }
        [Required(ErrorMessage="This field is Requierd")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This field is Requierd")]
        public string AddedBy { get; set; }

        // Rel
        public virtual ICollection<Post> Posts { get; set; }
    }
}