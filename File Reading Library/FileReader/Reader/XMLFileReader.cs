using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileReader.Reader
{
    public class XMLFileReader : AFileReader
    {
        protected override IEnumerable<string> _SupportedExtention { get; set; }

        public XMLFileReader(IEnumerable<string> supportedextention)
            : base(supportedextention)
        {
        }

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

            if (!this.ValidateFile(fileContent))
                throw new FormatException("File is not in the requested format");

            return fileContent;
        }

        public override bool ValidateFile(string fileContent)
        {
            try
            {
                XDocument xmlDocument = new XDocument(fileContent);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
