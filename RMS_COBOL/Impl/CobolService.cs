using RMS_DAL.Enum;
using RMS_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS_COBOL.Impl
{
    public class CobolService : ICobolService
    {


        public void WriteLog(int action, string contentsValue, string path)
        {
            string text = contentsValue + ", " + DateTime.Now.ToString();
            string appPath = path;
            // Write the text to the file


            string sAccessLogCobolProgram = string.Empty;
            if (action == (int)Cobol.EMPLOYEELISTTOCSV)
            {
                sAccessLogCobolProgram = path + "EMPLOYEE-LIST-TO-CSV.exe";
            }
            else if (action == (int)Cobol.LOGTOCSV)
            {
                sAccessLogCobolProgram = path + "LOGS-TO-CSV.exe";
            }
            else if (action == (int)Cobol.LOGTONOTEPAD)
            {
                sAccessLogCobolProgram = path + "LOG-TO-NOTEPAD.exe";
            }
            else if (action == (int)Cobol.TRAININGTOCSV)
            {
                sAccessLogCobolProgram = path + "TRAINING-TO-CSV.exe";
            }
            else if (action == (int)Cobol.TRANSLOG)
            {
                sAccessLogCobolProgram = appPath + "TRANS-LOG.exe";
                path = path + "\\TRANS-LOG.txt";
                File.WriteAllText(appPath, text);
            }

            Process procCobol = new Process();

            procCobol.StartInfo.FileName = sAccessLogCobolProgram;
            procCobol.StartInfo.UseShellExecute = false;
            procCobol.StartInfo.RedirectStandardInput = true;
            procCobol.StartInfo.RedirectStandardOutput = true;
            procCobol.Start();
            procCobol.WaitForExit();


            //try
            //{
            //    // Write the combined bytes to the COBOL program's standard input
            //    //procCobol.StandardInput.BaseStream.Write(byteCombinedBytes, 0, byteCombinedBytes.Length);
            //    //procCobol.StandardInput.BaseStream.Flush();
            //    //procCobol.StandardInput.Close();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.ToString());
            //}
            //finally
            //{
            //    procCobol.WaitForExit();
            //    Console.WriteLine("Data has been passed to the COBOL program.");
            //}

        }
    }
}
