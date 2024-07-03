using Microsoft.AspNetCore.Mvc;
using ChatBot.Business.Interface;

namespace ChatBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerguntaController : ControllerBase
    {
        private readonly IPerguntaService _perguntaService;

        public PerguntaController(IPerguntaService perguntaService)
        {
            _perguntaService = perguntaService;
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] string pergunta)
        {
            var resposta = _perguntaService.ObterResposta(pergunta);
            return Ok(resposta);
        }
    }
}
