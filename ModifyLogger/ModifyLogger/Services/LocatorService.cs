﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;
using ModifyLogger.Services.Abstractions;

namespace ModifyLogger.Services
{
    public static class LocatorService
    {
        private static readonly LoggerService _loggerService = new LoggerService();

        public static ILoggerService LoggerService => _loggerService;
        public static IFileService FileService => new FileService();
        public static IConfigService ConfigService => new LoggerConfigService();
        public static IDirectoryService DirectoryService => new DirectoryService();
    }
}
