using BillyNaCl.QQGroupToolkit.Interfaces.CommandExecutor;

namespace BillyNaCl.QQGroupToolkit.CommandExecutor
{
    internal class CompareCommandLexer : ICommandLexer
    {
        public Dictionary<string, string[]> Grouping(string[] optsOrArgs)
        {
            var index = 0;
            Dictionary<char, string> optShort2Long = new()
            {
                {'j', "jaccard" },
                {'m', "members" },
                {'M', "members-details" },
                {'f', "format" }
            };
            Dictionary<string, string[]> result = [];
            while (index < optsOrArgs.Length)
            {
                var current_option = optsOrArgs[index];
                if (current_option[0] == '-')
                {
                    if (current_option[1] == '-')
                    {
                        current_option = current_option[2..];
                        result = (Dictionary<string, string[]>)result.Union(OptArgsPairs(optsOrArgs, current_option, ref index));
                    }
                    else
                    {
                        foreach (var opt in current_option[1..])
                        {
                            current_option = optShort2Long[opt];
                            result = (Dictionary<string, string[]>)result.Union(OptArgsPairs(optsOrArgs, current_option, ref index));
                        }
                    }
                }
                else
                {
                    if (result.TryGetValue("-", out var argeOfCommand))
                    {
                        var temp_list = argeOfCommand.ToList();
                        temp_list.Add(current_option);
                        result["-"] = [.. temp_list];
                    }
                }
            }
            return result;
        }

        private static Dictionary<string, string[]> OptArgsPairs(string[] opt_or_args, string current_option, ref int index)
        {
            Dictionary<string, int> optArgsNumber = new()
            {
                {"jaccard", 0 },
                {"members", 0 },
                {"members-details", 0},
                {"format", 1 }
            };
            Dictionary<string, string[]> result = [];
            if (optArgsNumber.TryGetValue(current_option, out int argsNumber))
            {
                if (argsNumber == 0)
                    result.Add(current_option, []);
                else if (argsNumber > 0)
                {
                    var args = new string[argsNumber];
                    var offset = 0;
                    while (offset < argsNumber)
                    {
                        index++;
                        if (index < opt_or_args.Length)
                        {
                            if (opt_or_args[index][0] == '-')
                                throw new CommandExcption($"The option {current_option} has the wrong number of arguments. It should have {argsNumber} arguments.");
                            else
                            {
                                args[offset] = opt_or_args[index];
                                offset++;
                            }
                        }
                    }
                }
                else throw new CommandExcption($"The arguement count of option {current_option} is negative. It must be a non-negative integer.");
            }
            index++;
            return result;
        }
    }
}
