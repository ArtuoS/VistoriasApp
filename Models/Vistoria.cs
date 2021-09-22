using System;
using System.Drawing;
using System.IO;
using VistoriasProjeto.Dao;
using VistoriasProjeto.Models.Enumeradores;
using VistoriasProjeto.Models.Interfaces;

namespace VistoriasProjeto.Models
{
    public class Vistoria : IVistoria
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

        public int Id { get; set; } = GLOBALS.Invalid_Id;
        public EStatusVistoria Status { get; set; } = EStatusVistoria.Aberto;
        public DateTime DataVistoria { get; set; } = default(DateTime);
        public string Imagem { get; set; } = default(string);
        public string Descricao { get; set; } = default(string);
        public string Localidade { get; set; } = default(string);
        public int UsuarioId { get; set; } = GLOBALS.Invalid_Id;
        public Image ImageInstance
        {
            get
            {
                if (!string.IsNullOrEmpty(Imagem))
                {
                    if (File.Exists(Imagem))
                        return Image.FromFile(Imagem);
                }
                return null;
            }
        }
        public Usuario UsuarioInstance
        {
            get
            {
                if (UsuarioId > 0)
                    return UsuarioDao.GetById(UsuarioId);
                return UsuarioInstance;
            }
        }

        public void ClonarPropriedades(Vistoria novaVistoria)
        {
            if (Status != novaVistoria.Status)
                Status = novaVistoria.Status;

            if (DataVistoria != novaVistoria.DataVistoria && novaVistoria.DataVistoria != default(DateTime))
                DataVistoria = novaVistoria.DataVistoria;

            if (Imagem != novaVistoria.Imagem && !string.IsNullOrEmpty(novaVistoria.Imagem))
                Imagem = novaVistoria.Imagem;

            if (Descricao != novaVistoria.Descricao && !string.IsNullOrEmpty(novaVistoria.Descricao))
                Descricao = novaVistoria.Descricao;

            if (Localidade != novaVistoria.Localidade && !string.IsNullOrEmpty(novaVistoria.Localidade))
                Localidade = novaVistoria.Localidade;
        }
    }
}