using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VistoriasProjeto.Dao.Interfaces;
using VistoriasProjeto.Models;
using VistoriasProjeto.Models.Enumeradores;

namespace VistoriasProjeto.Dao
{
    public class OcorrenciaDao : IOcorrenciaDao
    {
        private readonly MySqlConnection Connection = new MySqlConnection(Utilitarios.ConnectionString);
        private readonly MySqlCommand Command = new MySqlCommand();

        public OcorrenciaDao()
        {
            Command.Connection = Connection;
            ConnectionHelper.OpenConnection(Connection);
        }

        public string EntityName => "OCORRENCIAS";

        public void Delete(int id)
        {
            var sql = $"DELETE FROM {EntityName} WHERE ID = @ID";
            try
            {
                ConnectionHelper.Init(Connection, Command);
                Command.CommandText = sql;
                Command.Parameters.AddWithValue("@ID", id);
                Command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ConnectionHelper.CloseConnection(Connection);
            }
        }

        public List<Ocorrencia> GetAll()
        {
            var ocorrencias = new List<Ocorrencia>();
            var sql = $"SELECT * FROM {EntityName}";
            MySqlDataReader Reader;

            try
            {
                ConnectionHelper.Init(Connection, Command);

                Command.CommandText = sql;

                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    ocorrencias.Add(new Ocorrencia()
                    {
                        Id = Convert.ToInt32(Reader["ID"]),
                        DataOcorrencia = Convert.ToDateTime(Reader["DATAOCORRENCIA"]),
                        Descricao = Reader["DESCRICAO"].ToString(),
                        Tipo = (ETipoOcorrencia)Enum.Parse(typeof(ETipoOcorrencia), Reader["TIPO"].ToString()),
                        VistoriaId = Convert.ToInt32(Reader["VISTORIAID"])
                    });
                }

                return ocorrencias;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                ConnectionHelper.CloseConnection(Connection);
            }
        }

        public Ocorrencia GetById(int id)
        {
            var ocorrencia = new Ocorrencia();
            MySqlDataReader Reader;

            var sql = $"SELECT * FROM {EntityName} WHERE ID = @ID";

            try
            {
                ConnectionHelper.Init(Connection, Command);
                Command.CommandText = sql;
                Command.Parameters.AddWithValue("@ID", id);

                Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    ocorrencia.Id = Convert.ToInt32(Reader["ID"]);
                    ocorrencia.DataOcorrencia = Convert.ToDateTime(Reader["DATAOCORRENCIA"]);
                    ocorrencia.Descricao = Reader["DESCRICAO"].ToString();
                    ocorrencia.Tipo = (ETipoOcorrencia)Enum.Parse(typeof(ETipoOcorrencia), Reader["TIPO"].ToString());
                    ocorrencia.VistoriaId = Convert.ToInt32(Reader["VISTORIAID"]);
                }

                return ocorrencia;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                ConnectionHelper.CloseConnection(Connection);
            }
        }

        public List<Ocorrencia> GetByVistoria(int idVistoria)
        {
            var ocorrencias = new List<Ocorrencia>();
            MySqlDataReader Reader;

            var sql = $"SELECT * FROM {EntityName} WHERE VISTORIAID = @VISTORIAID";

            try
            {
                ConnectionHelper.Init(Connection, Command);
                Command.CommandText = sql;
                Command.Parameters.AddWithValue("@VISTORIAID", idVistoria);

                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    ocorrencias.Add(new Ocorrencia()
                    {
                        Id = Convert.ToInt32(Reader["ID"]),
                        DataOcorrencia = Convert.ToDateTime(Reader["DATAOCORRENCIA"]),
                        Descricao = Reader["DESCRICAO"].ToString(),
                        Tipo = (ETipoOcorrencia)Enum.Parse(typeof(ETipoOcorrencia), Reader["TIPO"].ToString()),
                        VistoriaId = Convert.ToInt32(Reader["VISTORIAID"]),
                    });
                }

                return ocorrencias;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                ConnectionHelper.CloseConnection(Connection);
            }
        }

        public List<Ocorrencia> GetOcorrenciasByFilter(string descricao, int idVistoria, DateTime dataInicial, DateTime dataFinal, ETipoOcorrencia tipo)
        {
            var ocorrencias = new List<Ocorrencia>();
            var sql = $"SELECT * FROM {EntityName} A" + 
                Ocorrencia.MontaWhereSql(descricao, idVistoria, dataInicial, dataFinal, tipo);
            MySqlDataReader Reader;

            try
            {
                ConnectionHelper.Init(Connection, Command);

                Ocorrencia.MontaParametrosSql(Command, descricao, idVistoria,dataInicial, dataFinal, tipo);

                Command.CommandText = sql;

                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    ocorrencias.Add(new Ocorrencia()
                    {
                        Id = Convert.ToInt32(Reader["ID"]),
                        DataOcorrencia = Convert.ToDateTime(Reader["DATAOCORRENCIA"]),
                        Descricao = Reader["DESCRICAO"].ToString(),
                        Tipo = (ETipoOcorrencia)Enum.Parse(typeof(ETipoOcorrencia), Reader["TIPO"].ToString()),
                        VistoriaId = Convert.ToInt32(Reader["VISTORIAID"])
                    });
                }

                return ocorrencias;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ConnectionHelper.CloseConnection(Connection);
            }
        }

        public void Insert(Ocorrencia entity)
        {
            var sql = $"INSERT INTO {EntityName} (DATAOCORRENCIA, DESCRICAO, TIPO, VISTORIAID)" +
                      $"VALUES (@DATAOCORRENCIA, @DESCRICAO, @TIPO, @VISTORIAID)";
            try
            {
                ConnectionHelper.Init(Connection, Command);
                Command.CommandText = sql;
                Command.Parameters.AddWithValue("@DATAOCORRENCIA", entity.DataOcorrencia);
                Command.Parameters.AddWithValue("@DESCRICAO", entity.Descricao);
                Command.Parameters.AddWithValue("@TIPO", (int)entity.Tipo);
                Command.Parameters.AddWithValue("@VISTORIAID", entity.VistoriaId);
                Command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ConnectionHelper.CloseConnection(Connection);
            }
        }

        public void Update(Ocorrencia entity)
        {
            var sql = $"UPDATE {EntityName} SET DATAOCORRENCIA = @DATAOCORRENCIA, DESCRICAO = @DESCRICAO, TIPO = @TIPO, VISTORIAID = @VISTORIAID WHERE ID = @ID";

            try
            {
                ConnectionHelper.Init(Connection, Command);
                Command.CommandText = sql;
                Command.Parameters.AddWithValue("@DATAOCORRENCIA", entity.DataOcorrencia);
                Command.Parameters.AddWithValue("@DESCRICAO", entity.Descricao);
                Command.Parameters.AddWithValue("@TIPO", entity.Tipo);
                Command.Parameters.AddWithValue("@VISTORIAID", entity.VistoriaId);
                Command.Parameters.AddWithValue("@ID", entity.Id);
                Command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ConnectionHelper.CloseConnection(Connection);
            }
        }
    }
}