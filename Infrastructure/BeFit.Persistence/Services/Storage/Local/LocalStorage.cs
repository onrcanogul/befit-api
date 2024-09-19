using BeFit.Application.Services.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace BeFit.Persistence.Services.Storage.Local;

public class LocalStorage(IWebHostEnvironment webHostEnvironment) : ILocalStorage
{
    public Task DeleteAsync(string fileName, string path)
    {
        File.Delete($"{path}\\{fileName}");
        return Task.CompletedTask;
    }
    public List<string> GetFiles(string path)
    {
        DirectoryInfo directory = new(path);
        return directory.GetFiles().Select(f => f.Name).ToList();
    }
    public bool HasFile(string path, string fileName) => File.Exists($"{path}\\{fileName}");
    public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
    {
        var uploadPath = Path.Combine(webHostEnvironment.WebRootPath, path);
        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);
        List<(string fileName, string path)> datas = new();
        List<bool> results = new();
        foreach (var file in files)
        {
            var fileNewName = await FileRenameAsync(uploadPath, file.Name);
            var result = await CopyFileAsync(Path.Combine(uploadPath, fileNewName), file); // $"{uploadPath}\\{fileNewName}"
            datas.Add((fileNewName, $"{path}\\{fileNewName}"));               
        }
        return results.TrueForAll(e => e.Equals(true)) ? datas : throw new FileNotFoundException();
    }
    private async Task<bool> CopyFileAsync(string path, IFormFile file)
    {
        try
        {
            await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
            return true;
        }
        catch (IOException ex)
        {
            return false;
        }
    }
    private static async Task<string> FileRenameAsync(string pathOrContainerName, string fileName ,int num = 0)
    {
        var newFileName = await Task.Run<string>(async () =>
        {
            var newFileName = String.Empty;
            var extension = Path.GetExtension(fileName);
            if (num == 0)
            {
                var oldName = Path.GetFileNameWithoutExtension(fileName);
            }
            else
            {
                newFileName = fileName;
            }
            if (File.Exists($"{pathOrContainerName}\\{newFileName}"))
                return await FileRenameAsync(pathOrContainerName, $"{Path.GetFileNameWithoutExtension(newFileName)}-{num}{extension}",++num);
            return newFileName;
        });
        return newFileName;
}
    
}
