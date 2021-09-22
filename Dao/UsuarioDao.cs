using MySqlConnector;
using System;
using System.Collections.Generic;
using VistoriasProjeto.Dao.Interfaces;
using VistoriasProjeto.Models;
using VistoriasProjeto.Models.Enumeradores;

namespace VistoriasProjeto.Dao
{
    public class UsuarioDao : IUsuarioDao
    {
        private readonly MySqlConnection Connection = new MySqlConnection(Utilitarios.ConnectionString);
        private readonly MySqlCommand Command = new MySqlCommand();
        public UsuarioDao()
        {
            Command.Connection = Connection;
        }

        public string EntityName => "USUARIOS";

        public void Delete(int id)
        {
            var sql = $"DELETE FROM {EntityName} WHERE ID = @ID";
            try
            {
                ConnectionHelper.OpenConnection(Connection);
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

        public List<Usuario> GetAll()
        {
            var usuarios = new List<Usuario>();
            var sql = $"SELECT * FROM {EntityName}";
            MySqlDataReader Reader;

            try
            {
                ConnectionHelper.Init(Connection, Command);

                Command.CommandText = sql;

                Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    usuarios.Add(new Usuario()
                    {
                        Id = Convert.ToInt32(Reader["ID"]),
                        Login = Reader["LOGIN"].ToString(),
                        Senha = Reader["SENHA"].ToString(),
                        Perfil = (EPerfilUsuario)Enum.Parse(typeof(EPerfilUsuario), Reader["PERFIL"].ToString()),
                        Nome = Reader["NOME"].ToString()
                    });
                }

                return usuarios;
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

        public Usuario GetById(int id)
        {
            var usuario = new Usuario();
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
                    usuario.Id = Convert.ToInt32(Reader["ID"]);
                    usuario.Login = Reader["LOGIN"].ToString();
                    usuario.Senha = Reader["SENHA"].ToString();
                    usuario.Perfil = (EPerfilUsuario)Enum.Parse(typeof(EPerfilUsuario), Reader["PERFIL"].ToString());
                    usuario.Nome = Reader["NOME"].ToString();
                }

                return usuario;
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

        public Usuario GetByLoginAndSenha(string login, string senha)
        {
            Usuario usuario = new Usuario();
            MySqlDataReader Reader;

            var sql = $"SELECT * FROM {EntityName} WHERE LOGIN = @LOGIN AND SENHA = @SENHA";

            try
            {
                ConnectionHelper.Init(Connection, Command);
                Command.CommandText = sql;
                Command.Parameters.AddWithValue("@LOGIN", login);
                Command.Parameters.AddWithValue("@SENHA", senha);

                Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    usuario.Id = Convert.ToInt32(Reader["ID"]);
                    usuario.Login = Reader["LOGIN"].ToString();
                    usuario.Senha = Reader["SENHA"].ToString();
                    usuario.Perfil = (EPerfilUsuario)Enum.Parse(typeof(EPerfilUsuario), Reader["PERFIL"].ToString());
                    usuario.Nome = Reader["NOME"].ToString();
                }

                return usuario;
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

        public string GetNameById(int id)
        {
            string nome = "";
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
                    nome = Reader["NOME"].ToString();
                }

                return nome;
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

        public void Insert(Usuario entity)
        {
            var sql = $"INSERT INTO ${EntityName} (LOGIN, SENHA, PERFIL, NOME)" +
                      $"VALUES (@LOGIN, @SENHA, @PERFIL, @NOME) WHERE ID = @ID";
            try
            {
                ConnectionHelper.Init(Connection, Command);
                Command.CommandText = sql;
                Command.Parameters.AddWithValue("@LOGIN", entity.Login);
                Command.Parameters.AddWithValue("@SENHA", entity.Senha);
                Command.Parameters.AddWithValue("@PERFIL", (int)entity.Perfil);
                Command.Parameters.AddWithValue("@NOME", entity.Nome);
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

        public void Update(Usuario entity)
        {
            var sql = $"UPDATE ${EntityName} SET LOGIN = @LOGIN AND SENHA = @SENHA AND PERFIL = @PERFIL AND NOME = @NOME WHERE ID = @ID";

            try
            {
                ConnectionHelper.Init(Connection, Command);
                Command.CommandText = sql;
                Command.Parameters.AddWithValue("@LOGIN", entity.Login);
                Command.Parameters.AddWithValue("@SENHA", entity.Senha);
                Command.Parameters.AddWithValue("@PERFIL", (int)entity.Perfil);
                Command.Parameters.AddWithValue("@NOME", entity.Nome);
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

        public bool ValidateLoginUsuario(string login, string senha)
        {
            string nome = "";
            MySqlDataReader Reader;

            var sql = $"SELECT * FROM {EntityName} WHERE LOGIN = @LOGIN AND SENHA = @SENHA";

            try
            {
                ConnectionHelper.Init(Connection, Command);
                Command.CommandText = sql;
                Command.Parameters.AddWithValue("@LOGIN", login);
                Command.Parameters.AddWithValue("@SENHA", senha);

                Reader = Command.ExecuteReader();

                return Reader.Read();
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