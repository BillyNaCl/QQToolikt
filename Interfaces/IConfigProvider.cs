namespace BillyNaCl.QQGroupToolkit.Interfaces
{
    internal interface IConfigProvider
    {
        /// <summary>
        /// 获取协议
        /// </summary>
        /// <returns>协议</returns>
        string GetProtocol();

        /// <summary>
        /// 获取端口号
        /// </summary>
        /// <returns>端口号</returns>
        int GetPort();
    }
}
