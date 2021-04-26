using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TBC.Application.Services
{
    public interface IFileService
    {
        Task<string> Upload(IFormFile file);
        Task<string> Replace(IFormFile file, string oldFileName);
        Task<byte[]> Download(string path);
        void Remove(string path);
    }
}
