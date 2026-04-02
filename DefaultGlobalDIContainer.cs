using BillyNaCl.DIContainer.Core.Interfaces;

namespace BillyNaCl.DIContainer.Core
{
    internal class DefaultGlobalDIContainer : IDIContainer
    {
        static private IDIContainer? defultGlobaContainer = null;

        public T GetService<T>()
        {
            // TODO: 实现这个方法
            throw new NotImplementedException();
        }

        static public IDIContainer GetDefaultGlobalDIContainer() 
            => defultGlobaContainer ??= new DefaultGlobalDIContainer();
    }
}
