using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModifyLogger.Configs;
using ModifyLogger.Services.Abstractions;
using Newtonsoft.Json;

namespace ModifyLogger.Services
{
    public class LoggerConfigService : IConfigService
    {
        private readonly string _filePath = "config.json";
        private readonly LoggerConfig _loggerConfig;
        private readonly IFileService _fileService;

        public LoggerConfigService()
        {
            _fileService = LocatorService.FileService;

            var config = GetConfig();
            _loggerConfig = config.Logger;
        }

        public LoggerConfig LoggerConfig => _loggerConfig;

        private Config GetConfig()
        {
            var json = _fileService.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<Config>(json);
        }
    }
}
