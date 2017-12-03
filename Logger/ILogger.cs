using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLogger
{
    /// <summary>
    /// Interface fot logger.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Represents information messages.
        /// </summary>
        /// <param name="message">Message to log.</param>
        void Info(string message);
    }
}
