using ProjetoUFCD1790.App.Data;
using ProjetoUFCD1790.App.Model;
using System.Collections.Generic;


namespace ProjetoUFCD1790.App.Service
{
    public class RespostaService
    {
        private readonly RespostaRepository _respostaRepository = new RespostaRepository();
    
            public List<RespostaModel> getRespostasByPerguntaId(int idPergunta)
            {
                return _respostaRepository.ObterRespostasPorPergunta(idPergunta);
        }
    }
}
