using Intranet_Portal.Models;
using IntranetPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intranet_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly IntranetDbContext _context;
        public CommentController(IntranetDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentModel>>> GetComment()
        {
            return await _context.Comment.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<CommentModel>> PostCommentModel(CommentModel commentModel)
        {
            _context.Comment.Add(commentModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComment), new { id = commentModel.Id }, commentModel);
        }
    }
}
