using System;
using System.IO;
using System.Text;
using ModifyLogger.Services.Abstractions;

namespace Logger
{
    public class LoggerService : ILoggerService
    {
        public LoggerService()
        {
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
        }
    }
}
