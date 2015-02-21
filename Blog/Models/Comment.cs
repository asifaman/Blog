using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Comment
    {
        public int CommentId { set; get; }
        public string UserId { set; get; }
        public string BlogId { set; get; }
        public string UserComment { set; get; }
        public string Date { set; get; }
    }
}