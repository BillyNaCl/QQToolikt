using BillyNaCl.DI.Core.Interfaces;
using BillyNaCl.DI.Core;

namespace BillyNaCl.DI.Core.StaticGlobalDIContainerGateway
{
    static class DI
    {
        public static IDIContainer Get() 
            => DefaultGlobalDIContainer.GetDefaultGlobalDIContainer();

        public static T Service<T>() => Get().GetService<T>();
    }
}
