using System;

namespace ProjetoUFCD1790.App.Model
{
    public class ResultadoModel
    {
        public string Categoria { get; set; }
        public int TotalPerguntas { get; set; }
        public int Acertos { get; set; }
        public double Percentagem { get; set; }
        public DateTime data_realizacao { get; set; }
        public int Id_userLogado { get; set; }
        public ResultadoModel() { }

       

    }
    
}
