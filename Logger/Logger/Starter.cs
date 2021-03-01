using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Starter
    {
        private const string FilePath = "log.txt";
        private readonly Random _rand = new Random();
        private readonly Actions _action = new Actions();
        private readonly LogicofLogger _logicofLogger;
        private readonly FileService _fileService;
        private int _minvalue = 0;
        private int _maxvalue = 3;
        public Starter()
        {
            _logicofLogger = LogicofLogger.Instance;
            _fileService = new FileService();
        }

        public void Run()
        {
            var text = 0;
            for (int i = 0; i < 100; i++)
            {
                var result = new Result();
                text = _rand.Next(_minvalue, _maxvalue);
                switch (text)
                {
                    case 1:
                        result = _action.SkippedLogic();
                        break;
                    case 2:
                        result = _action.StartMethod();
                        break;
                    case 3:
                        result = _action.BrokeLogic();
                        break;
                }

                if (!result.Status)
                {
                    _logicofLogger.ShowEror($" Action failed by a reason {result.Massage}");
                }

                _fileService.WriteFile(FilePath, _logicofLogger.Log);
            }
        }
    }
}
