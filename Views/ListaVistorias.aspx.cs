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
    public partial class ListaVistorias : System.Web.UI.Page
    {
        private VistoriaDao vistoriaDao;
        public VistoriaDao VistoriaDao
        {
            get
            {
                if (vistoriaDao == null)
                    vistoriaDao = new VistoriaDao();
                return vistoriaDao;
            }
            set
            {
                vistoriaDao = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dplStatus.DataSource = Enum.GetValues(typeof(EStatusVistoria));
                dplStatus.DataBind();

                AtualizarGridVistorias();

                if (GLOBALS.UsuarioLogado != null && GLOBALS.UsuarioLogado.Perfil == EPerfilUsuario.Operador)
                {
                    btnInserirVistoria.Enabled = false;
                }
            }
        }

        protected void btnInserirVistoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroVistoria.aspx?action=Inserir");
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            var vistorias = VistoriaDao.GetAll();
            AtualizarGridVistoriasPorListaVistorias(vistorias);
        }

        private void AtualizarGridVistorias()
        {
            var vistorias = VistoriaDao.GetAll();

            dgvVistorias.DataSource = vistorias;
            dgvVistorias.DataBind();
        }

        private void AtualizarGridVistoriasPorListaVistorias(List<Vistoria> vistorias)
        {
            dgvVistorias.DataSource = vistorias;
            dgvVistorias.DataBind();
        }

        protected void dgvVistorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            var row = dgvVistorias.Rows[rowIndex];
            int id = Convert.ToInt32(row.Cells[2].Text);

            if (GLOBALS.UsuarioLogado != null && GLOBALS.UsuarioLogado.Perfil == EPerfilUsuario.Operador)
            {
                if (e.CommandName == "Atualizar" || e.CommandName == "Excluir")
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('O comando {e.CommandName} não está disponível para o grupo {GLOBALS.UsuarioLogado.Perfil.ToString()}');", true);
                else if (e.CommandName == "Ocorrencias")
                    Response.Redirect($"ListaOcorrencias.aspx?id={id}");
                else if(e.CommandName == "Consultar")
                    Response.Redirect($"CadastroVistoria.aspx?action={e.CommandName}");
            }
            else
            {
                if (e.CommandName == "Atualizar" || e.CommandName == "Excluir")
                    Response.Redirect($"CadastroVistoria.aspx?id={id}&action={e.CommandName}");
                else if (e.CommandName == "Ocorrencias")
                    Response.Redirect($"ListaOcorrencias.aspx?id={id}");
                else if (e.CommandName == "Consultar")
                    Response.Redirect($"CadastroVistoria.aspx?action={e.CommandName}");
            }
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            //Response.Redirect($"CadastroOcorrencia.aspx?id={id}&action={e.CommandName}");
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            //Response.Redirect($"CadastroOcorrencia.aspx?id={id}&action={e.CommandName}");
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            //Response.Redirect($"CadastroOcorrencia.aspx?id={id}&action={e.CommandName}");
        }

        protected void btnOcorrencias_Click(object sender, EventArgs e)
        {
            //Response.Redirect($"CadastroOcorrencia.aspx?id={id}&action={e.CommandName}");
        }

        protected void btnConsulta_Click(object sender, EventArgs e)
        {
            //Response.Redirect($"CadastroOcorrencia.aspx?id={id}&action={e.CommandName}");
        }
    }
}