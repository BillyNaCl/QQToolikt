using BillyNaCl.DIContainer.Core.Interfaces;
using BillyNaCl.QQGroupToolkit;
using BillyNaCl.QQGroupToolkit.Interfaces.CompareResultFormatInterfaces;
using BillyNaCl.QQGroupToolkit.Interfaces.CommandExecutor;
using BillyNaCl.QQGroupToolkit.CommandExecutor;
using BillyNaCl.QQGroupToolkit.Interfaces;

namespace BillyNaCl.DIContainer.Core
{
    internal class DefaultGlobalDIContainer : IDIContainer
    {
        static private IDIContainer? _defultGlobaContainer = null;

        private readonly Dictionary<Type, Func<object>> _factories = [];

        public DefaultGlobalDIContainer()
        {
            RegisterDefaultConfig();
        }

        private void RegisterDefaultConfig()
        {
            Register<ICompareResultFormat>(() => new CompareResultFormatPortal());
            Register<ICommandPortal>(() => new CommandPortal());
            Register<ICompareCommandExecutor>(() => new CompareCommandExecutor());
            Register<ICompare>(() => new QQGroupComparator());
            Register<IGetGroupMembers>(() => new DataFetcher());
            Register<IHTTPClientService>(() => new HTTPClientService());
            Register<IURLBuilder>(() => new URLBuilder());
            Register<IConfigProvider>(() => new DefaultComfig());
            Register<IGetGroupInfo>(() => new DataFetcher());
            Register<ICompareResultFormatGoodForRead>(() => new CompareResultFormatGoodForRead());
        }

        public void Register<T>(Func<T> factoryMethod) where T : class
        {
            if (_factories.ContainsKey(typeof(T)))
                _factories[typeof(T)] = factoryMethod;
            else
                _factories.Add(typeof(T), factoryMethod);
        }

        public T GetService<T>()
        {
            if (_factories.ContainsKey(typeof(T)))
                return (T)_factories[typeof(T)]();
            else
                throw new InvalidOperationException($"Type {typeof(T).Name} is not registered in the DI container.");
        }

        static public IDIContainer GetDefaultGlobalDIContainer() 
            => _defultGlobaContainer ??= new DefaultGlobalDIContainer();
    }
}
