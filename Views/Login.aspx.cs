using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistoriasProjeto.Dao;
using VistoriasProjeto.Models;
using VistoriasProjeto.Models.Enumeradores;

namespace VistoriasProjeto.Views
{
    public partial class Login : System.Web.UI.Page
    {
        private UsuarioDao usuarioDao;
        public UsuarioDao UsuarioDao
        {
            get
            {
                if (usuarioDao == null)
                    usuarioDao = new UsuarioDao();
                return usuarioDao;
            }
            set
            {
                usuarioDao = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            var usuario = UsuarioDao.GetByLoginAndSenha(txtLogin.Text, txtSenha.Text);
            if (usuario.Id != GLOBALS.Invalid_Id)
            {
                GLOBALS.UsuarioLogado = usuario;
                GerenciarRedirecionamento();
            }
        }

        private void GerenciarRedirecionamento()
        {
            Response.Redirect("ListaVistorias.aspx");
        }
    }
}