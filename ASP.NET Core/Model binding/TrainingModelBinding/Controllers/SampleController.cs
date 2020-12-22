using Microsoft.AspNetCore.Mvc;
using TrainingModelBinding.Dtos;

namespace TrainingModelBinding.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        [HttpGet("getWithoutParameters")]
        public IActionResult GetWithoutParameters()
        {
            return Ok();
        }

        [HttpGet("getWithParameters/{id}")]
        public IActionResult GetWithParameters(int id, string value)
        {
            return Ok(new { id, value });
        }

        [HttpPost("postWithoutParameters")]
        public IActionResult PostWithoutParameters()
        {
            return Ok();
        }

        [HttpPost("postWithParameters")]
        public IActionResult PostWithParameters(SampleDto sample)
        {
            return Ok(sample);
        }
    }
}
