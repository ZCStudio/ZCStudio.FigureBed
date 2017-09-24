using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ZCStudio.FigureBed.Configuration;

namespace ZCStudio.FigureBed.Controllers
{
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        private Config config;

        public FileController(IOptionsSnapshot<Config> configOptionsAccessor)
        {
            config = configOptionsAccessor.Value;
        }

        [Route("dl/{fileFullName}")]
        public FileResult DownloadFile(string fileFullName)
        {
            var filestream = System.IO.File.OpenRead(config.GetDocPath(fileFullName));
            return File(filestream, "application/jpg", fileFullName);
        }

        [Route("get/{fileFullName}")]
        public FileResult GetFile(string fileFullName)
        {
            var path = config.GetDocPath(fileFullName);
            return PhysicalFile(path, "image/png");
        }
    }
}