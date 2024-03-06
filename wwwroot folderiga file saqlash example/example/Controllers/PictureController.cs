using Microsoft.AspNetCore.Mvc;         // ControllerBase |ishlashi uchun

namespace example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;       // IWebHostEnvironment faqat Api ichida ishlaydi!

        public PictureController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        [Route("get")]
        public IActionResult GetPicture(IFormFile picture)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "images", picture.FileName);
            using (FileStream strem =new FileStream(path,FileMode.Create))
                picture.CopyTo(strem);

            var fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, "image/jpeg"); 
        }
    }
}