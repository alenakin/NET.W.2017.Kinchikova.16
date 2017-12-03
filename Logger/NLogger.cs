using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace CustomLogger
{
    /// <summary>
    /// Logger using NLog.
    /// </summary>
    public class NLogger : ILogger
    {
        #region Fields
        private Logger logger;
        #endregion

        #region Public methods
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="className">Name of logger.</param>
        public NLogger(string className)
        {
            logger = LogManager.GetLogger(className);
        }

        /// <summary>
        /// Represents information messages.
        /// </summary>
        /// <param name="message">Message to log.</param>
        public void Info(string message)
        {
            logger.Info(message);
        }
        #endregion
    }
}
