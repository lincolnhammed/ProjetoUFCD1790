namespace ProjetoUFCD1790.App.Model
{
    public class RespostaModel
    {
        public int id { get; set; }
        public string textoResposta { get; set; }
        public bool correta { get; set; }
        public int id_pergunta { get; set; }
       
    }


}
