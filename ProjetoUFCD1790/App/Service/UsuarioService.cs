using ProjetoUFCD1790.App.Data;
using ProjetoUFCD1790.App.Model;
using System.Collections.Generic;

namespace ProjetoUFCD1790.App.Service
{
    public class UsuarioService
    {
        private UsuarioRepository usuarioRepository;
        private bool admin = true;
        public UsuarioService()
        {
            usuarioRepository = new UsuarioRepository();
        }

        public void cadastrarUsuario(string nome, int nivel, int id_login)
        {

            if (nivel == 0)
            {
                admin = false;
                usuarioRepository.cadastrarUsuario(nome, admin, id_login);
            }
            else
            {
                
                usuarioRepository.cadastrarUsuario(nome, admin, id_login);
            }

        }

        public List<UsuarioLoginModel> ListarUsuarios()
        {
            return usuarioRepository.ListarUsuarios();
        }
        public bool getUsuario()
        {
            return usuarioRepository.statusUsuarios();
        }

        public void ExcluirUsuario(int id)
        {
            usuarioRepository.ExcluirUsuario(id);
        }
        public void EditarUsuario(int id, string nome, bool nivel, string usuario, string senha)
        {
            usuarioRepository.atualizarUsuario(id, nome, nivel, usuario, senha);
        }
    }

}
