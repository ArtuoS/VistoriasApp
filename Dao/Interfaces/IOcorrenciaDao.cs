using System;
using System.Collections.Generic;
using VistoriasProjeto.Models;
using VistoriasProjeto.Models.Enumeradores;

namespace VistoriasProjeto.Dao.Interfaces
{
    public interface IOcorrenciaDao : IDefaultDao<Ocorrencia>
    {
        List<Ocorrencia> GetOcorrenciasByFilter(string descricao, int idVistoria, DateTime dataInicial, DateTime dataFinal, ETipoOcorrencia tipo);
        List<Ocorrencia> GetByVistoria(int idVistoria);
    }
}
