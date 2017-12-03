using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Ninject;
using CustomLogger;
using Logic;
using Logic.Interfaces;

namespace Mapper
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IDataProvider>().To<FileDataProvider>();
            kernel.Bind<ILogger>().To<NLogger>().WithConstructorArgument("ToXmlConverter");
            kernel.Bind<Converter<XDocument>>().To<UrlToXMLConverter>();
        }
    }
}
