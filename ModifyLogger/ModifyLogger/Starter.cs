using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModifyLogger.Models;
using ModifyLogger.Services;
using ModifyLogger.Services.Abstractions;
using Logger;

namespace Logger
{
    public class Starter
    {
        private Actions _action;
        private ILoggerService _loggerService;

        public Starter()
        {
            _action = new Actions();
            _loggerService = LocatorService.LoggerService;
        }

        public void Run()
        {
            const int _randomNumberMin = 1;
            const int _randomNumberMax = 4;
            const int _runCounter = 100;

            var random = new Random();

            for (var i = 0; i < _runCounter; i++)
            {
                try
                {
                    var logType = random.Next(_randomNumberMin, _randomNumberMax);

                    switch (logType)
                    {
                        case 1:
                            _action.StartMethod();
                            break;
                        case 2:
                            _action.SkippedLogic();
                            break;
                        case 3:
                            _action.BrokeLogic();
                            break;
                    }
                }
                catch (BusinessException ex)
                {
                    _loggerService.ShowError($"Action got this custom Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    _loggerService.ShowError($"Action failed by reason:", ex);
                }
            }
        }
    }
}
