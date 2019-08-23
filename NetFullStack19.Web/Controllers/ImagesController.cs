using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetFullStack19.Core.Moderation;

namespace NetFullStack19.Web.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ImagesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            // 1. upload to temp storage
            long size = files.Sum(f => f.Length);
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", Path.GetRandomFileName());
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            // 2. moderate image
            IModeration moderation = new GoogleCloudModeration();
            var moderationResponse = moderation.CheckAdult(filePath);

            return Ok(new { count = files.Count, size, filePath });
        }
    }
}