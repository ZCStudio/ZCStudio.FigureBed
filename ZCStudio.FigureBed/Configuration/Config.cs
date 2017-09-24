using System;
using System.IO;

namespace ZCStudio.FigureBed.Configuration
{
    public class Config
    {
        public string RootPath { get; set; } = "files";

        internal string GetDocPath()
        {
            return Path.Combine(AppContext.BaseDirectory, RootPath);
        }

        internal string GetDocPath(string filepath)
        {
            return Path.Combine(GetDocPath(), filepath);
        }
    }
}