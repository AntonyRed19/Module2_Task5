using System;
using System.IO;
using System.Text;

namespace Logger
{
    public class Logger
    {
        private static readonly Logger _instance = new Logger();
        private readonly StringBuilder _log = new StringBuilder();
        static Logger()
        {
        }

        private Logger()
        {
        }

        public static Logger Instance => _instance;
        public string Log => _log.ToString();

        public void ShowEror(string massage)
        {
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
            Console.WriteLine(log);
            _log.AppendLine(log);
        }
    }
}
