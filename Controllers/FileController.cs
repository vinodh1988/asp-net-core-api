using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(List<IFormFile> files){
            long size = files.Sum(f => f.Length);

            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "Resources");

            foreach (var current in files) {
                var fileName = System.Net.Http.Headers.ContentDispositionHeaderValue.Parse(current.ContentDisposition).FileName.Trim('"');

                var fullPath = Path.Combine(pathToSave, fileName);

                using (var stream = System.IO.File.Create(fullPath))
                {
                    await current.CopyToAsync(stream);
                }
            }

            return Ok(new { result = "File Uploaded" });
        }
    }
}
