using System.Collections.Generic;

namespace SimplisticImplementation.Utility
{
    /// <summary>
    /// Simplistic representation of getting supported file extensions.
    /// </summary>
    public static class FileExtention
    {
        public static readonly IEnumerable<string> fileExtensions = new List<string>{ ".txt", ".log", ".md", ".xml" };


        /// <summary>
        /// Check if text file extention is supported
        /// </summary>
        /// <param name="filePath">file to check</param>
        public static bool IsExtentionSupported(string filePath)
        {
            //loop on list extention and return true if any match
            foreach (string extention in FileExtention.fileExtensions)
            {
                if (filePath.EndsWith(extention))
                {
                    return true;
                }
            }
            
            return false;

        }

    }
}
