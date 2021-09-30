<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroOcorrencia.aspx.cs" MasterPageFile="~/Views/Website.Master" Inherits="VistoriasProjeto.Views.CadastroOcorrencia" %>

<asp:Content ID="CadastroOcorrencias" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Table runat="server">
            <asp:TableRow>
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
                    <asp:Label ID="lblIdOcorrencia" runat="server">
                            Id Ocorrência
                    </asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtIdOcorrencia" runat="server" ReadOnly="true"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblData" runat="server">
                            Data
                    </asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtData" runat="server" ReadOnly="true"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
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
        </asp:Table>
        <div>
            <asp:Button runat="server" Text="Inserir" ID="btnInserir" OnClick="btnInserir_Click" />
            <asp:Button runat="server" Text="Excluir" ID="btnExcluir" OnClick="btnExcluir_Click" />
            <asp:Button runat="server" Text="Atualizar" ID="btnAtualizar" OnClick="btnAtualizar_Click" />
            <asp:Button runat="server" Text="Fechar" ID="btnFechar" OnClick="btnFechar_Click" />
        </div>
    </div>
</asp:Content>


