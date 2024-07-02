using Microsoft.ML;
using ChatBot.Models;
using ChatBot.Business.Interface;
using ChatBot.Repository.ChatBot.Models;
using ChatBot.Repository.Interface;

namespace ChatBot.Moldels.Services
{
    public class PerguntaService : IPerguntaService
    {
        private readonly PredictionEngine<PerguntaData, PerguntaPrediction> _predictionEngine;
        private readonly List<PerguntaData> _perguntas;

        public PerguntaService(IPerguntaRepository perguntaRepository)
        {
            var mlContext = new MLContext();
            _perguntas = perguntaRepository.ObterTodasPerguntas().ToList();
            var dados = mlContext.Data.LoadFromEnumerable(_perguntas);

            var pipeline = mlContext.Transforms.Conversion.MapValueToKey("Label", "Categoria")
                .Append(mlContext.Transforms.Text.FeaturizeText("Pergunta", "Features"))
                .Append(mlContext.Transforms.Concatenate("Features", "Features"))
                .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel", "Label"));

            var modelo = pipeline.Fit(dados);
            _predictionEngine = mlContext.Model.CreatePredictionEngine<PerguntaData, PerguntaPrediction>(modelo);
        }

        public string ObterCategoria(string pergunta)
        {
            var prediction = _predictionEngine.Predict(new PerguntaData { Pergunta = pergunta });
            return prediction.Categoria;
        }

        public string ObterResposta(string pergunta)
        {
            var categoria = ObterCategoria(pergunta);
            var resposta = _perguntas.FirstOrDefault(q => q.Categoria == categoria)?.Resposta;

            if (resposta != null && resposta.Contains("{hora}"))
            {
                resposta = resposta.Replace("{hora}", System.DateTime.Now.ToShortTimeString());
            }

            return resposta ?? "Não tenho certeza de como responder isso.";
        }
    }
}
