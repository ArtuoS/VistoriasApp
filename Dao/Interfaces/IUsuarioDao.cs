using VistoriasProjeto.Models;

namespace VistoriasProjeto.Dao.Interfaces
{
    public interface IUsuarioDao : IDefaultDao<Usuario>
    {
        string GetNameById(int id);
        bool ValidateLoginUsuario(string login, string senha);
        Usuario GetByLoginAndSenha(string login, string senha);
    }
}
