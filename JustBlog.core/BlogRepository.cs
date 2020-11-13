using JustBlog.core.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.core
{
    public class BlogRepository : IBlogRepository
    {
        private JustBlogDbContext db = new JustBlogDbContext();


        public List<Category> Categories()
        {
            return db.Categories.OrderBy(p => p.Name).ToList();
        }

        public Category Category(int categoryId)
        {
            return db.Categories.SingleOrDefault(p => p.Id == categoryId);
        }



        public Post Post(int id)
        {
            return db.Posts.SingleOrDefault(p=>p.Id==id);
        }

        public List<Post> PostForCategory(int categoryId, int pageNo, int pageSize)
        {
            return db.Posts
                .Where(p => p.published && p.CategoryId == categoryId)
                .OrderByDescending(p => p.PostedOn)
                .Skip(pageSize * (pageNo - 1))
                .Take(pageSize).ToList();
        }

        public List<Post> PostForSearch(string Search, int pageNo, int pageSize)
        {
            return db.Posts
              .Where(p => p.published && p.Title.Contains(Search))
              .OrderByDescending(p => p.PostedOn)
              .Skip(pageSize * (pageNo - 1))
              .Take(pageSize).ToList();
        }

        public List<Post> PostForTag(int TagID, int pageNo, int pageSize)
        {
            return db.Posts
               .Where(p => p.published && p.Tags.Any(t=>t.Id == TagID) )
               .OrderByDescending(p => p.PostedOn)
               .Skip(pageSize * (pageNo - 1))
               .Take(pageSize).ToList();
        }

        public List<Post> Posts(int pageNo, int pageSize)
        {
            return db.Posts
                .Where(p => p.published)
                .OrderByDescending(p => p.PostedOn)
                .Skip(pageNo*pageSize).Take(pageSize).ToList();
        }

        public Tag Tag(int id)
        {
            return db.Tags.SingleOrDefault(p => p.Id == id);
        }

        public List<Tag> Tags()
        {
            return db.Tags.OrderBy(p=>p.Name).ToList();
        }

        public int TotalPostForCategory(int CategoryId)
        {
            return db.Posts
                  .Where(p => p.published && p.CategoryId == CategoryId).Count();

        }

        public int TotalPostForTag(int TagId)
        {
            return db.Posts
                                .Where(p => p.published && p.Tags.Any(t => t.Id == TagId)).Count();
        }

        public int TotalPosts()
        {
            return db.Posts.Where(p => p.published).Count();        }

        public int TotalPostsForSearch(string search)
        {
            return db.Posts.Where(p => p.published && p.Title.Contains(search)).Count();
        }
    }
}
