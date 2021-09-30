using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace VistoriasProjeto.Models
{
    public static class GLOBALS
    {
        public static Usuario UsuarioLogado { get; set; } = null;
        public static int Invalid_Id { get; private set; } = -1;
        public static CultureInfo Culture { get; private set; } = new CultureInfo("pt-BR");
        public static string RelativeServerPath { get; private set; } = @"/Images/";
        public static string ServerPath { get; private set; } = @"D:/C#/VistoriasApp-master/Images/";

        public static string MontarFilePath(string imageName)
            => string.Concat(GLOBALS.ServerPath, imageName);

        public static string MontarFilePathRelative(string imageName)
            => string.Concat(GLOBALS.RelativeServerPath, imageName);
    }
}