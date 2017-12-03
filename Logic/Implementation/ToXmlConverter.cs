using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Logic.Interfaces;
using CustomLogger;

namespace Logic
{
    /// <summary>
    /// Class for converting url-s to xml format.
    /// </summary>
    public class UrlToXMLConverter : Converter<XDocument>
    {
        #region Fields
        private ILogger logger;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dataProvider">Provider of data.</param>
        /// <param name="logger">Logger.</param>
        public UrlToXMLConverter(IDataProvider dataProvider, ILogger logger)
        {
            this.dataProvider = dataProvider;
            this.logger = logger;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Logger.
        /// </summary>
        public ILogger Logger
        {
            set => this.logger = value ?? throw new ArgumentNullException("Logger can't be null");
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Converts string from data provider to XDocument.
        /// </summary>
        /// <returns>XML document containig data from data provider.</returns>
        public override XDocument Convert()
        {
            string[] text = dataProvider.GetData();

            if (text == null)
            {
                throw new ArgumentNullException("Text can't be null");
            }

            //if (text.Length == 0)
            //{
            //    throw new ArgumentOutOfRangeException("");
            //}

            XDocument xmlDoc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                new XElement("urlAddresses"));
            for (int i = 0; i < text.Length; i++)
            {
                if (Uri.TryCreate(text[i], UriKind.Absolute, out Uri uri))
                {
                    xmlDoc.Element("urlAddresses").Add(CreateAddressElement(uri));
                }
                else
                {
                    logger.Info("Invalid url pattern: " + text[i]);
                }
            }
            return xmlDoc;
        }

        /// <summary>
        /// Saves data from data provider to xml file.
        /// </summary>
        /// <param name="pathName">Path to the file where to save.</param>
        public override void SaveToFile(string pathName)
        {
            if (string.IsNullOrEmpty(pathName))
            {
                throw new ArgumentNullException("");
            }

            XDocument xmlDoc = Convert();
            xmlDoc.Save(pathName);
        }
        #endregion

        #region Private methods
        private XElement CreateAddressElement(Uri uri)
        {
            XElement element = new XElement("urlAddress",
                new XElement("host", new XAttribute("name", uri.Host)),
                new XElement("uri", 
                    from s in uri.Segments
                    where !s.Equals("/")
                    select new XElement("segment", s.Trim('/'))));
            if (uri.Query != "")
            {
                element.Add(GetParameters(uri));
            }

            return element;
        }

        private XElement GetParameters(Uri uri)
        {
            XElement element = new XElement("parameters");
            string[] arr = uri.Query.Trim('?').Split('&');
            foreach (string s in arr)
            {
                string[] pair = s.Split('=');
                element.Add(new XElement("parameter", 
                    new XAttribute("value", pair[0]), 
                    new XAttribute("key", pair[1])));
            }
            return element;
        }
        #endregion
    }
}
