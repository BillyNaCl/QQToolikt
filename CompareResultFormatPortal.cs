using BillyNaCl.QQGroupToolkit.Interfaces;
using BillyNaCl.QQGroupToolkit.Interfaces.CompareResultFormatInterfaces;
using BillyNaCl.DI.Core;
using BillyNaCl.DI.Core.Interfaces;


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
                "gfr" => DIContainer.GetService<ICompareResultFormatGoodForRead>()
                    .Foramt(result, jaccard, members, members_details),

                _ => throw new ArgumentOutOfRangeException(nameof(format), "Invalid format")
            };
    }
}
