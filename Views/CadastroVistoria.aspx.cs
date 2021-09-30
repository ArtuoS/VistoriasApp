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
    public partial class CadastroVistoria : System.Web.UI.Page
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

                int id = Request.QueryString["id"] != null ? Convert.ToInt32(Request.QueryString["id"].ToString()) : GLOBALS.Invalid_Id;
                string action = Request.QueryString["action"] != null ? Request.QueryString["action"].ToString() : string.Empty;
                Vistoria vistoria = new Vistoria();

                if (id > 0)
                    vistoria = VistoriaDao.GetById(id);

                switch (action)
                {
                    case "Inserir":
                        txtData.ReadOnly = false;
                        btnAtualizar.Enabled = false;
                        btnExcluir.Enabled = false;
                        break;
                    case "Atualizar":
                        txtIdVistoria.ReadOnly = true;
                        txtData.ReadOnly = true;
                        txtIdVistoria.Text = vistoria.Id.ToString();
                        txtData.Text = vistoria.DataVistoria.ToString("dd/MM/yyyy");
                        btnInserir.Enabled = false;
                        btnExcluir.Enabled = false;
                        break;
                    case "Excluir":
                        txtData.ReadOnly = true;
                        txtData.Text = vistoria.DataVistoria.ToString("dd/MM/yyyy");
                        txtDescricao.ReadOnly = true;
                        txtDescricao.Text = vistoria.Descricao.ToString();
                        txtEndereco.ReadOnly = true;
                        txtEndereco.Text = vistoria.Localidade.ToString();
                        txtIdResponsavel.ReadOnly = true;
                        txtIdResponsavel.Text = vistoria.UsuarioId.ToString();
                        txtIdVistoria.ReadOnly = true;
                        txtIdVistoria.Text = vistoria.Id.ToString();
                        dplStatus.Enabled = false;
                        btnInserir.Enabled = false;
                        btnAtualizar.Enabled = false;
                        break;
                    case "Consultar":
                        txtData.ReadOnly = true;
                        txtDescricao.ReadOnly = true;
                        txtEndereco.ReadOnly = true;
                        txtIdResponsavel.ReadOnly = true;
                        txtIdVistoria.ReadOnly = true;
                        dplStatus.Enabled = false;
                        fuFoto.Enabled = false;
                        btnInserir.Enabled = false;
                        btnAtualizar.Enabled = false;
                        btnExcluir.Enabled = false;
                        break;
                }
            }
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            var vistoria = new Vistoria();
            vistoria.Localidade = txtEndereco.Text;
            vistoria.DataVistoria = Convert.ToDateTime(txtData.Text, GLOBALS.Culture);
            vistoria.UsuarioId = Convert.ToInt32(txtIdResponsavel.Text);
            vistoria.Descricao = txtDescricao.Text;
            vistoria.Status = (EStatusVistoria)Enum.Parse(typeof(EStatusVistoria), dplStatus.SelectedValue);
            vistoria.Imagem = GLOBALS.MontarFilePathRelative(fuFoto.FileName);

            SalvarImagem();

            VistoriaDao.Insert(vistoria);
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIdVistoria.Text);

            VistoriaDao.Delete(id);

            Response.Redirect("ListaVistorias.aspx");
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            int id = Request.QueryString["id"] != null ? Convert.ToInt32(Request.QueryString["id"].ToString()) : GLOBALS.Invalid_Id;

            if (id != GLOBALS.Invalid_Id)
            {
                var vistoriaPadrao = VistoriaDao.GetById(id);

                var novaVistoria = new Vistoria()
                {
                    Id = id,
                    Localidade = (txtEndereco.Text != string.Empty) ? txtEndereco.Text : "",
                    DataVistoria = (txtData.Text != string.Empty) ? Convert.ToDateTime(txtData.Text, GLOBALS.Culture) : default(DateTime),
                    UsuarioId = (txtIdResponsavel.Text != string.Empty) ? Convert.ToInt32(txtIdResponsavel.Text) : GLOBALS.Invalid_Id,
                    Descricao = (txtDescricao.Text != string.Empty) ? txtDescricao.Text : "",
                    Status = (EStatusVistoria)Enum.Parse(typeof(EStatusVistoria), dplStatus.SelectedValue),
                    Imagem = (fuFoto.FileName != string.Empty) ? GLOBALS.MontarFilePathRelative(fuFoto.FileName) : "",
                };

                vistoriaPadrao.ClonarPropriedades(novaVistoria);

                VistoriaDao.Update(vistoriaPadrao);
            }
        }

        protected void btnFechar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaVistorias.aspx");
        }

        private void SalvarImagem()
        {
            fuFoto.SaveAs(GLOBALS.MontarFilePath(fuFoto.FileName));
        }

    }
}