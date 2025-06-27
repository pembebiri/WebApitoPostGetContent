using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private static List<Content> contents = new List<Content>
        {
            new Content { Id = 1, Title = "İlk İçerik", Body = "Bu, ilk içerik örneğidir." },
            new Content { Id = 2, Title = "İkinci İçerik", Body = "Bu, ikinci içerik örneğidir." }
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(contents);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Content newContent)
        {
            if (newContent == null || string.IsNullOrEmpty(newContent.Title) || string.IsNullOrEmpty(newContent.Body))
            {
                return BadRequest("Geçersiz içerik verisi.");
            }
            newContent.Id = contents.Count + 1; // basit id ataması
            contents.Add(newContent);
            return CreatedAtAction(nameof(Get), new { id = newContent.Id }, newContent);
        }

    }
}
