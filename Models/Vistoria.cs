using MySqlConnector;
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

        public static string MontaWhereSql(int idVistoria, DateTime dataInicial, DateTime dataFinal, string endereco, int idUsuarioResponsavel, EStatusVistoria status)
        {
            bool primeiro = true;
            var sql = @" WHERE ";

            if (!string.IsNullOrWhiteSpace(endereco))
            {
                if (primeiro)
                {
                    primeiro = false;
                    sql += @" A.LOCALIDADE = @LOCALIDADE ";
                }
                else
                {
                    sql += @" AND A.LOCALIDADE = @LOCALIDADE ";
                }
            }

            if (idVistoria > 0)
            {
                if (primeiro)
                {
                    primeiro = false;
                    sql += @" A.ID = @ID ";
                }
                else
                {
                    sql += @" AND A.ID = @ID ";
                }
            }

            if (dataInicial != default(DateTime) && dataFinal != default(DateTime))
            {
                if (primeiro)
                {
                    primeiro = false;
                    sql += @" A.DATAVISTORIA BETWEEN @DATAVISTORIA AND @DATAVISTORIAFINAL ";
                }
                else
                {
                    sql += @" AND A.DATAVISTORIA BETWEEN @DATAVISTORIA AND @DATAVISTORIAFINAL ";
                }
            }

            if (idUsuarioResponsavel > 0)
            {
                if (primeiro)
                {
                    primeiro = false;
                    sql += @" A.USUARIOID = @USUARIOID ";
                }
                else
                {
                    sql += @" AND A.USUARIOID = @USUARIOID ";
                }
            }

            if (status != EStatusVistoria.Aberto || status != EStatusVistoria.Fechado)
            {
                if (primeiro)
                {
                    primeiro = false;
                    sql += @" A.STATUS = @STATUS";
                }
                else
                {
                    sql += @" AND A.STATUS = @STATUS";
                }
            }

            return sql;
        }

        public static void MontaParametrosSql(MySqlCommand command, int idVistoria, DateTime dataInicial, DateTime dataFinal, string endereco, int idUsuarioResponsavel, EStatusVistoria status)
        {
            if (!string.IsNullOrWhiteSpace(endereco))
            {
                command.Parameters.AddWithValue("@LOCALIDADE", endereco);
            }

            if (idVistoria > 0)
            {
                command.Parameters.AddWithValue("@ID", idVistoria);
            }

            if (idUsuarioResponsavel > 0)
            {
                command.Parameters.AddWithValue("@USUARIOID", idVistoria);
            }

            if (dataInicial != default(DateTime) && dataFinal != default(DateTime))
            {
                command.Parameters.AddWithValue("@DATAVISTORIA", dataInicial.ToString("yyyy/MM/dd"));
                command.Parameters.AddWithValue("@DATAVISTORIAFINAL", dataFinal.ToString("yyyy/MM/dd"));
            }

            if (status != EStatusVistoria.Aberto || status != EStatusVistoria.Fechado)
            {
                command.Parameters.AddWithValue("@STATUS", status);
            }
        }
    }
}