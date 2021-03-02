using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class BusinessException : Exception
    {
        public string Massage { get; set; }

        public bool Status { get; set; }
    }
}
