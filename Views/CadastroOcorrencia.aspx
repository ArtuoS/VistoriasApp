<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroOcorrencia.aspx.cs" Inherits="VistoriasProjeto.Views.CadastroOcorrencia" %>

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
                        <asp:Label id="lblIdVistoria" runat="server">
                            Id Vistoria
                        </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox id="txtIdVistoria" runat="server" ></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label id="lblIdOcorrencia" runat="server">
                            Id Ocorrência
                        </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox id="txtIdOcorrencia" runat="server" ReadOnly="true"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label id="lblData" runat="server">
                            Data
                        </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox id="txtData" runat="server" ReadOnly="true"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label id="lblStatus" runat="server">
                            Tipo
                        </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList id="dplTipo" runat="server">
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label id="lblDescricao" runat="server">
                            Descrição
                        </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox id="txtDescricao" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <div>
                <asp:Button runat="server" Text="Inserir" id="btnInserir" OnClick="btnInserir_Click"/>
                <asp:Button runat="server" Text="Excluir" id="btnExcluir" OnClick="btnExcluir_Click"/>
                <asp:Button runat="server" Text="Atualizar" id="btnAtualizar" OnClick="btnAtualizar_Click"/>
                <asp:Button runat="server" Text="Fechar" id="btnFechar" OnClick="btnFechar_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
