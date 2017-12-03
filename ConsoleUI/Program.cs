using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Logic;
using CustomLogger;
using ConsoleUI.PathProviders;
using Ninject;
using Mapper;
using System.Xml.Linq;

namespace ConsoleUI
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {
            IPathProvider pathProvider = new FilePathProvider();
            string sourceFilePath = pathProvider.GetSourcePath();
            string targetFilePath = pathProvider.GetTargetPath();

            IDataProvider dataProvider = resolver.Get<IDataProvider>(new Ninject.Parameters.ConstructorArgument("filePath", sourceFilePath));
            ILogger logger = resolver.Get<ILogger>();
            var firstP = new Ninject.Parameters.ConstructorArgument("dataProvider", dataProvider);
            var secondP = new Ninject.Parameters.ConstructorArgument("logger", logger);

            Converter<XDocument> converter = resolver.Get<Converter<XDocument>>(firstP, secondP);

            Console.WriteLine(converter.Convert());
            converter.SaveToFile(targetFilePath);
        }
    }
}
