using BillyNaCl.DIContainer.Core.Interfaces;
using BillyNaCl.QQGroupToolkit;
using BillyNaCl.QQGroupToolkit.Interfaces.CompareResultFormatInterfaces;

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
