using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Actions
    {
        private readonly LogicofLogger _logger = LogicofLogger.Instance;

        public Result StartMethod()
        {
            _logger.ShowInfo($" Start Method : {nameof(StartMethod)}");
            return new Result() { Status = true };
        }

        public Result SkippedLogic()
        {
            _logger.ShowWarning($"{TypeofLogger.Warning}: Skipped logic of Method {nameof(SkippedLogic)}");
            return new Result() { Status = true };
        }

        public Result BrokeLogic()
        {
            return new Result() { Status = false, Massage = "I broke a logic" };
        }
    }
}
