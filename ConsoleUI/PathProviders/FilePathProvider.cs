using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;

namespace ConsoleUI.PathProviders
{
    /// <summary>
    /// Class for providing paths to files from App.config.
    /// </summary>
    class FilePathProvider : IPathProvider
    {
        #region Fields
        private const string defaultSourceFilePath = "addresses.txt";
        private const string defaultTargetFilePath = "addresses.xml";
        #endregion

        #region Public methods
        /// <summary>
        /// Gets path of source file.
        /// </summary>
        /// <returns>path of source file</returns>
        public string GetSourcePath()
        {
            return GetPath("sourceFilePath", defaultSourceFilePath);
        }

        /// <summary>
        /// Gets path of target xml file.
        /// </summary>
        /// <returns>path of target xml file</returns>
        public string GetTargetPath()
        {
            return GetPath("xmlFilePath", defaultTargetFilePath);
        }
        #endregion

        #region Private methods
        private string GetPath(string key, string defaulFileName)
        {
            string path = string.Empty;
            try
            {
                path = System.Configuration.ConfigurationManager.AppSettings[key];
            }
            catch (Exception)
            {
                path = defaulFileName;
            }

            return path;
        }
        #endregion
    }
}
