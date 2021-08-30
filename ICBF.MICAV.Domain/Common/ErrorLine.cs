using System;

namespace ICBF.MICAV.Domain.Common
{
    public class ErrorLine
    {
        public static string GetNumber(Exception e)
        {
            string lineNumber = e.StackTrace?.Substring(e.StackTrace.Length - 7, 7);
            return lineNumber.Replace("line", "linea");
        }
    }
}