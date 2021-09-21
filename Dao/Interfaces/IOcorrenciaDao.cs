using System.Collections.Generic;
using VistoriasProjeto.Models;

namespace VistoriasProjeto.Dao.Interfaces
{
    public interface IOcorrenciaDao : IDefaultDao<Ocorrencia>
    {
        List<Ocorrencia> GetOcorrenciasByFilter(string filter);
        List<Ocorrencia> GetByVistoria(int idVistoria);
    }
}
