using InMemory.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IMemoryCache _cache;

        public BlogController(IMemoryCache cache)
        {
            _cache = cache;
        }

        [HttpGet("{id}")]
        public ActionResult<BlogPost> GetBlogPost(int id)
        {
            BlogPost blogPost;
            if (!_cache.TryGetValue(id, out blogPost))
            {
                blogPost = new BlogPost
                {
                    Id = id,
                    Title = "Test Başlığı",
                    Content = "Test İçeriği"
                };

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                };

                _cache.Set(id, blogPost, cacheEntryOptions);

                Console.WriteLine("Önbelleğe alındı");
            }

            return blogPost;
        }
    }
}
