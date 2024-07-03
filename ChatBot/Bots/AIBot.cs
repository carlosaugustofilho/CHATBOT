using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using ChatBot.Business.Interface;

namespace ChatBot.Bots
{
    public class AIBot : ActivityHandler
    {
        private readonly IPerguntaService _perguntaService;

        public AIBot(IPerguntaService perguntaService)
        {
            _perguntaService = perguntaService;
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var mensagemUsuario = turnContext.Activity.Text;
            var resposta = _perguntaService.ObterResposta(mensagemUsuario);

            await turnContext.SendActivityAsync(MessageFactory.Text(resposta), cancellationToken);
        }
    }
}
