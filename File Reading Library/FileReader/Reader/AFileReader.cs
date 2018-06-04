using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader.Reader
{
    public abstract class AFileReader
    {
        protected abstract IEnumerable<string> _SupportedExtention { get; set; }

        public AFileReader(IEnumerable<string> supportedextention)
        {
            _SupportedExtention = supportedextention;
        }

        /// <summary>
        /// Check if text file extention is supported
        /// </summary>
        /// <param name="filePath">file to check</param>
        public bool IsExtentionSupported(string filePath)
        {
            //loop on list extention and return true if any match
            foreach (string extention in _SupportedExtention)
            {
                if (filePath.EndsWith(extention))
                {
                    return true;
                }
            }

            return false;

        }

        /// <summary>
        /// file reading metho to implement in derived classes
        /// </summary>
        /// <returns>File content</returns>
        public abstract string ReadFile(string filePath);

        /// <summary>
        /// file validation method to implement in derived classes
        /// </summary>
        /// <returns>boolean indicating if file is valid</returns>
        public abstract bool ValidateFile(string FileContent);
    }
}
