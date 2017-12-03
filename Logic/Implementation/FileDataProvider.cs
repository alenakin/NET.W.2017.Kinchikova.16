using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;

namespace Logic
{
    /// <summary>
    /// Class for providing data from text file.
    /// </summary>
    public class FileDataProvider : IDataProvider
    {
        #region Fields
        private string filePath;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="filePath">Path of the file.</param>
        public FileDataProvider(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentOutOfRangeException("String can't be null or empty.");
            }

            this.filePath = filePath;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Reads data from file.
        /// </summary>
        /// <returns>Array of lines in the file.</returns>
        public string[] GetData()
        {
            var lines = new List<string>();
            string line = string.Empty;
            StreamReader file = new StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }

            file.Close();
            return lines.ToArray();
        }
        #endregion
    }
}
