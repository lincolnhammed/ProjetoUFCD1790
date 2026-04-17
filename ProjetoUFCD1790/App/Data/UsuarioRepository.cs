using MySql.Data.MySqlClient;
using ProjetoUFCD1790.App.Forms;
using ProjetoUFCD1790.App.Model;
using ProjetoUFCD1790.App.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoUFCD1790.App.Data
{
    public class UsuarioRepository
    {
        public UsuarioRepository() { }

        public void cadastrarUsuario(string nome, bool nivel, int id_login)
        {

            string query = "INSERT INTO usuario (nome, is_admin,id_login) VALUES (@nome, @is_admin, @id_login)";
            using (MySqlConnection conn = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = nome;
                cmd.Parameters.Add("@is_admin", MySqlDbType.Bit).Value = nivel;
                cmd.Parameters.Add("@id_login", MySqlDbType.Int32).Value = id_login;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao conectar ao banco: " + ex.Message);
                }
            }
        }
        public List<UsuarioModel> ListarUsuariosSimples()
        {
            var usuarios = new List<UsuarioModel>();
            string query = "SELECT id, nome FROM usuario;";

            using (MySqlConnection conn = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var usuario = new UsuarioModel
                            {
                                Id = reader.GetInt32("id"),
                                Nome = reader.GetString("nome"),
                                Nivel = reader.GetBoolean("is_admin")
                            };
                            usuarios.Add(usuario);
                        }
                    }
                    return usuarios;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao conectar ao banco: " + ex.Message);
                }
            }
        }
        public List<UsuarioLoginModel> ListarUsuarios()
        {
            var usuarios = new List<UsuarioLoginModel>();
            string query = "SELECT l.id, u.nome,u.is_admin,l.usuario,l.senha FROM usuario u INNER JOIN login l ON u.id_login = l.id;";

            using (MySqlConnection conn = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var usuario = new UsuarioLoginModel
                            {
                                Id = reader.GetInt32("id"),
                                Nome = reader.GetString("nome"),
                                IsAdmin = reader.GetBoolean("is_admin"),
                                UserName = reader.GetString("usuario"),
                                Password = reader.GetString("senha")
                            };

                            usuarios.Add(usuario);
                        }
                    }
                    return usuarios;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao conectar ao banco: " + ex.Message);
                }
            }


        }
        public bool statusUsuarios()
        {

            string query = @"SELECT u.id, u.nome,u.is_admin,l.usuario,l.senha FROM usuario u INNER JOIN login l ON u.id_login = l.id WHERE u.id = @id";

            using (MySqlConnection conn = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@id", Sessao.IdUsuarioLogado);
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {


                        if (reader.Read())
                        {
                            var usuario = new UsuarioLoginModel
                            {
                                Id = reader.GetInt32("id"),
                                Nome = reader.GetString("nome"),
                                IsAdmin = reader.GetBoolean("is_admin"),
                                UserName = reader.GetString("usuario"),
                                Password = reader.GetString("senha")
                            };

                            return usuario.IsAdmin;
                        }
                        else
                        {
                            return false;
                        }

                    }

                }

                catch (Exception ex)
                {
                    throw new Exception("Erro ao conectar ao banco: " + ex.Message);
                }
            }
        }

        public void atualizarUsuario(int idUsuario, string nome, bool isAdmin, string usuario, string senha)
        {
            string query = "UPDATE usuario u INNER JOIN login l ON u.id_login = l.id SET u.nome = @nome, u.is_admin = @isAdmin, l.usuario = @usuario, l.senha = @senha WHERE u.id_login = @idUsuario";
            using (MySqlConnection conn = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.Add("@idUsuario", MySqlDbType.Int32).Value = idUsuario;
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = nome;
                cmd.Parameters.Add("@isAdmin", MySqlDbType.Bit).Value = isAdmin;
                cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = usuario;
                cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = senha;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao conectar ao banco: " + ex.Message);
                }
            }

        }
        public void ExcluirUsuario(int idUsuario)
        {
            string query = "DELETE FROM usuario WHERE id_login = @idUsuario";
            using (MySqlConnection conn = Database.GetConnection())
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.Add("@idUsuario", MySqlDbType.Int32).Value = idUsuario;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao conectar ao banco: " + ex.Message);
                }
            }
        }
    }
}
