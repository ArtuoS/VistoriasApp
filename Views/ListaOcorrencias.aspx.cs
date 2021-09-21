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
                dgvOcorrencias.DataSource = ocorrencias;
                dgvOcorrencias.DataBind();
            }
        }

        private void AtualizarOcorrencias(int vistoriaId)
        {
            if (vistoriaId != GLOBALS.Invalid_Id)
            {
                var ocorrencias = OcorrenciaDao.GetByVistoria(vistoriaId);
                dgvOcorrencias.DataSource = ocorrencias;
                dgvOcorrencias.DataBind();
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            int vistoriaId = Request.QueryString["id"] != null ? Convert.ToInt32(Request.QueryString["id"].ToString()) : GLOBALS.Invalid_Id;
            AtualizarOcorrencias(vistoriaId);
        }

        protected void btnInserirOcorrencia_Click(object sender, EventArgs e)
        {
            int vistoriaId = Request.QueryString["id"] != null ? Convert.ToInt32(Request.QueryString["id"].ToString()) : GLOBALS.Invalid_Id;
            if (vistoriaId != GLOBALS.Invalid_Id)
            {
                Response.Redirect($"CadastroOcorrencia.aspx?vistoriaId={vistoriaId}&action=Inserir");
            }
        }
    }
}