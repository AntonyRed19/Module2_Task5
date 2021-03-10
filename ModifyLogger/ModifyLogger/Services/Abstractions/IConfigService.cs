using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModifyLogger.Configs;

namespace ModifyLogger.Services.Abstractions
{
    public interface IConfigService
    {
        LoggerConfig LoggerConfig { get; }
    }
}
