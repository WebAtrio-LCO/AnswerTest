using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Linq;
using SimplisticImplementation.Utility;

namespace FileReader.Reader
{
    /// <summary>
    /// Manage a txet reading
    /// </summary>
    public class TextFileReader : AFileReader
    {
        protected override IEnumerable<string> _SupportedExtention { get; set; }

        public TextFileReader(IEnumerable<string> supportedextention)
            : base(supportedextention)
        {
        }

        /// <summary>
        /// Read the content of a text file
        /// </summary>
        /// <param name="filePath">File to read</param>
        /// <returns>Content of the text file</returns>
        public override string ReadFile(string filePath)
        {
            if (filePath.EndsWith("/") || filePath.EndsWith("\\"))
                throw new ArgumentException("The requested path is not a file");

            //File must exists
            if (!File.Exists(filePath))
                throw new FileNotFoundException(string.Format("Text File {0} does not exist", filePath));

            if (!IsExtentionSupported(filePath))
                throw new ArgumentOutOfRangeException("Specified type is not supported");

            StreamReaderTool streamReaderTool = new StreamReaderTool();
            string fileContent = streamReaderTool.ReadFile(filePath);

            return fileContent;
        }

        public override bool ValidateFile(string fileCntent)
        {
            return true;
        }
    }
}
