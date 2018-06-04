using System.IO;
using System.Threading.Tasks;

/// <summary>
/// Tool for reading File
/// </summary>
namespace FileReader.Reader
{
    public class StreamReaderTool
    {
        /// <summary>
        /// Open and read the content of a file
        /// </summary>
        /// <param name="filePath">file to read</param>
        /// <returns></returns>
        public string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
