namespace apiDocuments.Services
{
    public class LocalFileStorage : IFileStorage
    {
        private readonly IWebHostEnvironment env; //Para obtener ruta wwwroot
        private readonly IHttpContextAccessor httpContextAccessor; //Para determinar dominio y poder crear url documento

        public LocalFileStorage(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }

        public Task DeleteFile(string path, string container)
        {
            if (path != null)
            {
                var fileName = Path.GetFileName(path);
                string pathFile = Path.Combine(env.WebRootPath, container, fileName);

                if (File.Exists(pathFile))
                {
                    File.Delete(pathFile);
                }
            }

            return Task.CompletedTask;
        }

        public async Task<string> EditFile(byte[] data, string extension, string container, string path, string contentType)
        {
            await DeleteFile(path, container);
            return await SaveFile(data, extension, container, contentType);
        }

        public async Task<string> SaveFile(byte[] data, string extension, string container, string contentType)
        {
            var fileName = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(env.WebRootPath, container);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string path = Path.Combine(folder, fileName);
            await File.WriteAllBytesAsync(path, data);

            var currentPath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";

            var urlDb = Path.Combine(currentPath, container, fileName).Replace("\\", "/");

            return urlDb;
        }
    }
}
