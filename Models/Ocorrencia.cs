using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VistoriasProjeto.Dao;
using VistoriasProjeto.Models.Enumeradores;

namespace VistoriasProjeto.Models
{
    public class Ocorrencia
    {
        private VistoriaDao vistoriaDao;
        private VistoriaDao VistoriaDao
        {
            get
            {
                if (vistoriaDao == null)
                    vistoriaDao = new VistoriaDao();
                return vistoriaDao;
            }
        }

        public int Id { get; set; }
        public ETipoOcorrencia Tipo { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string Descricao { get; set; }
        public int VistoriaId { get; set; }
        public Vistoria VistoriaInstance
        {
            get
            {
                if (VistoriaId > 0)
                    VistoriaInstance = VistoriaDao.GetById(VistoriaId);
                return VistoriaInstance;
            }
            set
            {
                if (value != null)
                    VistoriaInstance = value;
                else
                    VistoriaInstance = null;
            }
        }
    }
}