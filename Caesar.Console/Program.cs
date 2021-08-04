using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Caesar.Console
{
    class Program
    {
        private static ITelegramBotClient _botClient;

        static async Task Main(string[] args)
        {
            _botClient = new TelegramBotClient("{{{token}}}");
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;


            _botClient.OnMessage += Bot_OnMessage;
            _botClient.StartReceiving();

            System.Console.WriteLine("Press any key to exit");
            System.Console.ReadKey();

            _botClient.StopReceiving();
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                System.Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                await _botClient.SendTextMessageAsync(chatId: e.Message.Chat, text: "You said:\n" + e.Message.Text
                );
            }
        }
    }
}
