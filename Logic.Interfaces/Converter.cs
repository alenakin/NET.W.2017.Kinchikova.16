using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    /// <summary>
    /// Class for converting some data to specified type.
    /// </summary>
    /// <typeparam name="T">Type of result of converting</typeparam>
    public abstract class Converter<T>
    {
        protected IDataProvider dataProvider;

        /// <summary>
        /// Provider for data.
        /// </summary>
        public IDataProvider DataProvider
        {
            set => this.dataProvider = value ?? throw new ArgumentNullException("DataProvider can't be null");
        }

        /// <summary>
        /// Coverts data from data provider to specified type.
        /// </summary>
        /// <returns>Result of converting</returns>
        public abstract T Convert();

        /// <summary>
        /// Saves data from data provider to file.
        /// </summary>
        /// <param name="filePath">Path to the file where to save.</param>
        public abstract void SaveToFile(string filePath);
    }
}
