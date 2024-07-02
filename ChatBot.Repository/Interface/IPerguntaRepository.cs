using ChatBot.Repository.ChatBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot.Repository.Interface
{
    public interface IPerguntaRepository
    {
        IEnumerable<PerguntaData> ObterTodasPerguntas();
    }
}
