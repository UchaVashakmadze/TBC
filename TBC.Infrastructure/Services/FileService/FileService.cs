using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using TBC.Application.Services;
using Options = TBC.Application.Services.Options;

namespace TBC.Infrastructure.Services.FileService
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IOptions<Options> _options;
        public FileService(
            IHostingEnvironment hostingEnvironment,
            IOptions<Options> options)
        {
            _hostingEnvironment = hostingEnvironment;
            _options = options;
        }

        public async Task<string> Upload(IFormFile file)
	    {
            var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
            var path = GetFullPath(fileName);
            using (var stream = new FileStream(path, FileMode.Create))
		    {
			    await file.CopyToAsync(stream);
		    }

            return fileName; 
        }
        public async Task<string> Replace(IFormFile file, string oldFileName)
        {
            var oldFileFullPath = GetFullPath(oldFileName);
            if (File.Exists(oldFileFullPath))
            {
                File.Delete(oldFileFullPath);
            }

            var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
            var path = GetFullPath(fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }
        public async Task<byte[]> Download(string fileName)
	    {
            var path = GetFullPath(fileName);
            if (!File.Exists(path)) return null;
            return await File.ReadAllBytesAsync(path);
        }
        public void Remove(string fileName)
        {
            var path = GetFullPath(fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// Get Full Path
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetFullPath(string fileName)
        {
            if (!Directory.Exists(Path.Combine(_hostingEnvironment.ContentRootPath, _options.Value.ImageSourceFolder)))
            {
                Directory.CreateDirectory(Path.Combine(_hostingEnvironment.ContentRootPath,
                    _options.Value.ImageSourceFolder));
            }
            return Path.Combine(_hostingEnvironment.ContentRootPath, _options.Value.ImageSourceFolder, fileName);
        }
    }
}
