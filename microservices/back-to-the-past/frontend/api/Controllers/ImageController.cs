using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("images")]
public class ImageController : ControllerBase
{
    [HttpPost]
    [Route("")]
    public IActionResult ProcessImage()
    {
        var file = Request.Form.Files.FirstOrDefault();
        var emailAddress = Request.Form["emailAddress"].FirstOrDefault();

        return Ok();
    }
}
