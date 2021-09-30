using System;
using System.Collections.Generic;
using VistoriasProjeto.Models;
using VistoriasProjeto.Models.Enumeradores;

namespace VistoriasProjeto.Dao.Interfaces
{
    public interface IVistoriaDao : IDefaultDao<Vistoria>
    {
        List<Vistoria> GetVistoriaByFilter(int idVistoria, DateTime dataInicial, DateTime dataFinal, string endereco, int idUsuarioResponsavel, EStatusVistoria status);
    }
}
