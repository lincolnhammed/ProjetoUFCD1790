using ProjetoUFCD1790.App.Data;
using ProjetoUFCD1790.App.Model;
using ProjetoUFCD1790.App.Utils;
using System;
using System.Collections.Generic;

namespace ProjetoUFCD1790.App.Service
{
    public class ResultadoService
    {



        private RespostaService respostaService;
        private ResultadoRepository resultadoRepository;
        private ResultadoModel resultadoModel;
        public ResultadoService()
        {
            resultadoRepository = new ResultadoRepository();
            respostaService = new RespostaService();
           
        }

        public ResultadoModel CalcularResultado(List<PerguntaModel> perguntas)
        {
            int acertos = 0;

            foreach (var pergunta in perguntas)
            {
                if (pergunta.respostaSelecionadaId != null)
                {
                    var respostas = respostaService.getRespostasByPerguntaId(pergunta.id);

                    foreach (var r in respostas)
                    {
                        if (r.id == pergunta.respostaSelecionadaId && r.correta)
                        {
                            acertos++;
                        }
                    }
                }
            }

            return new ResultadoModel
            {
                TotalPerguntas = perguntas.Count,
                Acertos = acertos,
                Percentagem = (double)acertos / perguntas.Count * 100
            };
        }

        public void SalvarResultado(int IdUsuarioLogado, string nomeCategoria, int nPrgunta, int acertos, double Percentagem)
        {
          
            ResultadoModel resultado = new ResultadoModel
            {
                Categoria = nomeCategoria,
                TotalPerguntas = nPrgunta,
                Acertos = acertos,
                Percentagem = Percentagem,
                Id_userLogado = IdUsuarioLogado
            };
            resultadoRepository.SaveResultado(resultado);
        }

        public List<ResultadoModel> ObterResultadosPorUsuario(int idUsuario)
        {
           
            return resultadoRepository.ResultadosPorUsuario(idUsuario);


        }
    }
}

