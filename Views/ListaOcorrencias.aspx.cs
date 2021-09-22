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
    public partial class ListaOcorrencias : System.Web.UI.Page
    {

        private OcorrenciaDao ocorrenciaDao;
        public OcorrenciaDao OcorrenciaDao
        {
            get
            {
                if (ocorrenciaDao == null)
                    ocorrenciaDao = new OcorrenciaDao();
                return ocorrenciaDao;
            }
            set
            {
                ocorrenciaDao = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dplTipo.DataSource = Enum.GetValues(typeof(ETipoOcorrencia));
                dplTipo.DataBind();

                AtualizarOcorrencias();
            }
        }

        private void AtualizarOcorrencias()
        {
            int vistoriaId = Request.QueryString["id"] != null ? Convert.ToInt32(Request.QueryString["id"].ToString()) : GLOBALS.Invalid_Id;

            if (vistoriaId != GLOBALS.Invalid_Id)
            {
                var ocorrencias = OcorrenciaDao.GetByVistoria(vistoriaId);
                dgvOcorrencia.DataSource = ocorrencias;
                dgvOcorrencia.DataBind();
            }
        }

        private void AtualizarOcorrenciasByFilter()
        {
            int vistoriaId = Request.QueryString["id"] != null ? Convert.ToInt32(Request.QueryString["id"].ToString()) : GLOBALS.Invalid_Id;

            if (vistoriaId != GLOBALS.Invalid_Id)
            {
                var ocorrencias = OcorrenciaDao.GetOcorrenciasByFilter(
                    descricao: (txtDescricao.Text != string.Empty) ? txtDescricao.Text : "",
                    idVistoria: (txtIdVistoria.Text != string.Empty) ? Convert.ToInt32(txtIdVistoria.Text) : -1,
                    dataInicial: (txtDataInicial.Text != string.Empty) ? Convert.ToDateTime(txtDataInicial.Text, GLOBALS.Culture) : default(DateTime),
                    dataFinal: (txtDataFinal.Text != string.Empty) ? Convert.ToDateTime(txtDataFinal.Text, GLOBALS.Culture) : default(DateTime),
                    tipo: (dplTipo != null) ? (ETipoOcorrencia)Enum.Parse(typeof(ETipoOcorrencia), dplTipo.SelectedValue) : 0
                    );

                dgvOcorrencia.DataSource = ocorrencias;
                dgvOcorrencia.DataBind();
            }
        }

        private void AtualizarOcorrencias(int vistoriaId)
        {
            if (vistoriaId != GLOBALS.Invalid_Id)
            {
                var ocorrencias = OcorrenciaDao.GetByVistoria(vistoriaId);
                dgvOcorrencia.DataSource = ocorrencias;
                dgvOcorrencia.DataBind();
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            int vistoriaId = Request.QueryString["id"] != null ? Convert.ToInt32(Request.QueryString["id"].ToString()) : GLOBALS.Invalid_Id;
            AtualizarOcorrenciasByFilter();
        }

        protected void btnInserirOcorrencia_Click(object sender, EventArgs e)
        {
            int vistoriaId = Request.QueryString["id"] != null ? Convert.ToInt32(Request.QueryString["id"].ToString()) : GLOBALS.Invalid_Id;
            if (vistoriaId != GLOBALS.Invalid_Id)
            {
                Response.Redirect($"CadastroOcorrencia.aspx?vistoriaId={vistoriaId}&action=Inserir");
            }
        }

        protected void dgvOcorrencia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            var row = dgvOcorrencia.Rows[rowIndex];
            int id = Convert.ToInt32(row.Cells[5].Text);
            int ocorrenciaId = Convert.ToInt32(row.Cells[1].Text);

            if (e.CommandName == "Consultar" || e.CommandName == "Atualizar" || e.CommandName == "Excluir")
                Response.Redirect($"CadastroOcorrencia.aspx?vistoriaId={id}&ocorrenciaId={ocorrenciaId}&action={e.CommandName}");
        }

        protected void btnConsulta_Click(object sender, EventArgs e)
        {

        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {

        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {

        }
    }
}