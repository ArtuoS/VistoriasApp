﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VistoriasProjeto.Models.Enumeradores;

namespace VistoriasProjeto.Models
{
    public class Usuario
    {
        public int Id { get; set; } = GLOBALS.Invalid_Id;
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public EPerfilUsuario Perfil { get; set; }
    }
}