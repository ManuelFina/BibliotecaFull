using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticoBiblioteca.API.Repositories.Interfaces;

namespace PracticoBiblioteca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CloudinaryUploadController : ControllerBase
    {
        private readonly ICloudinaryRepository _cloudinaryRepository;

        public CloudinaryUploadController(ICloudinaryRepository cloudinaryRepository)
        {
            _cloudinaryRepository = cloudinaryRepository;
        }

        [HttpPost("image")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest("Archivo vacío");

                using var stream = file.OpenReadStream();
                var url = await _cloudinaryRepository.UploadImageAsync(stream, file.FileName);

                return Ok(new { Url = url });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }

        }
    }

}
