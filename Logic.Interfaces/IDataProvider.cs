using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    /// <summary>
    /// Class for providing data.
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// Gets data.
        /// </summary>
        /// <returns>Data from provider.</returns>
        string[] GetData();
    }
}
