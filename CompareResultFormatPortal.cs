using BillyNaCl.QQGroupToolkit.Interfaces;
using BillyNaCl.DI.Core;

namespace BillyNaCl.QQGroupToolkit
{
    internal class CompareResultFormatPortal : ICompareResultFormat
    {
        public string Format(
            ICompareResult result,
            bool jaccard,
            bool members,
            bool members_details,
            string format) => format.ToLower() switch
            {
                "gfr" => DefaultGlobalDIContainer.GetDefaultGlobalDIContainer()
                .GetService<ICompareResultFormatGoodForRead>()
                .Foramt(result, jaccard, members, members_details),

                _ => throw new ArgumentOutOfRangeException(nameof(format), "Invalid format")
            };
    }
}
