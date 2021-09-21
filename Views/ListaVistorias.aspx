<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaVistorias.aspx.cs" Inherits="VistoriasProjeto.Views.ListaVistorias" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblStatus" runat="server">
                            Status
                        </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="dplStatus" runat="server">
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblIdUsuario" runat="server">
                            Id do Usuário Responsável
                        </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtIdUsuario" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblIdVistoria" runat="server">
                            Id Vistoria
                        </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtIdVistoria" runat="server"></asp:TextBox>
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
                        <asp:Label ID="lblDataInicial" runat="server">
                            Data Inicial
                        </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtDataInicial" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblEndereco" runat="server">
                            Endereço
                        </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox>
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
            <asp:Button Text="Inserir Vistoria" ID="btnInserirVistoria" runat="server" OnClick="btnInserirVistoria_Click" />
            <asp:GridView ID="dgvVistorias" runat="server" OnRowCommand="dgvVistorias_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnConsulta" runat="server"
                                CommandName="Consulta"
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                Text="Inserir"
                                OnClick="btnInserir_Click" />
                            <asp:Button ID="btnAtualizar" runat="server"
                                CommandName="Atualizar"
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                Text="Atualizar"
                                OnClick="btnAtualizar_Click" />
                            <asp:Button ID="btnExcluir" runat="server"
                                CommandName="Excluir"
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                Text="Excluir"
                                OnClick="btnExcluir_Click" />
                            <asp:Button ID="btnOcorrencias" runat="server"
                                CommandName="Ocorrencias"
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                Text="Ocorrências"
                                OnClick="btnOcorrencias_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("Imagem") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
