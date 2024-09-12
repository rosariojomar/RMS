using RMS_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_COBOL.Impl
{
    public class CobolService : ICobolService
    {

        public void WriteLog(string contentsValue, string location, string actionFilename, int actionFile)
        {

            string path = string.Empty;
            string text = contentsValue + "," + DateTime.Now.ToString();

            //if (actionFile == (int)Action.Login)
            //{
            //    path = location + "\\" + actionFilename + "_COB.txt";
            //}

            // Write the text to the file
            File.WriteAllText(path, text);

            Console.WriteLine("Note written to " + path);
        }

        public void WriteLog(string message)
        {
            throw new NotImplementedException();
        }
    }
}
