using System;
using System.Diagnostics;
using System.IO;

namespace PdfTextExtractor
{
    public class PdfTextExtractor
    {
        public PdfTextExtractor()
        {            
            // check java is installed
        }

        /// <summary>
        /// Extracts text from specified PDF file to particular text file.
        /// </summary>
        /// <param name="pdfFilePath">The path to PDF File.</param>
        /// <param name="outputTextFilePath">The path to text file with extracted text from PDF.</param>
        public void ExtractTextToFile(string pdfFilePath, string outputTextFilePath)
        {
            this.ExtractTextToFile(pdfFilePath, outputTextFilePath, 1, Int32.MaxValue);
        }

        /// <summary>
        /// Extracts text from specified PDF file between definied start page and end page to particular text file.
        /// </summary>
        /// <param name="pdfFilePath">The path to PDF File.</param>
        /// <param name="outputTextFilePath">The path to text file with extracted text from PDF.</param>
        /// <param name="startPage">The first page to extract.</param>
        /// <param name="endPage">The last page to extract.</param>
        public void ExtractTextToFile(string pdfFilePath, string outputTextFilePath, int startPage, int endPage)
        {
            this.RunCommand(string.Format("java -jar pdfbox-app-2.0.6.jar ExtractText {0} {1} -startPage {2} -endPage {3}", pdfFilePath, outputTextFilePath, startPage, endPage));
        }

        /// <summary>
        /// Extracts text from specified PDF file to string data type.
        /// </summary>
        /// <param name="pdfFilePath">The path to PDF File.</param>
        /// <returns>The string with extracted text from PDF File.</returns>
        public string ExtractTextToString(string pdfFilePath)
        {
            return this.ExtractTextToString(pdfFilePath, 1, Int32.MaxValue);
        }

        /// <summary>
        /// Extracts text from specified PDF file between definied start page and end page to string data type.
        /// </summary>
        /// <param name="pdfFilePath">The path to PDF File.</param>
        /// <param name="startPage">The first page to extract.</param>
        /// <param name="endPage">The last page to extract.</param>
        /// <returns>The string with extracted text from PDF File.</returns>
        public string ExtractTextToString(string pdfFilePath, int startPage, int endPage)
        {
            var output = this.RunCommand(string.Format("java -jar pdfbox-app-2.0.6.jar ExtractText {0} -console -encoding UTF-8 -startPage {1} -endPage {2}", pdfFilePath, startPage, endPage));
            return output;
        }

        /// <summary>
        /// Extracts text from specified PDF file to html file with the same name as source pdf file.
        /// </summary>
        /// <param name="pdfFilePath">The path to PDF File.</param>
        public void ExtractTextToHtml(string pdfFilePath)
        {
            this.ExtractTextToHtml(pdfFilePath, 1, Int32.MaxValue);
        }

        /// <summary>
        /// Extracts text from specified PDF file between definied start page and end page  to html file with the same name as source pdf file.
        /// </summary>
        /// <param name="pdfFilePath">The path to PDF File.</param>
        /// <param name="startPage">The first page to extract.</param>
        /// <param name="endPage">The last page to extract.</param>
        public void ExtractTextToHtml(string pdfFilePath, int startPage, int endPage)
        {
            this.RunCommand(string.Format("java -jar pdfbox-app-2.0.6.jar ExtractText {0} -html -startPage {1} -endPage {2}", pdfFilePath, startPage, endPage));
        }

        #region Private methods

        private string RunCommand(string command)
        {            
            var process = new Process();
            var startInfo = new ProcessStartInfo();        
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;           
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.WorkingDirectory = "PdfBoxTool";
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = string.Format("/c {0}", command);
            process.StartInfo = startInfo;
            
            var result = process.Start();
            StreamReader reader = process.StandardOutput;
            var output = reader.ReadToEnd();
            process.WaitForExit();
            process.Close();

            return output;
        }

        #endregion
    }
}
