using M17AB_TrabalhoModelo_202223.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_2022_23.Admin.Utilizadores
{
    public partial class Utilizadores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: validar a sessão do utilizador
            AtualizaGrid();
        }

        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            //validar o form
            string nome=tb_nome.Text;
            string email=tb_email.Text;
            string morada=tb_morada.Text;
            string nif=tb_nif.Text;
            string password = tb_password.Text;
            int perfil = int.Parse(dd_perfil.SelectedValue);
            Random rnd=new Random();
            int sal = rnd.Next(1000);

            Utilizador utilizador = new Utilizador();
            utilizador.nome = nome;
            utilizador.email = email;
            utilizador.sal = sal;
            utilizador.morada= morada;
            utilizador.nif = nif;
            utilizador.password = password;
            utilizador.perfil= perfil;

            utilizador.Adicionar();

            //limpar form
            tb_email.Text = "";
            tb_morada.Text = "";
            tb_nif.Text = "";
            tb_nome.Text = "";

            //atualizar grid
            AtualizaGrid();
        }

        private void AtualizaGrid()
        {
            Utilizador utilizador = new Utilizador();
            gvUtilizadores.DataSource = utilizador.ListaTodosUtilizadores();
            gvUtilizadores.DataBind();
        }
    }
}