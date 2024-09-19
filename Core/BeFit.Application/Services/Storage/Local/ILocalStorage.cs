using Microsoft.AspNetCore.Http;

namespace BeFit.Application.Services.Storage.Local;

public interface ILocalStorage
{
    Task DeleteAsync(string fileName, string path);
    List<string> GetFiles(string path);
    Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files);
}