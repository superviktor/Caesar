using System.Threading;
using Telegram.Bot;

namespace Caesar.Console
{
    class Program
    {
        private static ITelegramBotClient _botClient;

        static void Main(string[] args)
        {
            _botClient = new TelegramBotClient("{{{token}}");

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var messageReceivedHandler = new MessageReceivedHandler();

            _botClient.StartReceiving(messageReceivedHandler, cancellationToken);

            System.Console.WriteLine("Press any key to exit");
            System.Console.ReadKey();
        }
    }
}
