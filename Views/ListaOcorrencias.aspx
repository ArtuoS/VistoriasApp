﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaOcorrencias.aspx.cs" Inherits="VistoriasProjeto.Views.ListaOcorrencias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblStatus" runat="server">
                            Tipo
                        </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="dplTipo" runat="server">
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblIdVistoria" runat="server">
                            Id Vistoria
                        </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtIdVistoria" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblDataInicial" runat="server">
                            Data Inicial
                        </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtDataInicial" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblDataFinal" runat="server">
                            Data Final
                        </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtDataFinal" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblDescricao" runat="server">
                            Descrição
                        </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button runat="server" Text="Pesquisar" ID="btnPesquisar" OnClick="btnPesquisar_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <div>
            <asp:Button Text="Inserir Ocorrências" ID="btnInserirOcorrencia" runat="server" OnClick="btnInserirOcorrencia_Click" />
            <div>
                <asp:DataGrid ID="dgvOcorrencias" runat="server">
                </asp:DataGrid>
            </div>
        </div>
    </form>
</body>
</html>