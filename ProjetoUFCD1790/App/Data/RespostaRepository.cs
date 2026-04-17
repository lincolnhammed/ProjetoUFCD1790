using MySql.Data.MySqlClient;
using ProjetoUFCD1790.App.Model;
using ProjetoUFCD1790.App.Utils;
using System.Collections.Generic;


namespace ProjetoUFCD1790.App.Data
{
    public class RespostaRepository
    {
        public List<RespostaModel> ObterRespostasPorPergunta(int idPergunta)
        {
            var respostas = new List<RespostaModel>();

            string query = "SELECT * FROM resposta WHERE id_pergunta = @idPergunta ORDER BY RAND()";

            using (MySqlConnection conn = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@idPergunta", idPergunta);
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        respostas.Add(new RespostaModel
                        {
                            id = reader.GetInt32("id"),
                            textoResposta = reader.GetString("resposta"),
                            correta = reader.GetBoolean("correta"),
                            id_pergunta = reader.GetInt32("id_pergunta")
                        });
                    }
                }
            }

            return respostas;
        }
    }
}
