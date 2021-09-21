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
            if (!IsPostBack)
            {
                dplTipo.DataSource = Enum.GetValues(typeof(ETipoOcorrencia));
                dplTipo.DataBind();

                int vistoriaId = Request.QueryString["vistoriaId"] != null ? Convert.ToInt32(Request.QueryString["vistoriaId"].ToString()) : GLOBALS.Invalid_Id;
                string action = Request.QueryString["action"] != null ? Request.QueryString["action"].ToString() : string.Empty;

                var vistoria = VistoriaDao.GetById(vistoriaId);

                if (vistoriaId > 0 && action != string.Empty)
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
                            txtDescricao.Text = vistoria.Descricao;
                            txtIdOcorrencia.Text = vistoria.Id.ToString();
                            break;
                        case "Deletar":
                            btnAtualizar.Enabled = false;
                            btnInserir.Enabled = false;
                            txtIdVistoria.ReadOnly = true;
                            txtIdOcorrencia.ReadOnly = true;
                            txtData.ReadOnly = true;
                            txtIdVistoria.Text = vistoriaId.ToString();
                            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
                            txtDescricao.Text = vistoria.Descricao;
                            txtIdOcorrencia.Text = vistoria.Id.ToString();
                            break;
                    }
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
            var ocorrencia = new Ocorrencia()
            {
                VistoriaId = Convert.ToInt32(txtIdVistoria.Text),
                Tipo = (ETipoOcorrencia)Enum.Parse(typeof(ETipoOcorrencia), dplTipo.SelectedValue),
                Descricao = txtDescricao.Text,
                DataOcorrencia = Convert.ToDateTime(txtData.Text, GLOBALS.Culture),
            };

            OcorrenciaDao.Update(ocorrencia);
        }

        protected void btnFechar_Click(object sender, EventArgs e)
        {

        }

        private void AtualizarGridOcorrenciasPorId(int id)
        {

        }
    }
}