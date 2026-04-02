class MainLoop
{
    static void Main()
    {
        while (true)
        {
            string? input = Console.ReadLine();
            if (input is "exit" or "quit" or "q")
            {
                break;
            }
        }
        Console.WriteLine("程序已退出，按任意键关闭此窗口。");
        Console.ReadKey();
    }
}
