using M17AB_TrabalhoModelo_202223.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_2022_23.Admin.Livros
{
    public partial class Livros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validar a sessão

            if (!IsPostBack)
            {
                AtualizarGrid();
            }
        }
        /// <summary>
        /// Adicionar umlivro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bt_Click(object sender, EventArgs e)
        {

            try
            {
                string nome = tbNome.Text;
                if (nome.Trim().Length < 3)
                {
                    throw new Exception("O nome é muito pequeno.");
                }
                int ano = int.Parse(tbAno.Text);
                if (ano>DateTime.Now.Year || ano < 0)
                {
                    throw new Exception("O ano não é válido");
                }
                DateTime data = DateTime.Parse(tbData.Text);
                if (data>DateTime.Now)
                {
                    throw new Exception("A data tem de ser inferior à data atual");
                }
                Decimal preco = Decimal.Parse(tbPreco.Text);
                if (preco<0 || preco > 100)
                {
                    throw new Exception("O preço deve estar entre 0 e 100");
                }
                string autor = tbAutor.Text;
                if (autor.Trim().Length < 3)
                {
                    throw new Exception("O nome do autor é muito pequeno");
                }
                string tipo = dpTipo.SelectedValue;
                if (tipo=="")
                {
                    throw new Exception("O tipo não é válido");
                }
                Livro livro = new Livro();
                livro.nome = nome;
                livro.preco = preco;
                livro.ano = ano;
                livro.data_aquisicao = data;
                livro.autor = autor;
                livro.tipo = tipo;
                livro.estado = 1;
                int nlivro = livro.Adicionar();

                if (fuCapa.HasFile)
                {
                    string ficheiro = Server.MapPath(@"~\Public\Imagens\");
                    ficheiro = ficheiro + nlivro + ".jpg";
                    fuCapa.SaveAs(ficheiro);
                }
            }catch(Exception ex)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                return;
            }
            //limpar form
            tbAno.Text = "";
            tbNome.Text = "";
            tbPreco.Text = "";
            tbAutor.Text = "";
            dpTipo.SelectedIndex = 0;
            tbData.Text = DateTime.Now.ToShortDateString();
            //atualizar grid
            AtualizarGrid();
        }
        /// <summary>
        /// Atualiza a grid dos livros
        /// </summary>
        private void AtualizarGrid()
        {
            Livro lv = new Livro();
            gvLivros.DataSource = lv.ListaTodosLivros();
            gvLivros.DataBind();
        }
    }
}