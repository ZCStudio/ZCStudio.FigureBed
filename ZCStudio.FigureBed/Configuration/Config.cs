using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ZCStudio.FigureBed.Configuration
{
    public class Config
    {
        internal const string defaultPath = "files";
        internal static IConfigurationRoot configroot { get; set; }

        internal static string DocPath => configroot["Files:RootPath"]??defaultPath;

        internal static string GetDocPath()
        {
            return Path.Combine(AppContext.BaseDirectory, DocPath);
        }

        internal static string GetDocPath(string filepath)
        {
            return Path.Combine(GetDocPath(), filepath);
        }
    }
}
