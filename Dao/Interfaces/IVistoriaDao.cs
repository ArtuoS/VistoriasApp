using VistoriasProjeto.Models;

namespace VistoriasProjeto.Dao.Interfaces
{
    public interface IVistoriaDao : IDefaultDao<Vistoria>
    {
        Vistoria GetVistoriaByFilter(string filter);
    }
}
