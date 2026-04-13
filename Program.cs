using BillyNaCl.DIContainer.Core.StaticGlobalDIContainerGateway;
using BillyNaCl.QQGroupToolkit.Interfaces.CommandExecutor;

class MainLoop
{
    static void Main()
    {
        while (true)
        {
            Console.Write("请输入命令：");
            string? input = Console.ReadLine();
            if (input is "exit" or "quit" or "q")
            {
                break;
            }
            if (input is not null)
                Console.WriteLine(DI.GetService<ICommandPortal>().Execute(input));
        }
        Console.WriteLine("程序已退出，按任意键关闭此窗口。");
        Console.ReadKey();
    }
}
