using M17AB_TrabalhoModelo_202223.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_2022_23.Admin.Livros
{
    public partial class EditarLivro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: Validar sessão
            try
            {
                //querystring nlivro
                int nlivro = int.Parse(Request["nlivro"].ToString());

                Livro lv = new Livro();
                DataTable dados = lv.devolveDadosLivro(nlivro);
                if (dados == null || dados.Rows.Count == 0)
                {
                    //o nlivro não existe na tabela dos livros
                    throw new Exception("Livro não existe.");
                }
                //mostrar os dados livro
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbAno.Text = dados.Rows[0]["ano"].ToString();
                tbAutor.Text = dados.Rows[0]["autor"].ToString();
                tbPreco.Text = dados.Rows[0]["preco"].ToString();
                tbData.Text = dados.Rows[0]["data_aquisicao"].ToString();
                dpTipo.Text = dados.Rows[0]["tipo"].ToString();

                imgCapa.ImageUrl = @"~\Public\Imagens\" + nlivro + ".jpg";
                imgCapa.Width = 300;
            }
            catch
            {
                Response.Redirect("~/Admin/Livros/livros.aspx");
            }
        }

        protected void btAtualizar_Click(object sender, EventArgs e)
        {

        }
    }
}