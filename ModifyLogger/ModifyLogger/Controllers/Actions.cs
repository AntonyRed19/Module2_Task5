using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Actions
    {
        private readonly Logger _logger = Logger.Instance;
        public bool StartMethod()
        {
            _logger.ShowInfo($"{TypeofLogger.Info}: Start Method : {nameof(StartMethod)}");
            return true;
        }

        public BusinessException SkippedLogic()
        {
            return new BusinessException() { BusinessMessage = " Skipped logic in method " };
        }

        public void BrokeLogic()
        {
            throw new Exception("I broke a logic");
        }
    }
}
