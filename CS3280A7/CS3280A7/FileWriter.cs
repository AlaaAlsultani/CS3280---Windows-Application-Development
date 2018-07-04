using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CS3280A7
{
    /// <summary>
    /// Class for writing to files
    /// </summary>
    class FileWriter
    {

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FileWriter() { }

        /// <summary>
        /// Checks to see if provided FilePath is available
        /// </summary>
        /// <param name="FilePath">File Path to check for availability</param>
        /// <returns>boolean representing existance of a file</returns>
        public bool FileExists(String FilePath)
        {
            return File.Exists(FilePath);
        }

        /// <summary>
        /// Write provided Text to provided FilePath
        /// </summary>
        /// <param name="FilePath">Path to which Text should be written</param>
        /// <param name="Text">Text to write to file</param>
        public void WriteToFile(string FilePath, string Text)
        {
            using (StreamWriter FileWriter = new StreamWriter(FilePath))
            {
                FileWriter.WriteAsync(Text);
            }
        }

    }
}
