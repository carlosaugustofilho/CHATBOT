using Microsoft.ML.Data;

namespace ChatBot.Models
{
    public class PerguntaPrediction
    {
        [ColumnName("PredictedLabel")]
        public string Categoria { get; set; }
    }
}
