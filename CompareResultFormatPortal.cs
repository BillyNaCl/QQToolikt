using BillyNaCl.QQGroupToolkit.Interfaces;
using BillyNaCl.QQGroupToolkit.Interfaces.CompareResultFormatInterfaces;
using BillyNaCl.DIContainer.Core;
using BillyNaCl.DIContainer.Core.Interfaces;
using BillyNaCl.DIContainer.Core.StaticGlobalDIContainerGateway;

namespace BillyNaCl.QQGroupToolkit
{
    internal class CompareResultFormatPortal : ICompareResultFormat
    {
        readonly IDIContainer DIContainer = DefaultGlobalDIContainer.GetDefaultGlobalDIContainer();

        public string Format(
            ICompareResult result,
            bool jaccard = false,
            bool members = false,
            bool members_details = false,
            string format = "gfr") => format.ToLower() switch
            {
                "gfr" => DI.GetService<ICompareResultFormatGoodForRead>()
                    .Foramt(result, jaccard, members, members_details),

                "json" => DI.GetService<ICompareResultFormatJson>()
                    .Foramt(result, jaccard, members, members_details),

                "xml" => DI.GetService<ICompareResultFormatXML>()
                    .Foramt(result, jaccard, members, members_details),

                "yaml" => DI.GetService<ICompareResultFormatYAML>()
                    .Foramt(result, jaccard, members, members_details),

                _ => throw new ArgumentOutOfRangeException(nameof(format), "Invalid format")
            };
    }
}
