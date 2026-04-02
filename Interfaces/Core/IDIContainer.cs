namespace BillyNaCl.DI.Core.Interfaces
{
    internal interface IDIContainer
    {
        /// <summary>
        /// 获取接口的实例
        /// </summary>
        /// <typeparam name="T">需要的接口类型</typeparam>
        /// <returns>注册到DI容器的接口的实例</returns>
        T GetService<T>();
    }
}
