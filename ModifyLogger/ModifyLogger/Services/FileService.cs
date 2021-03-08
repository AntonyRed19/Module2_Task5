using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;

namespace Logger
{
    public class FileService : IDisposable
    {
        private static readonly FileService _instance = new FileService();
        private bool _disposed = false;
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);
        static FileService()
        {
        }

        private FileService()
        {
        }

        public static FileService Instance => _instance;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void WriteFile(string path, string text)
        {
            File.WriteAllText(path, text);
        }

        public void CreateDirectory()
        {
            string path = @"C:\\Users\\Antony\\source\\repos\\AntonyRed19\\Module2_Task5\\Logger\\Logger\\bin\\Debug\\net5.0\\Files";

            try
            {
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }

                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally
            {
                Dispose();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _safeHandle?.Dispose();
            }

            _disposed = true;
        }
    }
}
