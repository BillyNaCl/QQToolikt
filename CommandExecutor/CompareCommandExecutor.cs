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
            var compareResult = DI.GetService<ICompare>().Compare(int.Parse(optArgsPair["-"][0]), int.Parse(optArgsPair["-"][1]));
            // TODO: 这里解析命令的方式也太丑陋了，最好提炼出一个参数类
            //return DI.GetService<ICompareResultFormat>().Format(compareResult, optArgsPair.ContainsKey("jaccard"), optArgsPair.ContainsKey("member"), optArgsPair.ContainsKey("member-details"), optArgsPair["format"][0]);
            // TODO: 记得把这里的硬编码参数换成真实的参数
            return DI.GetService<ICompareResultFormat>().Format(compareResult, true, true, true, "gfr");
        }
    }
}
