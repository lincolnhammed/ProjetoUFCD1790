using ProjetoUFCD1790.App.Data;
using ProjetoUFCD1790.App.Model;
using System.Collections.Generic;

namespace ProjetoUFCD1790.App.Service
{
    
    public class PerguntaService
    {
        private PerguntaRepository perguntaRepository = new PerguntaRepository();

        public List<PerguntaModel> getPerguntas(int idCategoria)
        {
                
            return perguntaRepository.ObterPerguntasPorCategoria(idCategoria);
        }

    }
}
