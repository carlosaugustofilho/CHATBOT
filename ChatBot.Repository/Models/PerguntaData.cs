using Microsoft.ML.Data;

namespace ChatBot.Repository
{
    namespace ChatBot.Models
    {
        public class PerguntaData
        {
            [LoadColumn(0)]
            public string Pergunta { get; set; }

            [LoadColumn(1)]
            public string Categoria { get; set; }

            [LoadColumn(2)]
            public string Resposta { get; set; }
        }
    }