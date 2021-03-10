using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModifyLogger.Helpers;
using ModifyLogger.Services.Abstractions;

namespace ModifyLogger.Services
{
    public class DirectoryService : IDirectoryService
    {
        private readonly IFileService _fileService;

        public DirectoryService()
        {
            _fileService = LocatorService.FileService;
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public void RemoveOldestFiles(string path, int countOfBackup)
        {
            var files = GetFiles(path);

            var countForRemove = files.Length - countOfBackup;

            if (countForRemove < 1)
            {
                return;
            }

            var filesInfo = new Models.File[files.Length];

            for (var i = 0; i < files.Length; i++)
            {
                var item = files[i];

                var createdDatetime = _fileService.GetCreationTime(item);

                filesInfo[i] = new Models.File()
                {
                    Path = item,
                    CreateTime = createdDatetime
                };
            }

            Array.Sort(filesInfo, new FileComparer());

            for (var i = 0; i < countForRemove; i++)
            {
                _fileService.Delete(filesInfo[i].Path);
            }
        }

        public string[] GetFiles(string path) => Directory.GetFiles(path);

        public bool Exists(string path) => Directory.Exists(path);
    }
}
