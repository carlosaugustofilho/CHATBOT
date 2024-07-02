using ChatBot.Repository.ChatBot.Models;
using ChatBot.Repository.Interface;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace ChatBot.Repository.Repository
{
    public class PerguntaRepository : IPerguntaRepository
    {
        private readonly string _caminhoDados = Path.Combine(System.Environment.CurrentDirectory, "Data", "questions.csv");

        public IEnumerable<PerguntaData> ObterTodasPerguntas()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                Encoding = Encoding.UTF8
            };

            using (var leitor = new StreamReader(_caminhoDados))
            using (var csv = new CsvReader(leitor, config))
            {
                return csv.GetRecords<PerguntaData>().ToList();
            }
        }
    }
}
