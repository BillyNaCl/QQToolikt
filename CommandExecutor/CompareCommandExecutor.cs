using BillyNaCl.QQGroupToolkit.Interfaces.CommandExecutor;
using System;

namespace BillyNaCl.QQGroupToolkit
{
    internal class CompareCommandExecutor : ICompareCommandExecutor
    {
        public string Execute(string[] opt_or_args)
        {
            var index = 0;
            Dictionary<char, string> optShort2Long = new()
            {
                {'j', "jaccard" },
                {'m', "members" },
                {'M', "members-details" },
                {'f', "format" }
            };
            Dictionary<string, int> optArgsNumber = new()
            {
                {"jaccard", 0 },
                {"members", 0 },
                {"members-details", 0},
                {"format", 1 }
            };
            Dictionary<string, string[]> result = [];
            while (index < opt_or_args.Length)
            {
                var current_option = opt_or_args[index];
                if (current_option[0] == '-')
                {
                    if (current_option[1] == '-')
                    {
                        current_option = current_option[2..];
                        result.Union(optArgsPairs(opt_or_args, current_option, ref index));
                    }
                    else
                    {
                        foreach (var opt in current_option[1..])
                        {
                            current_option = optShort2Long[opt];
                            result.Union(optArgsPairs(opt_or_args, current_option, ref index));
                        }
                    }
                }
                else
                {
                    if (result.TryGetValue("-", out var argeOfCommand))
                    {
                        var temp_list = argeOfCommand.ToList();
                        temp_list.Add(current_option);
                        result["-"] = temp_list.ToArray();
                    }
                }
            }
        }

        private static Dictionary<string, string[]> optArgsPairs(string[] opt_or_args, string current_option, ref int index)
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
