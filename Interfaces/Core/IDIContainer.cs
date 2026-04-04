namespace BillyNaCl.DIContainer.Core.Interfaces
{
    internal interface IDIContainer
    {
        /// <summary>
        /// 注册接口的工厂方法
        /// </summary>
        /// <typeparam name="T">被注册的接口的类型</typeparam>
        void Register<T>(Func<T> factoryMethod) where T : class;

        /// <summary>
        /// 获取接口的实例
        /// </summary>
        /// <typeparam name="T">需要的接口类型</typeparam>
        /// <returns>注册到DI容器的接口的实例</returns>
        T GetService<T>();
    }
}
