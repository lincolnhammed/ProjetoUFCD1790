using MySql.Data.MySqlClient;
using ProjetoUFCD1790.App.Model;
using ProjetoUFCD1790.App.Utils;
using System.Collections.Generic;


namespace ProjetoUFCD1790.App.Data
{
    public class PerguntaRepository
    {
        public List<PerguntaModel> ObterPerguntasPorCategoria(int idCategoria)
        {
            var perguntas = new List<PerguntaModel>();

            string query = "SELECT * FROM pergunta WHERE id_categoria = @idCategoria ORDER BY RAND() limit 10";

            using (MySqlConnection conn = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@idCategoria", idCategoria);// Evita SQL Injection e melhora a legibilidade 
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        perguntas.Add(new PerguntaModel
                        {
                            id = reader.GetInt32("id"),
                            textoPergunta = reader.GetString("pergunta"),
                            id_categoria = reader.GetInt32("id_categoria"),
                            respostas = new List<RespostaModel>() // será preenchido depois
                        });
                    }
                }
            }

            return perguntas;
        }
    }
}
