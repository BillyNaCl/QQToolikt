using BillyNaCl.QQGroupToolkit.Interfaces;
using System.Net.Http;

namespace BillyNaCl.QQGroupToolkit
{
    internal class HTTPClientService : IHTTPClientService
    {
        readonly static HttpClient client = new HttpClient();

        public async Task<HttpResponseMessage> POST(string url, string body)
        {
            var content = new StringContent(body, System.Text.Encoding.UTF8, "application/json");
            System.Diagnostics.Debug.WriteLine($"将发送HTTP请求，方法：POST，URL：{url}，请求体：{body}");
            return await client.PostAsync(url, content);
        }
    }
}
