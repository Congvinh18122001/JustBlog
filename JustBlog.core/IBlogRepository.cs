using JustBlog.core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.core
{
    public interface IBlogRepository
    {
        List<Post> Posts(int pageNo, int pageSize);
        int TotalPosts();
        List<Post> PostForCategory(int categoryId, int pageNo, int pageSize);
        int TotalPostForCategory(int CategoryId);
        Category Category(int id);
        List<Post> PostForTag(int TagID, int pageNo, int pageSize);
        int TotalPostForTag(int TagId);
        Tag Tag(int id);
        List<Post> PostForSearch(String Search, int pageNo, int pageSize);
        int TotalPostsForSearch(string search);
        Post Post(int id);
        List<Category> Categories();
        List<Tag> Tags();
    }
}
