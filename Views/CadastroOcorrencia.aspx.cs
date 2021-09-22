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
    public partial class CadastroOcorrencia : System.Web.UI.Page
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
            dplTipo.DataSource = Enum.GetValues(typeof(ETipoOcorrencia));
            dplTipo.DataBind();

            int vistoriaId = Request.QueryString["vistoriaId"] != null ? Convert.ToInt32(Request.QueryString["vistoriaId"].ToString()) : GLOBALS.Invalid_Id;
            int ocorrenciaId = Request.QueryString["ocorrenciaId"] != null ? Convert.ToInt32(Request.QueryString["ocorrenciaId"].ToString()) : GLOBALS.Invalid_Id;
            string action = Request.QueryString["action"] != null ? Request.QueryString["action"].ToString() : string.Empty;

            var ocorrencia = OcorrenciaDao.GetById(ocorrenciaId);

            if ((ocorrenciaId > 0 && action != string.Empty) || (ocorrenciaId == GLOBALS.Invalid_Id && action == "Inserir"))
                switch (action)
                {
                    case "Inserir":
                        btnExcluir.Enabled = false;
                        btnAtualizar.Enabled = false;
                        txtIdVistoria.ReadOnly = true;
                        txtIdOcorrencia.ReadOnly = true;
                        txtData.ReadOnly = true;
                        txtIdVistoria.Text = vistoriaId.ToString();
                        txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        break;
                    case "Atualizar":
                        btnExcluir.Enabled = false;
                        btnInserir.Enabled = false;
                        txtIdVistoria.ReadOnly = true;
                        txtIdOcorrencia.ReadOnly = true;
                        txtData.ReadOnly = true;
                        txtIdVistoria.Text = vistoriaId.ToString();
                        txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        txtDescricao.Text = ocorrencia.Descricao;
                        txtIdOcorrencia.Text = ocorrencia.Id.ToString();
                        break;
                    case "Excluir":
                        btnAtualizar.Enabled = false;
                        btnInserir.Enabled = false;
                        txtIdVistoria.ReadOnly = true;
                        txtIdOcorrencia.ReadOnly = true;
                        txtData.ReadOnly = true;
                        txtDescricao.ReadOnly = true;
                        dplTipo.Enabled = false;
                        txtIdVistoria.Text = vistoriaId.ToString();
                        txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        txtDescricao.Text = ocorrencia.Descricao;
                        txtIdOcorrencia.Text = ocorrencia.Id.ToString();
                        break;
                    case "Consultar":
                        btnAtualizar.Enabled = false;
                        btnInserir.Enabled = false;
                        txtIdVistoria.ReadOnly = true;
                        txtIdOcorrencia.ReadOnly = true;
                        txtData.ReadOnly = true;
                        txtDescricao.ReadOnly = true;
                        dplTipo.Enabled = false;
                        btnExcluir.Enabled = false;
                        btnAtualizar.Enabled = false;
                        btnInserir.Enabled = false;
                        break;
                }
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            var ocorrencia = new Ocorrencia();
            ocorrencia.VistoriaId = Convert.ToInt32(txtIdVistoria.Text);
            ocorrencia.Tipo = (ETipoOcorrencia)Enum.Parse(typeof(ETipoOcorrencia), dplTipo.SelectedValue);
            ocorrencia.Descricao = txtDescricao.Text;
            ocorrencia.DataOcorrencia = Convert.ToDateTime(txtData.Text, GLOBALS.Culture);

            OcorrenciaDao.Insert(ocorrencia);
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIdOcorrencia.Text);

            OcorrenciaDao.Delete(id);
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            int id = Request.QueryString["vistoriaId"] != null ? Convert.ToInt32(Request.QueryString["vistoriaId"].ToString()) : GLOBALS.Invalid_Id;

            if (id != GLOBALS.Invalid_Id)
            {
                var ocorrenciaPadrao = OcorrenciaDao.GetById(id);

                var novaOcorrencia = new Ocorrencia()
                {
                    VistoriaId = (txtIdVistoria != null) ? Convert.ToInt32(txtIdVistoria.Text) : GLOBALS.Invalid_Id,
                    Tipo = (ETipoOcorrencia)Enum.Parse(typeof(ETipoOcorrencia), dplTipo.SelectedValue),
                    Descricao = (txtDescricao != null) ? txtDescricao.Text : "",
                    DataOcorrencia = (txtData != null) ? Convert.ToDateTime(txtData.Text, GLOBALS.Culture) : default(DateTime),
                };

                ocorrenciaPadrao.ClonarPropriedades(novaOcorrencia);

                OcorrenciaDao.Update(ocorrenciaPadrao);
            }
        }

        protected void btnFechar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaVistorias.aspx");
        }

        private void AtualizarGridOcorrenciasPorId(int id)
        {

        }
    }
}