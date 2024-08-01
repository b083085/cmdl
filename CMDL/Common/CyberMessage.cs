using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMDL.Common
{
    public static class CyberMessage
    {
        public static string GetException(Exception ex)
        {
            if (ex.InnerException == null)
                return ex.Message;

            return GetException(ex.InnerException);
        }
    }
}
