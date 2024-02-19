using HackerNewsAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HackerNewsAPIController : ControllerBase
    {
        private readonly IAPIHander _IAPIHander;
        private readonly ILogger<HackerNewsAPIController> _logger;
        public HackerNewsAPIController(IAPIHander iapiHandler, ILogger<HackerNewsAPIController> logger)
        {
            _IAPIHander = iapiHandler;
            _logger = logger;

        }


        [HttpGet("GetAllStories")]
        public async Task<IActionResult> GetAllStories()
        {
            try
            {
                var result = await _IAPIHander.GetAllStory();
                if (result != null)
                {
                    return Ok(result);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to execute the API");
                return BadRequest(ex);
            }
        }


        [HttpGet(Name = "GetStories")]
        public async Task<IActionResult> GetStories(string? id)
        {
            try
            {
                var result = await _IAPIHander.GetStoryById(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to execute the API");

                return BadRequest(ex);
            }
        }



    }
}
