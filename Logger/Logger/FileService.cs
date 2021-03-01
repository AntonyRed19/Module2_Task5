using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class FileService
    {
        public void WriteFile(string path, string text)
        {
            File.WriteAllText(path, text);
        }
    }
}
