using Intranet_Portal.Models;
using IntranetPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Intranet_Portal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirthdayCommentController : Controller
    {
        private readonly IntranetDbContext _context;
        public BirthdayCommentController(IntranetDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BirthdayCommentcs>>> GetComment()
        {
            return await _context.BirthdayComment.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<BirthdayCommentcs>> PostCommentModel(BirthdayCommentcs commentModel)
        {
            _context.BirthdayComment.Add(commentModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetComment), new { id = commentModel.Id }, commentModel);
        }


    }
}
