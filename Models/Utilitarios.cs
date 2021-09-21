using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VistoriasProjeto.Models
{
    public class Utilitarios
    {
        public static string ConnectionString { get; private set; } = "Server=localhost;Database=molinaridb;Uid=root;AllowZeroDateTime=True;";
    }
}