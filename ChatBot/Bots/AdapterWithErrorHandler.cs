using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Builder.TraceExtensions;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ChatBot.Bots
{
    public class AdapterWithErrorHandler : BotFrameworkHttpAdapter
    {
        public AdapterWithErrorHandler(ICredentialProvider credentialProvider, ILogger<BotFrameworkHttpAdapter> logger, IConfiguration configuration)
             : base(credentialProvider)
        {
            OnTurnError = async (turnContext, exception) =>
            {
                logger.LogError($"Exceção capturada: {exception.Message}");

                // Enviar uma mensagem ao usuário
                await turnContext.SendActivityAsync("Desculpe, parece que algo deu errado.");

                // Enviar uma atividade de rastreamento, que será exibida no Bot Framework Emulator
                await turnContext.TraceActivityAsync("Rastreamento de Erro", exception.Message, "https://www.botframework.com/schemas/error", "TurnError");
            };
        }
    }
}
