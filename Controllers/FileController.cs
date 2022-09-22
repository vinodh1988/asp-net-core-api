using CrudAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(List<IFormFile> files){
           // new Person { Sno = 1, Name = name, City = "Chennai" };
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

        [HttpPost("filedataupload")]
        public async Task<IActionResult> Upload2(IFormCollection formdata)
        {
            // new Person { Sno = 1, Name = name, City = "Chennai" };
            var files = HttpContext.Request.Form.Files;
            var name = HttpContext.Request.Form["name"];
            long size = files.Sum(f => f.Length);

            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "Resources");

            foreach (var current in files)
            {
                var fileName = System.Net.Http.Headers.ContentDispositionHeaderValue.Parse(current.ContentDisposition).FileName.Trim('"');

                var fullPath = Path.Combine(pathToSave, fileName);

                using (var stream = System.IO.File.Create(fullPath))
                {
                    await current.CopyToAsync(stream);
                }
            }

            return Ok(new { result = "File Uploaded and form data received is "+name });
        }


        [HttpGet("download/{fileName}")]
        public async Task<IActionResult> Download(string fileName)
        {

            var path = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
            var fullPath = Path.Combine(path, fileName );

            var memory = new MemoryStream();
            using (var stream = new FileStream(fullPath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/octet-stream", Path.GetFileName(fullPath));
        }
    }
}
