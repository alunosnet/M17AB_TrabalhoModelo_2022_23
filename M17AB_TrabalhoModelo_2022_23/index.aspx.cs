using M17AB_TrabalhoModelo_202223.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M17AB_TrabalhoModelo_2022_23
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_recuperar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_Email.Text.Trim().Length == 0)
                {
                    throw new Exception("Indique um email");
                }
                string email=tb_Email.Text.Trim();
                Utilizador utilizador= new Utilizador();
                DataTable dados = utilizador.devolveDadosUtilizador(email);
                if(dados==null || dados.Rows.Count != 1)
                {
                    throw new Exception("Foi enviado um email para recuperação da palavra passe");
                }
                Guid guid=Guid.NewGuid();
                utilizador.recuperarPassword(email, guid.ToString());

                string mensagem = "Clique no link para recuperar a sua password.<br/>";
                mensagem += "<a href='http://" + Request.Url.Authority + "/recuperarpassword.aspx?";
                mensagem += "id=" + Server.UrlEncode(guid.ToString()) + "'>Clique aqui</a>";
                //TODO:Continuar aqui

                lb_erro.Text = "Foi enviado um email para recuperação da palavra passe";
            }
            catch(Exception ex)
            {
                lb_erro.Text= ex.Message;
            }
        }
    }
}