using System.Collections.Generic;

namespace ProjetoUFCD1790.App.Model
{
    public class PerguntaModel
    {
     
        public int id { get; set; }
   
        public string textoPergunta { get; set; }
       
        public int id_categoria { get; set; }
        public List<RespostaModel> respostas { get; set; }

        public int? respostaSelecionadaId { get; set; } //guarda a resposta escolhida
    }
}
