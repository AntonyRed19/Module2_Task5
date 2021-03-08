using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModifyLogger.Models;
using ModifyLogger.Services;
using ModifyLogger.Services.Abstractions;

namespace Logger
{
    public class Actions
    {
        private ILoggerService _loggerService;
        public Actions()
        {
            _loggerService = LocatorService.LoggerService;
        }

        public bool StartMethod()
        {
            _loggerService.ShowInfo($"{TypeofLogger.Info}: Start Method : {nameof(StartMethod)}");
            return true;
        }

        public bool SkippedLogic()
        {
            throw new BusinessException("Skipped logic in method ");
        }

        public bool BrokeLogic()
        {
            throw new Exception("I broke a logic");
        }
    }
}
