using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UtilityLogger
{
    public class ErrorLogger
    {
        public void logger(Exception _errorToWrite)
        {

            String message = string.Format("Time: {0}", DateTime.Now.ToString(""));
            message += Environment.NewLine;
            message += "-------------------------------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("message {0}", _errorToWrite.Message);
            message += Environment.NewLine;
            message += string.Format("stack trace{0}", _errorToWrite.StackTrace);
            message += Environment.NewLine;
            message += string.Format("source:{0}", _errorToWrite.Source);
            message += Environment.NewLine;
            message += string.Format("target site {0}", _errorToWrite.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-------------------------------------------------------------------------------";
            message += Environment.NewLine;
            using (StreamWriter writer = new StreamWriter("C:\\Users\\admin2\\Desktop\\errorLog.txt"))
            {
                writer.WriteLine(message);
            }
        }
    }
}
