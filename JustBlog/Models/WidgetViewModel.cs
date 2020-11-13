using JustBlog.core;
using JustBlog.core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JustBlog.Models
{
    public class WidgetViewModel
    {
        public WidgetViewModel(IBlogRepository blogRepository)
        {
            Categories = blogRepository.Categories();
            Tags = blogRepository.Tags();
            LastestPosts = blogRepository.Posts(0, 10);
        }
        public List<Category> Categories { get;private set; }
        public List<Tag> Tags { get; private set; } 
        public List<Post> LastestPosts { get; set; }
    }
}