using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using ModifyLogger.Services.Abstractions;
using Newtonsoft.Json;

namespace Logger
{
    public class FileService : IFileService
    {
        public IDisposable CreateStreamForWrite(string path)
        {
            return new StreamWriter(path, true, Encoding.Default);
        }

        public void WriteToStream(IDisposable stream, string text)
        {
            var streamWrite = (StreamWriter)stream;

            streamWrite.WriteLine(text);
        }

        public void Delete(string path)
        {
            File.Delete(path);
        }

        public string ReadAllText(string path) => File.ReadAllText(path);

        public DateTime GetCreationTime(string path) => File.GetCreationTime(path);
    }
}
