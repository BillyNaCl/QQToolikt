using BillyNaCl.QQGroupToolkit.Interfaces;

namespace BillyNaCl.QQGroupToolkit
{
    internal class DefaultComfig : IConfigProvider
    {
        public int GetPort() => 3000;

        public string GetProtocol() => "Milky";
    }
}
