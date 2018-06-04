using NUnit.Framework;
using System;

namespace FileReader.Test.Common
{
    /// <summary>
    /// Custom attribute which identify test that must succeed before mergin
    /// Usefull in continuous integration
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class CrucialTestAttribute : CategoryAttribute
    {
        /// <summary>
        /// Builds a new CrucialTest with the "CrucialTest" Name
        /// </summary>
        public CrucialTestAttribute()
            : base("CrucialTest")
        {
        }
    }
}
