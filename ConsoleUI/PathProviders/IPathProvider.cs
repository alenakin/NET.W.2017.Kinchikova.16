using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.PathProviders
{
    /// <summary>
    /// Interface for path providers.
    /// </summary>
    public interface IPathProvider
    {
        /// <summary>
        /// Gets path of source file.
        /// </summary>
        /// <returns>path of source file</returns>
        string GetSourcePath();

        /// <summary>
        /// Gets path of target xml file.
        /// </summary>
        /// <returns>path of target xml file</returns>
        string GetTargetPath();
    }
}
