using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingModelBinding.Dtos;

namespace TrainingModelBinding.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        [HttpGet("GetWithoutParameters")]
        public IActionResult GetWithoutParameters()
        {
            return Ok();
        }

        [HttpGet("GetWithParameters/{id}")]
        public IActionResult GetWithParameters(int id, string value)
        {
            return Ok(new { id, value });
        }

        [HttpPost("PostWithoutParameters")]
        public IActionResult PostWithoutParameters()
        {
            return Ok();
        }

        [HttpPost("PostWithParameters")]
        public IActionResult PostWithParameters(SampleDto sample)
        {
            return Ok(sample);
        }

        [HttpPost("PostWithParametersFromQuery")]
        public IActionResult PostWithParametersFromQuery([FromQuery] int id)
        {
            return Ok(id);
        }

        [HttpPost("PostWithParametersFromForm")]
        public IActionResult PostWithParametersFromForm([FromForm] string name, [FromForm] string value)
        {
            return Ok(new { name, value });
        }

        [HttpPost("PostWithParametersFromBody")]
        public IActionResult PostWithParametersFromBody([FromBody] string body)
        {
            return Ok(body);
        }

        [HttpPost("PostWithParametersFromHeader")]
        public IActionResult PostWithParametersFromHeader([FromHeader(Name = "x-custom-header")] string header)
        {
            return Ok(header);
        }

        [HttpPost("PostWithFile")]
        public IActionResult PostWithFile(IFormFile file)
        {
            return Ok(new { name = file.FileName, size = $"{file.Length} bytes", type = file.ContentType });
        }
    }
}
