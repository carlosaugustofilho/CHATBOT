namespace ChatBot.Business.Interface
{
    public interface IPerguntaService
    {
        string ObterCategoria(string pergunta);
        string ObterResposta(string pergunta);
    }
}