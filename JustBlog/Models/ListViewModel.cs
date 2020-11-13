using JustBlog.core;
using JustBlog.core.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace JustBlog.Models
{
    public class ListViewModel
    {
        int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"].ToString());

        public ListViewModel(BlogRepository blogRepository , int pageNo)
        {
            posts = blogRepository.Posts(pageNo,pageSize);
            TotalPost = blogRepository.TotalPosts(); 
        }
        public List<Post> posts { get; private set; }
        public int TotalPost { get; private set; }
        public Category Category { get; private set; }
        public Tag Tag { get; private set; }
        public ListViewModel(IBlogRepository blogRepository,string type , int id,int page)
        {
            switch (type)
            {
                case "Category":
                    posts = blogRepository.PostForCategory(id, page, pageSize);
                    TotalPost = blogRepository.TotalPostForCategory(id);
                    Category = blogRepository.Category(id);
                    break;
                case "Tag":
                    posts = blogRepository.PostForTag(id, page, pageSize);
                    TotalPost = blogRepository.TotalPostForTag(id);
                    Tag = blogRepository.Tag(id);
                    break;
            }
            
        }
        public ListViewModel(IBlogRepository blogRepository , string Search , int page)
        {
            posts = blogRepository.PostForSearch(Search,page,pageSize);
            TotalPost = blogRepository.TotalPostsForSearch(Search);
        }
        
    }
}