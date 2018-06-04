using System;
using System.CodeDom.Compiler;

namespace FlightManagerSimulator.DataLayer.DatabaseGenerator
{
    /// <summary>
    /// Contains data for versionning purpose
    /// </summary>
    [GeneratedCode("DatabaseGenerator", "1.0")]
    public class DBFileInfo
    {
        /// <summary>
        /// FileName
        /// </summary>
        public string FileName { get; } = "FlightManagerSimulator.db";

        /// <summary>
        /// CreationDate
        /// </summary>
        public DateTime CreationDate { get; } = DateTime.UtcNow;

        /// <summary>
        /// Migration assembly
        /// </summary>
        public string MigrationsAssembly { get; } = "FlightManagerSimulator.DataLayer";
    }
}
