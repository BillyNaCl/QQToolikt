using BillyNaCl.DIContainer.Core.StaticGlobalDIContainerGateway;
using BillyNaCl.QQGroupToolkit.Interfaces.CommandExecutor;

namespace BillyNaCl.QQGroupToolkit
{
    internal class CommandPortal : ICommandPortal
    {
        public string Execute(string command)
        {
            var command_split = command.Split(' ');
            var command_name = command_split[0];
            var opt_or_args = command_split[1..];
            return command_name.ToLower() switch
            {
                "compare" => DI.GetService<ICompareCommandExecutor>().Execute(opt_or_args),

                _ => throw new CommandExcption("Invalid command name.")
            };
        }
    }
}

