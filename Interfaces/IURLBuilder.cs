using System.Net;

namespace BillyNaCl.QQGroupToolkit.Interfaces;

internal interface IURLBuilder
{
    /// <summary>
    /// 构建LLBot的API请求URL
    /// </summary>
    /// <param name="protocol">使用的协议（支持OneBot11、Milky、Satori）</param>
    /// <param name="host">域名</param>
    /// <param name="basePath">路径前缀</param>
    /// <param name="endpoint">端点</param>
    /// <param name="https">是否使用HTTPS，如果不使用，则使用HTTP</param>
    /// <returns>构建出的BuildURL</returns>
    string BuildURL(string protocol, string host, int? port = null, string? basePath = null, string? endpoint = null, bool https = true);
}

internal static class URLBuilderExtensions
{
    public static string BuildLocalHostURL(this IURLBuilder urlBuilder, string protocol, int? port = null, string? basePath = null, string? endpoint = null, bool https = false)
    {
        return urlBuilder.BuildURL(protocol, "127.0.0.1", port, basePath, endpoint, https);
    }
}
