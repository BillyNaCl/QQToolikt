using BillyNaCl.DIContainer.Core.Interfaces;
using BillyNaCl.DIContainer.Core;

namespace BillyNaCl.DIContainer.Core.StaticGlobalDIContainerGateway
{
    static class DI
    {
        public static IDIContainer Get() 
            => DefaultGlobalDIContainer.GetDefaultGlobalDIContainer();

        public static T GetService<T>() => Get().GetService<T>();
    }
}
