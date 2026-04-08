namespace BillyNaCl.QQGroupToolkit.Interfaces
{
    internal interface ICommandExecutor<out TResult>
    {
        TResult Execute(string command);
    }
}
