using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccineMatchDBSource
{
    public class logger
    {
        public static void WriteLog(Exception ex)
        {
            string msg = $@"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}
                        {ex.ToString()}
                ";

            string logPath = ("C:\\Logs\\FinalProject\\Log.log");
            string folderPath = System.IO.Path.GetDirectoryName(logPath);

            if (!System.IO.Directory.Exists(folderPath))
                System.IO.Directory.CreateDirectory(folderPath);

            if (!System.IO.File.Exists(logPath))
                System.IO.File.Create(logPath);

            System.IO.File.AppendAllText(logPath, msg);

            throw ex;
        }
    }
}
