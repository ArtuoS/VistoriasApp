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
            bool primeiro = true;
            var sql = @" WHERE ";

            if (!string.IsNullOrWhiteSpace(descricao))
            {
                if (primeiro)
                {
                    primeiro = false;
                    sql += @" A.DESCRICAO = @DESCRICAO% ";
                }
                else
                {
                    sql += @" AND A.DESCRICAO = @DESCRICAO ";
                }
            }

            if (idVistoria > 0)
            {
                if (primeiro)
                {
                    primeiro = false;
                    sql += @" A.VISTORIAID = @VISTORIAID ";
                }
                else
                {
                    sql += @" A.VISTORIAID = @VISTORIAID ";
                }
            }

            if (dataInicial != default(DateTime) && dataFinal != default(DateTime))
            {
                if (primeiro)
                {
                    primeiro = false;
                    sql += @" A.DATAOCORRENCIA BETWEEN @DATAOCORRENCIA AND @DATAOCORRENCIAFINAL ";
                }
                else
                {
                    sql += @" AND A.DATAOCORRENCIA BETWEEN @DATAOCORRENCIA AND @DATAOCORRENCIAFINAL ";
                }
            }

            if (tipo != ETipoOcorrencia.Ambiental || tipo != ETipoOcorrencia.Patrimonial)
            {
                if (primeiro)
                {
                    primeiro = false;
                    sql += @" A.TIPO = @TIPO";
                }
                else
                {
                    sql += @" AND A.TIPO = @TIPO";
                }
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
                command.Parameters.AddWithValue("@VISTORIAID", idVistoria);
            }

            if (dataInicial != default(DateTime) && dataFinal != default(DateTime))
            {
                command.Parameters.AddWithValue("@DATAOCORRENCIA", dataInicial.ToString("yyyy/MM/dd"));
                command.Parameters.AddWithValue("@DATAOCORRENCIAFINAL", dataFinal.ToString("yyyy/MM/dd"));
            }

            if (tipo != ETipoOcorrencia.Ambiental || tipo != ETipoOcorrencia.Patrimonial)
            {
                command.Parameters.AddWithValue("@TIPO", tipo);
            }
        }
    }
}