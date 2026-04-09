using BillyNaCl.QQGroupToolkit.Interfaces.CommandExecutor;
using BillyNaCl.DIContainer.Core.StaticGlobalDIContainerGateway;
using BillyNaCl.QQGroupToolkit.CommandExecutor;
using BillyNaCl.QQGroupToolkit.Interfaces;
using BillyNaCl.QQGroupToolkit.Interfaces.CompareResultFormatInterfaces;

namespace BillyNaCl.QQGroupToolkit
{
    internal class CompareCommandExecutor : ICompareCommandExecutor
    {
        public string Execute(string[] opt_or_args)
        {
            CompareCommandLexer lexer = new();
            var optArgsPair = lexer.Grouping(opt_or_args);
            var compareResult = DI.GetService<ICompare>().Compare(int.Parse(optArgsPair["-"][0]), int.Parse(optArgsPair["-"][0]));
            return DI.GetService<ICompareResultFormat>().Format(compareResult, bool.Parse(optArgsPair["jaccard"][0]), bool.Parse(optArgsPair["member"][0]), bool.Parse(optArgsPair["member-details"][0]), optArgsPair["format"][0]);
        }
    }
}
