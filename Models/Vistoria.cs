using System;
using System.Drawing;
using System.IO;
using VistoriasProjeto.Dao;
using VistoriasProjeto.Models.Enumeradores;

namespace VistoriasProjeto.Models
{
    public class Vistoria
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

        public int Id { get; set; }
        public EStatusVistoria Status { get; set; }
        public DateTime DataVistoria { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public string Localidade { get; set; }
        public int UsuarioId { get; set; }
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
    }
}