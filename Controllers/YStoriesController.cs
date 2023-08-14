using IntranetPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntranetPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YStoriesController : Controller
    {
        private readonly IntranetDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public YStoriesController(IntranetDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<YStoriesModel>>> GetYStory()
        {
            return await _context.YStories.Select(x => new YStoriesModel
            {
                videoId = x.videoId,
                videoURL = x.videoURL,
                videoTitle = x.videoTitle
                //String.Format("{0}://{1}{2}/VideoTitale/{3}", Request.Scheme, Request.Host, Request.PathBase, x.videoTitale)

            }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<YStoriesModel>> GetStriesById(int id)
        {
            var ystoriesModel = await _context.YStories.FindAsync(id);
            if (ystoriesModel == null)
            {
                return NotFound();
            }
            return ystoriesModel;
        }

        [HttpPost]
        public async Task<ActionResult<YStoriesModel>> AddStries([FromForm] YStoriesModel ystoriesModel)
        {
            // striesModel.imageName = await SaveImage(striesModel.imageFile);
            _context.YStories.Add(ystoriesModel);
            await _context.SaveChangesAsync();

            return Ok(ystoriesModel);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<YStoriesModel>> EditVideo(int id, [FromForm] YStoriesModel ystoriesModel)
        {
            if (id != ystoriesModel.videoId)
            {
                return BadRequest();
            }


            _context.Entry(ystoriesModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YStoriesModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(ystoriesModel);

        }

        [HttpDelete()]
        public async Task<ActionResult<YStoriesModel>> DeleteStries(int id)
        {
            var ystoriesmodel = await _context.YStories.FindAsync(id);
            if (ystoriesmodel == null)
            {
                return BadRequest();
            }

            _context.YStories.Remove(ystoriesmodel);
            await _context.SaveChangesAsync();
            return Ok(ystoriesmodel);
        }




        private bool YStoriesModelExists(int id)
        {
            return _context.YStories.Any(e => e.videoId == id);
        }
    }
}
