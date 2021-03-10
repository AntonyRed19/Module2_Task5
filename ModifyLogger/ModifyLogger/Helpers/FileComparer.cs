using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifyLogger.Helpers
{
    public class FileComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var fileInfoOld = x as Models.File;
            var fileInfoNew = y as Models.File;

            var fileInfoOldTimeSpan = DateTime.UtcNow - fileInfoOld.CreateTime;
            var fileInfoNewTimeSpan = DateTime.UtcNow - fileInfoNew.CreateTime;
            if (fileInfoOldTimeSpan > fileInfoNewTimeSpan)
            {
                return -1;
            }

            if (fileInfoOldTimeSpan < fileInfoNewTimeSpan)
            {
                return 1;
            }

            return 0;
        }
    }
}
