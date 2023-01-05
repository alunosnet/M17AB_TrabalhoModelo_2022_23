using M17AB_TrabalhoModelo_202223.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_2022_23.Admin.Emprestimos
{
    public partial class Emprestimos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: validar sessão

            ConfigurarGrid();

            if (IsPostBack) return;

            AtualizarGrid();
            AtualizarDDLivros();
            AtualizarDDLeitores();

        }

        private void AtualizarDDLeitores()
        {
            Utilizador u = new Utilizador();
            dd_leitor.Items.Clear();
            DataTable dados = u.listaTodosUtilizadoresDisponiveis();
            foreach (DataRow linha in dados.Rows)
                dd_leitor.Items.Add(
                    new ListItem(linha["nome"].ToString(), linha["id"].ToString())
                );
        }

        private void AtualizarDDLivros()
        {
            Livro lv = new Livro();
            dd_livro.Items.Clear();
            DataTable dados = lv.listaLivrosDisponiveis();
            foreach (DataRow linha in dados.Rows)
                dd_livro.Items.Add(
                    new ListItem(linha["nome"].ToString(), linha["nlivro"].ToString())
                );
        }

        private void AtualizarGrid()
        {
            Emprestimo emp = new Emprestimo();

            DataTable dados;
            if (cb_livros_emprestados.Checked)
                dados = emp.listaTodosEmprestimosPorConcluirComNomes();
            else
                dados = emp.listaTodosEmprestimosComNomes();

            gv_emprestimos.Columns.Clear();
            gv_emprestimos.DataSource = null;
            gv_emprestimos.DataBind();
            if (dados == null || dados.Rows.Count == 0) return;
            //botões de comando
            //receber
            ButtonField bfReceber = new ButtonField();
            bfReceber.HeaderText = "Receber Livro";
            bfReceber.Text = "Receber";
            bfReceber.ButtonType = ButtonType.Button;
            bfReceber.ControlStyle.CssClass = "btn btn-info";
            bfReceber.CommandName = "receber";
            gv_emprestimos.Columns.Add(bfReceber);
            //enviar um email
            ButtonField bfEmail = new ButtonField();
            bfEmail.HeaderText = "Enviar email";
            bfEmail.Text = "Email";
            bfEmail.ButtonType = ButtonType.Button;
            bfEmail.ControlStyle.CssClass = "btn btn-danger";
            bfEmail.CommandName = "email";
            gv_emprestimos.Columns.Add(bfEmail);

            gv_emprestimos.DataSource = dados;
            gv_emprestimos.AutoGenerateColumns = true;
            gv_emprestimos.DataBind();
        }

        private void ConfigurarGrid()
        {
            //paginação
            gv_emprestimos.AllowPaging = true;
            gv_emprestimos.PageSize = 5;
            gv_emprestimos.PageIndexChanging += Gv_emprestimos_PageIndexChanging;
            //botões de comando
            gv_emprestimos.RowCommand += Gv_emprestimos_RowCommand;
        }

        private void Gv_emprestimos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //TODO: continuar aqui
        }

        private void Gv_emprestimos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_emprestimos.PageIndex = e.NewPageIndex;
            AtualizarGrid();
        }

        protected void bt_registar_Click(object sender, EventArgs e)
        {
            try
            {
                Emprestimo emp = new Emprestimo();
                int nlivro = int.Parse(dd_livro.SelectedValue);
                int nleitor = int.Parse(dd_leitor.SelectedValue);
                DateTime data = DateTime.Parse(tb_data.Text);
                emp.adicionarEmprestimo(nlivro, nleitor, data);
                AtualizarDDLeitores();
                AtualizarDDLivros();
                AtualizarGrid();
                lb_erro.Text = "O empréstimo foi registado com sucesso.";
                lb_erro.CssClass = "";
            }catch(Exception erro)
            {
                lb_erro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lb_erro.CssClass = "alert alert-danger";
            }
        }
    }
}