
namespace TaleOfCrestoria
{
    class Program
    {
        static void Main(string[] args)
        {
            new InitBot().RunBotAsync().GetAwaiter().GetResult();
        }        
    }
}
