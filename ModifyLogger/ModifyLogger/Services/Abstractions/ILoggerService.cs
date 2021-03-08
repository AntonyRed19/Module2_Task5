using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace ModifyLogger.Services.Abstractions
{
    public interface ILoggerService
    {
        public void ShowError(string massage, Exception ex = null);
        public void ShowInfo(string massage);
        public void ShowWarning(string massage);
        public void ShowAllLog(TypeofLogger logger, string massage);
    }
}
