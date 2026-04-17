using ProjetoUFCD1790.App.Model;
using ProjetoUFCD1790.App.Service;
using ProjetoUFCD1790.App.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ProjetoUFCD1790.App.Forms
{
    public partial class home : Form
    {
        private CategoriaService categoriaService;
        private PerguntaService perguntaService;
        private RespostaService respostaService;
        private int selecionaIdCategoria;
        private int selecionaIdNivel;
        private List<PerguntaModel> perguntas;
        private List<RespostaModel> resposta;
        private int perguntaAtualIndex = 0;
        private bool p = true;
        private bool carregandoPergunta = false;
        private ResultadoService resultadoQuizService;
        private LoginService loginService;
        private UsuarioService usuarioService;
        int total;
        int corretas;
        int erradas;

        string nomeCategoria;

        public home()
        {
            InitializeComponent();
            categoriaService = new CategoriaService();
            perguntaService = new PerguntaService();
            respostaService = new RespostaService();
            resultadoQuizService = new ResultadoService();
            loginService = new LoginService();
            usuarioService = new UsuarioService();


            btn_fim.Enabled = false;
            lbl_dataAtual.Text = DateTime.Now.ToString("dd/MM/yyyy");
            // Carrega categorias
            cbx_categoria.DataSource = categoriaService.getCategorias();
            cbx_categoria.DisplayMember = "nomeCategoria"; // o que será mostrado
            cbx_categoria.ValueMember = "id";               // o valor interno
            cbx_categoria.SelectedIndex = -1;                  // opcional, deixa vazio no início
            cbx_categoria.Text = "Selecione...";
            btn_iniciar.Enabled = false;

            lbl_nomeUsuario.Text = Sessao.NomeUsuarioLogado;
            atualizaGrid();
            lbl_nivelUsuario.Text = usuarioService.getUsuario() ? "Admin" : "User";


            if (!usuarioService.getUsuario())
            {
                tabctrl_resultado.TabPages.Remove(tabPage3);
            }

            pictureBox2.Image = Properties.Resources.xxx;
            pictureBox1.Image = Properties.Resources.imagem;
            lbl_Corretas.Text = "";
            lbl_incorreta.Text = "";
            progressBar1.Visible = false;
            progressBar2.Visible = false;
            btn_anterior.Enabled = false;
            btn_proximo.Enabled = false;
            btn_fim.Visible = false;
            txt_id.Enabled = false;


            // if (Sessao.IdUsuarioLogado != 1) // Supondo que o ID 1 seja do admin
            //{
            //    admin = false;
            //    tabControl1.TabPages.Remove(tabPageGestao); // Esconde a aba de gestão
            //}
        }

        private void img_sair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja sair?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GerirForms.sair();
            }
        }

        private void cbx_categoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // SelectedItem é o objeto real da categoria (CategoriaModel)
            var categoriaSelecionada = cbx_categoria.SelectedItem as CategoriaModel;
            if (categoriaSelecionada != null)
            {
                selecionaIdCategoria = categoriaSelecionada.id;       // pega o ID
                nomeCategoria = categoriaSelecionada.nomeCategoria; // pega o nome
                btn_iniciar.Enabled = true; // Habilita o botão de iniciar após selecionar uma categoria
                switch (selecionaIdCategoria)
                {

                    case
                        1:
                        pictureBox2.Image = Properties.Resources.geografia;
                        break;
                    case 2:
                        pictureBox2.Image = Properties.Resources.historia;
                        break;
                    case 3:
                        pictureBox2.Image = Properties.Resources.tecnologia;
                        break;

                    default:
                        pictureBox2.Image = null; // ou uma imagem padrão
                        break;

                }


            }



        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            // MessageBox.Show($"id selecionado {selecionaId}");
            perguntas = perguntaService.getPerguntas(selecionaIdCategoria);
            btn_iniciar.Enabled = false;
            btn_proximo.Enabled = true;
            lbl_indice.Text = "1";
            mostrarPerguntas(perguntaAtualIndex = 0);// Exibe a primeira pergunta (índice 0) ao iniciar o quiz 
            chk_Resp1.Enabled = true;
            chk_Resp2.Enabled = true;
            chk_Resp3.Enabled = true;
            chk_Resp4.Enabled = true;
        }

        private void mostrarPerguntas(int idPergunta)
        {

            var perguntaAtual = perguntas[idPergunta];// Obtém a pergunta atual com base no índice

            lbl_pergunta.Text = perguntaAtual.textoPergunta;

            resposta = respostaService.getRespostasByPerguntaId(perguntaAtual.id);

            if (resposta.Count >= 4)
            {
                txt_res1.Text = resposta[0].textoResposta;
                txt_res2.Text = resposta[1].textoResposta;
                txt_res3.Text = resposta[2].textoResposta;
                txt_res4.Text = resposta[3].textoResposta;


                chk_Resp1.Tag = resposta[0].id;
                chk_Resp2.Tag = resposta[1].id;
                chk_Resp3.Tag = resposta[2].id;
                chk_Resp4.Tag = resposta[3].id;
            }
            carregandoPergunta = true;// Evita que os eventos de CheckedChanged sejam processados enquanto carregamos a pergunta
            chk_Resp1.Checked = false;
            chk_Resp2.Checked = false;
            chk_Resp3.Checked = false;
            chk_Resp4.Checked = false;

            // Verifica se há uma resposta selecionada para a pergunta atual e marca o checkbox correspondente
            if (perguntaAtual.respostaSelecionadaId != null)
            {
                if ((int)chk_Resp1.Tag == perguntaAtual.respostaSelecionadaId) chk_Resp1.Checked = true;
                if ((int)chk_Resp2.Tag == perguntaAtual.respostaSelecionadaId) chk_Resp2.Checked = true;
                if ((int)chk_Resp3.Tag == perguntaAtual.respostaSelecionadaId) chk_Resp3.Checked = true;
                if ((int)chk_Resp4.Tag == perguntaAtual.respostaSelecionadaId) chk_Resp4.Checked = true;
            }
            carregandoPergunta = false;// Permite que os eventos de CheckedChanged sejam processados novamente
        }

        private void chk_Resp1_CheckedChanged(object sender, EventArgs e)
        {
            if (carregandoPergunta) return;
            if (chk_Resp1.Checked)
            {

                chk_Resp2.Checked = false;
                chk_Resp3.Checked = false;
                chk_Resp4.Checked = false;
            }
            perguntas[perguntaAtualIndex].respostaSelecionadaId = (int)chk_Resp1.Tag;
        }

        private void chk_Resp2_CheckedChanged(object sender, EventArgs e)
        {
            if (carregandoPergunta) return;
            if (chk_Resp2.Checked)
            {
                chk_Resp1.Checked = false;
                chk_Resp3.Checked = false;
                chk_Resp4.Checked = false;
            }
            perguntas[perguntaAtualIndex].respostaSelecionadaId = (int)chk_Resp2.Tag;
        }

        private void chk_Resp3_CheckedChanged(object sender, EventArgs e)
        {
            if (carregandoPergunta) return;
            if (chk_Resp3.Checked)
            {
                chk_Resp1.Checked = false;
                chk_Resp2.Checked = false;
                chk_Resp4.Checked = false;
            }
            perguntas[perguntaAtualIndex].respostaSelecionadaId = (int)chk_Resp3.Tag;
        }

        private void chk_Resp4_CheckedChanged(object sender, EventArgs e)
        {
            if (carregandoPergunta) return;
            if (chk_Resp4.Checked)
            {
                chk_Resp1.Checked = false;
                chk_Resp2.Checked = false;
                chk_Resp3.Checked = false;

            }
            perguntas[perguntaAtualIndex].respostaSelecionadaId = (int)chk_Resp4.Tag;
        }



        private void btn_proximo_Click(object sender, EventArgs e)
        {
            p = true;
            mostrarPerguntas(nextQuestion());
        }

        private void btn_anterior_Click(object sender, EventArgs e)
        {
            p = false;
            mostrarPerguntas(nextQuestion());
        }
       
        private int nextQuestion()
        {
            if (p) // próximo
            {
                if (perguntaAtualIndex < perguntas.Count - 1)
                {
                    perguntaAtualIndex++;
                }
            }
            else // anterior
            {
                if (perguntaAtualIndex > 0)
                {
                    perguntaAtualIndex--;
                }
            }

            // label correto
            lbl_indice.Text = (perguntaAtualIndex + 1).ToString();

            // controlar botões
            btn_anterior.Enabled = perguntaAtualIndex > 0;
            btn_proximo.Enabled = perguntaAtualIndex < perguntas.Count - 1;


            // mensagens opcionais
            if (perguntaAtualIndex == 0)
            {
                MessageBox.Show("Primeira pergunta");
            }

            if (perguntaAtualIndex == perguntas.Count - 1)
            {
                MessageBox.Show("Última pergunta");
                btn_fim.Enabled = perguntaAtualIndex == perguntas.Count - 1;
                btn_fim.Visible = true;
            }

            return perguntaAtualIndex;
        }

        bool resultadoatual = false;
        private void btn_fim_Click(object sender, EventArgs e)
        {
            ResultadoModel acertos = resultadoQuizService.CalcularResultado(perguntas);

            resultadoQuizService.SalvarResultado(
               Sessao.IdUsuarioLogado,
               nomeCategoria,
               perguntas.Count,
               acertos.Acertos,
               acertos.Percentagem
            );
            if (acertos != null)
            {
                total = perguntas.Count;
                corretas = acertos.Acertos;
                erradas = perguntas.Count - acertos.Acertos;
                MessageBox.Show($"Acertaste {acertos.Acertos} de {perguntas.Count}");
                tabctrl_resultado.SelectedTab = tabP_resultado;
                resultadoatual = true;
                atualizaGridResultado();
                carregaResultadoAtual();
                
            }
            btn_proximo.Enabled = false;
            btn_anterior.Enabled = false;
            btn_fim.Visible = false;
            chk_Resp1.Enabled = false;
            chk_Resp2.Enabled = false;
            chk_Resp3.Enabled = false;
            chk_Resp4.Enabled = false;
        }

        private void btn_InserirUser_Click(object sender, EventArgs e)
        {
            int idLogin = loginService.cadastrarLogin(txt_nomeUsuario.Text, txt_passwordUsuario.Text);
            usuarioService.cadastrarUsuario(txt_nomeUsuario.Text, selecionaIdNivel, idLogin);
            atualizaGrid();
            MessageBox.Show("Usuário cadastrado com sucesso!");

        }
        //############################################################################################################
        //########################################## Seleciona nivel #################################################
        private void cbx_nivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            selecionaIdNivel = cbx_nivel.SelectedIndex;

            MessageBox.Show($"id selecionado {selecionaIdNivel}");
        }
        //#############################################################################################################


        //#############################################################################################################
        //########################################## GRID LISTA GESTÃO DE USUÁRIO #####################################
        private void dgv_GestaoUtilizador_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_GestaoUtilizador.Rows[e.RowIndex];
                txt_id.Text = row.Cells["Id"].Value.ToString();
                txt_nomeUsuario.Text = row.Cells["Nome"].Value.ToString();

                // cbx_nivel.Text = row.Cells["IsAdmin"].Value.ToString();
               
                bool isAdmin = Convert.ToBoolean(row.Cells["IsAdmin"].Value);

                if (isAdmin)
                {
                    cbx_nivel.Text = "admin";
                }
                else
                {
                    cbx_nivel.Text = "user";
                }

                txt_nomeUsuario.Text = row.Cells["UserName"].Value.ToString();
                txt_passwordUsuario.Text = row.Cells["Password"].Value.ToString();



            }
        }
        private void atualizaGrid()
        {

            dgv_GestaoUtilizador.DataSource = usuarioService.ListarUsuarios();
            dgv_GestaoUtilizador.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            List<UsuarioLoginModel> lista = usuarioService.ListarUsuarios();


        }
        //#############################################################################################################


        private void dgv_historico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_historico.Rows[e.RowIndex];




            }
        }
        private void atualizaGridResultado()
        {

            dgv_historico.DataSource = resultadoQuizService.ObterResultadosPorUsuario(Sessao.IdUsuarioLogado);
            dgv_historico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_historico.Columns["Id_userLogado"].Visible = false;
            //List<ResultadoModel> lista = resultadoQuizService.ObterResultadosPorUsuario(Sessao.IdUsuarioLogado);
        }


        private void tabctrl_resultado_Click(object sender, EventArgs e)
        {
            atualizaGridResultado();
            carregaResultadoAtual();
        }
        
        private void carregaResultadoAtual()
        {


            if (resultadoatual)
            {
                int percentagemAcertos = (corretas * 100) / total;
                int percentagemErradas = (erradas * 100) / total;

                // Labels

                lbl_Corretas.Text = $"Acertos: {corretas}";
                lbl_incorreta.Text = $"Erradas: {erradas}";


                // ProgressBar
                progressBar1.Visible = true;
                progressBar2.Visible = true;
                progressBar1.Value = percentagemAcertos;
                progressBar2.Value = percentagemErradas;
            }
        }

        private void btn_excluir_Click(object sender, EventArgs e)
        {
            
                if (int.TryParse(txt_id.Text, out int id))
                {
                    usuarioService.ExcluirUsuario(id);
                    loginService.ExcluirLogin(id);
                    atualizaGrid();
                    MessageBox.Show("Usuário excluído com sucesso!");
                }
                else
                {
                    MessageBox.Show("ID inválido. Selecione um usuário para excluir.");
                }
        
        }

        private void btn_atualizar_Click(object sender, EventArgs e)
        {
                        if (int.TryParse(txt_id.Text, out int id))
            {
                //MessageBox.Show(txt_id.Text);

                string nome = txt_nomeUsuario.Text;
                bool isAdmin = cbx_nivel.Text == "admin";
                string usuario = txt_nomeUsuario.Text;
                string senha = txt_passwordUsuario.Text;
                //MessageBox.Show(""+isAdmin);
                usuarioService.EditarUsuario(id, nome, isAdmin, usuario, senha);
                atualizaGrid();
                MessageBox.Show("Usuário atualizado com sucesso!");
            }
            else
            {
                MessageBox.Show("ID inválido. Selecione um usuário para atualizar.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
