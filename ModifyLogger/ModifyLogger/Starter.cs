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
        private const string FilePath = "C:\\Users\\Antony\\source\\repos\\AntonyRed19\\Module2_Task5\\Logger\\Logger\\bin\\Debug\\net5.0\\Files\\Logfile.txt";
        private readonly Random _rand = new Random();
        private readonly Actions _action = new Actions();
        private readonly Logger _logicofLogger;
        private readonly FileService _fileService;
        private int _minvalue = 0;
        private int _maxvalue = 3;
        public Starter()
        {
            _logicofLogger = Logger.Instance;
            _fileService = FileService.Instance;
        }

        public void Run()
        {
            var text = 0;
            for (int i = 0; i < 100; i++)
            {
                var business = new BusinessException();
                var exp = new Exception();
                text = _rand.Next(_minvalue, _maxvalue);
                switch (text)
                {
                    case 1:
                       business = _action.SkippedLogic();
                       _logicofLogger.ShowWarning($" Action got this custom Exception : {business.Message}");
                       break;
                    case 2:
                       _action.StartMethod();
                       break;
                    case 3:
                       _action.BrokeLogic();
                       _logicofLogger.ShowEror($" Action failed by reason : {exp.Message}");
                       break;
                }

                _fileService.WriteFile(FilePath, _logicofLogger.Log);
            }

            _fileService.CreateDirectory();
        }
    }
}
