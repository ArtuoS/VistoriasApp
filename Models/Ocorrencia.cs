using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VistoriasProjeto.Dao;
using VistoriasProjeto.Models.Enumeradores;
using VistoriasProjeto.Models.Interfaces;

namespace VistoriasProjeto.Models
{
    public class Ocorrencia : IOcorrencia
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

        public void ClonarPropriedades(Ocorrencia novaOcorrencia)
        {
            if (Tipo != novaOcorrencia.Tipo)
                Tipo = novaOcorrencia.Tipo;

            if (DataOcorrencia != novaOcorrencia.DataOcorrencia && novaOcorrencia.DataOcorrencia != default(DateTime))
                DataOcorrencia = novaOcorrencia.DataOcorrencia;

            if (Descricao != novaOcorrencia.Descricao && !string.IsNullOrEmpty(novaOcorrencia.Descricao))
                Descricao = novaOcorrencia.Descricao;

            if (VistoriaId != novaOcorrencia.VistoriaId && novaOcorrencia.VistoriaId != GLOBALS.Invalid_Id)
                VistoriaId = novaOcorrencia.VistoriaId;
        }

        public static string MontaWhereSql(string descricao, int idVistoria, DateTime dataInicial, DateTime dataFinal, ETipoOcorrencia tipo)
        {
            var sql = @" WHERE ";

            if (!string.IsNullOrWhiteSpace(descricao))
            {
                sql += @"A.DESCRICAO = @DESCRICAO AND ";
            }

            if (idVistoria > 0)
            {
                sql += @"A.VISTORIAID = @VISTORIAID AND ";
            }

            if (dataInicial != default(DateTime) && dataFinal != default(DateTime))
            {
                sql += @"A.DATAOCORRENCIA BETWEEN @DATAOCORRENCIA AND @DATAOCORRENCIAFINAL AND ";
            }

            if (tipo != ETipoOcorrencia.Ambiental || tipo != ETipoOcorrencia.Patrimonial)
            {
                sql += @"A.TIPO = @TIPO";
            }

            return sql;
        }

        public static void MontaParametrosSql(MySqlCommand command, string descricao, int idVistoria, DateTime dataInicial, DateTime dataFinal, ETipoOcorrencia tipo)
        {
            if (!string.IsNullOrWhiteSpace(descricao))
            {
                command.Parameters.AddWithValue("@DESCRICAO", descricao);
            }

            if (idVistoria > 0)
            {
                command.Parameters.AddWithValue("@VISTORIA_ID", idVistoria);
            }

            if (dataInicial != default(DateTime) && dataFinal != default(DateTime))
            {
                command.Parameters.AddWithValue("@DATAOCORRENCIA", dataInicial.ToString("dd/MM/YYYY"));
                command.Parameters.AddWithValue("@DATAOCORRENCIAFINAL", dataFinal.ToString("dd/MM/YYYY"));
            }

            if (tipo != ETipoOcorrencia.Ambiental || tipo != ETipoOcorrencia.Patrimonial)
            {
                command.Parameters.AddWithValue("@TIPO", tipo);
            }
        }
    }
}