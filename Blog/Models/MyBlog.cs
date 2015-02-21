using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class MyBlog
    {
        [Key]
        public int BlogId { set; get; }
        [Required]
        [Display(Name = "User Name")]
        public string UserId { set; get; }
        [Required]
        [Display(Name = "Blog Title")]
        public string BlogTitle { set; get; }
        [Required]
        [Display(Name = "Blog Description")]
        public string BlogDescription { set; get; }
        public string BloggerImg { set; get; }
        public int VisitorCount { set; get; }
        public string Date { set; get; }
        public string Status { set; get; }
    }
}