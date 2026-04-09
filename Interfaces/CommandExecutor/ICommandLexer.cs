namespace BillyNaCl.QQGroupToolkit.Interfaces.CommandExecutor
{
    internal interface ICommandLexer
    {
        /// <summary>
        /// 处理输入的参数与选项，按照{选项:参数表}的形式分组
        /// </summary>
        /// <param name="optsOrArgs">参数和选项的列表</param>
        /// <returns>分组后的字典</returns>
        Dictionary<string, string[]> Grouping(string[] optsOrArgs);
    }
}
