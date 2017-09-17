using ZCStudio.FigureBed.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ZCStudio.FigureBed.Controllers
{
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        public IConfigurationRoot Configuration { get; }

        public FileController(IConfigurationRoot config)
        {
            Configuration = config;
        }

        [Route("dl/{fileFullName}")]
        public FileResult DownloadFile(string fileFullName)
        {
            var filestream = System.IO.File.OpenRead(Config.GetDocPath(fileFullName));
            return File(filestream, "application/jpg", fileFullName);
        }

        [Route("get/{fileFullName}")]
        public FileResult GetFile(string fileFullName)
        {
            var path = Config.GetDocPath(fileFullName);
            return PhysicalFile(path, "image/png");
        }
    }
}