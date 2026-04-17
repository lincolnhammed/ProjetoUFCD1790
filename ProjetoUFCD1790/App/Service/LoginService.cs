using ProjetoUFCD1790.App.Model;
using ProjetoUFCD1790.App.Repositories;
using ProjetoUFCD1790.App.Utils;
using System;

namespace ProjetoUFCD1790.App.Service
{
    public class LoginService
    {
        private readonly LoginRepository _loginRepository = new LoginRepository();
        public LoginModel validarLogin(String usuario, String senha)
        {

            

            if (string.IsNullOrWhiteSpace(usuario)  || string.IsNullOrWhiteSpace(senha)) {
                return null;
            }

            LoginModel loginModel = new LoginModel(usuario, senha);
            return _loginRepository.ValidaLogin(loginModel);
        }

        public int cadastrarLogin(String nome, String senha)
        {

            return _loginRepository.CadastrarLogin(nome, senha);
        }
        public static void sessaoLogin(int id, String usuario)
        {
            Sessao.IdUsuarioLogado = id;
            Sessao.NomeUsuarioLogado = usuario;
        }
        public void ExcluirLogin(int idLogin)
        {
            _loginRepository.ExcluirLogin(idLogin);
        }


    }
}
