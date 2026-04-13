using BillyNaCl.QQGroupToolkit.Interfaces;
using System.Net;
using System.Text;

namespace BillyNaCl.QQGroupToolkit
{
    internal class URLBuilder : IURLBuilder
    {
        public string BuildURL(string protocol, string host, int? port, string? basePath, string? endpoint, bool https = true)
        {
            StringBuilder urlBuilder = new();
            urlBuilder.Append(https ? "https://" : "http://");
            if (protocol is "One Bot 11")
                throw new NotImplementedException("One Bot 11 is not supported yet.");
            else if (protocol is "Milky")
            {
                urlBuilder.Append(host);
                urlBuilder.Append(port.HasValue ? $":{port}" : string.Empty);
                urlBuilder.Append('/');
                urlBuilder.Append(basePath is null ? string.Empty : basePath + '/');
                urlBuilder.Append(endpoint is null ? string.Empty : endpoint);
            }
            else if (protocol is "Satori")
                throw new NotImplementedException("Satori is not supported yet.");
            else throw new ProtocolViolationException("Protocol is not supported. Only \"One Bot 11\", \"Satori\", and \"Milky\" are supported.");
            return urlBuilder.ToString();
        }
    }
}
