using MySqlConnector;
using System;
using System.Collections.Generic;
using VistoriasProjeto.Dao.Interfaces;
using VistoriasProjeto.Models;
using VistoriasProjeto.Models.Enumeradores;

namespace VistoriasProjeto.Dao
{
    public class VistoriaDao : IVistoriaDao
    {
        private readonly MySqlConnection Connection = new MySqlConnection(Utilitarios.ConnectionString);
        private readonly MySqlCommand Command = new MySqlCommand();

        public VistoriaDao()
        {
            Command.Connection = Connection;
            ConnectionHelper.OpenConnection(Connection);
        }

        public string EntityName => "VISTORIAS";

        public void Delete(int id)
        {
            var sql = $"DELETE FROM {EntityName} WHERE ID = @ID";
            try
            {
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

        public List<Vistoria> GetAll()
        {
            var vistorias = new List<Vistoria>();
            var sql = $"SELECT * FROM {EntityName}";
            MySqlDataReader Reader;

            try
            {
                Command.CommandText = sql;

                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    vistorias.Add(new Vistoria()
                    {
                        Id = Convert.ToInt32(Reader["ID"]),
                        DataVistoria = Convert.ToDateTime(Reader["DATAVISTORIA"]),
                        Descricao = Reader["DESCRICAO"].ToString(),
                        Localidade = Reader["LOCALIDADE"].ToString(),
                        Status = (EStatusVistoria)Enum.Parse(typeof(EStatusVistoria), Reader["STATUS"].ToString()),
                        UsuarioId = Convert.ToInt32(Reader["USUARIOID"]),
                        Imagem = Reader["IMAGEM"].ToString()
                    });
                }

                return vistorias;
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

        public Vistoria GetById(int id)
        {
            var vistoria = new Vistoria();
            var sql = $"SELECT * FROM {EntityName} WHERE ID = @ID";
            MySqlDataReader Reader;

            try
            {
                Command.CommandText = sql;
                Command.Parameters.AddWithValue("@ID", id);
                Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    vistoria.Id = Convert.ToInt32(Reader["ID"]);
                    vistoria.DataVistoria = Convert.ToDateTime(Reader["DATAVISTORIA"]);
                    vistoria.Descricao = Reader["DESCRICAO"].ToString();
                    vistoria.Localidade = Reader["LOCALIDADE"].ToString();
                    vistoria.Status = (EStatusVistoria)Enum.Parse(typeof(EStatusVistoria), Reader["STATUS"].ToString());
                    vistoria.UsuarioId = Convert.ToInt32(Reader["USUARIOID"]);
                    vistoria.Imagem = Reader["IMAGEM"].ToString();
                }

                return vistoria;
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

        public Vistoria GetVistoriaByFilter(string filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Vistoria entity)
        {
            var sql = $"INSERT INTO {EntityName} (DATAVISTORIA, DESCRICAO, LOCALIDADE, STATUS, USUARIOID, IMAGEM)" +
                      $"VALUES (@DATAVISTORIA, @DESCRICAO, @LOCALIDADE, @STATUS, @USUARIOID, @IMAGEM)";
            try
            {
                Command.CommandText = sql;
                Command.Parameters.AddWithValue("@DATAVISTORIA", entity.DataVistoria);
                Command.Parameters.AddWithValue("@LOCALIDADE", entity.Localidade);
                Command.Parameters.AddWithValue("@USUARIOID", entity.UsuarioId);
                Command.Parameters.AddWithValue("@DESCRICAO", entity.Descricao);
                Command.Parameters.AddWithValue("@STATUS", (int)entity.Status);
                Command.Parameters.AddWithValue("@IMAGEM", entity.Imagem);
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

        public void Update(Vistoria entity)
        {
            var vistoria = GetById(entity.Id);
            var sql = $"UPDATE {EntityName} SET DATAVISTORIA = @DATAVISTORIA AND DESCRICAO = @DESCRICAO AND LOCALIDADE = @LOCALIDADE " +
                      $"AND STATUS = @STATUS AND USUARIOID = @USUARIOID WHERE ID = @ID";

            try
            {
                Command.CommandText = sql;
                Command.Parameters.AddWithValue("@DATAVISTORIA", (vistoria.DataVistoria != entity.DataVistoria) ? entity.DataVistoria : vistoria.DataVistoria);
                Command.Parameters.AddWithValue("@LOCALIDADE", (vistoria.Localidade != entity.Localidade) ? entity.Localidade : vistoria.Localidade);
                Command.Parameters.AddWithValue("@USUARIOID", (vistoria.UsuarioId != entity.UsuarioId) ? entity.UsuarioId : vistoria.UsuarioId);
                Command.Parameters.AddWithValue("@DESCRICAO", (vistoria.Descricao != entity.Descricao) ? entity.Descricao : vistoria.Descricao);
                Command.Parameters.AddWithValue("@STATUS", ((int)vistoria.Status != (int)entity.Status) ? (int)entity.Status : (int)vistoria.Status);
                Command.Parameters.AddWithValue("@ID", (vistoria.Id != entity.Id) ? entity.Id : vistoria.Id);
                Command.Parameters.AddWithValue("@IMAGEM", (vistoria.Imagem != entity.Imagem) ? entity.Imagem : vistoria.Imagem));
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