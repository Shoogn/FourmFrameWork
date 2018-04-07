using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcDemo.Models;

namespace MvcDemo.ViewModels
{
    public class PostViewModel
    {
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
        public int PostViewCount { get; set; }

        public string CommentTitle { get; set; }
        public string CommentBody { get; set; }

    }
}