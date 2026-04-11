namespace BillyNaCl.QQGroupToolkit.Interfaces
{
    internal interface IHTTPClientService
    {
        Task<HttpResponseMessage> POST(string url, string body);
    }
}
