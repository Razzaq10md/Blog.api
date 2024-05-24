using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.api.Data;
using Blog.api.Models;

namespace Blog.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogRepository _blogRepository;

        public BlogController(BlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Blog>>> GetBlogs()
        {
            var blogs = await _blogRepository.GetBlogsAsync();
            return Ok(blogs);
        }
    }
}