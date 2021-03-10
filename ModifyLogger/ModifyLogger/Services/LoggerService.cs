using System;
using System.IO;
using System.Text;
using ModifyLogger.Configs;
using ModifyLogger.Services;
using ModifyLogger.Services.Abstractions;

namespace Logger
{
    public class LoggerService : ILoggerService
    {
        private readonly LoggerConfig _loggerConfig;
        private readonly IFileService _fileService;
        private readonly IDirectoryService _directoryService;
        private IDisposable _fileStreamWrite;
        public LoggerService()
        {
            var config = LocatorService.ConfigService;
            _loggerConfig = config.LoggerConfig;

            _fileService = LocatorService.FileService;
            _directoryService = LocatorService.DirectoryService;
            Init();
        }

        public void ShowError(string massage, Exception ex)
        {
            var massagelog = $"{massage}: {ex}";
            ShowAllLog(TypeofLogger.Eror, massage);
        }

        public void ShowInfo(string massage)
        {
            ShowAllLog(TypeofLogger.Info, massage);
        }

        public void ShowWarning(string massage)
        {
            ShowAllLog(TypeofLogger.Warning, massage);
        }

        public void ShowAllLog(TypeofLogger logger, string massage)
        {
            var log = $"{DateTime.Now}: {logger}: {massage}";
            _fileService.WriteToStream(_fileStreamWrite, log);
        }

        private void Init()
        {
            var dirPath = _loggerConfig.DirectoryPath;

            if (!_directoryService.Exists(dirPath))
            {
                _directoryService.CreateDirectory(dirPath);
            }

            _directoryService.RemoveOldestFiles(dirPath, _loggerConfig.BackUpCount);

            var fileName = $"{DateTime.UtcNow.ToString(_loggerConfig.NameFormat)}";
            var filePath = $"{dirPath}{fileName}{_loggerConfig.ExtensionFile}";

            _fileStreamWrite = _fileService.CreateStreamForWrite(filePath);
        }
    }
}
