<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaVistorias.aspx.cs" MasterPageFile="~/Views/Website.Master" Inherits="VistoriasProjeto.Views.ListaVistorias" %>

<asp:Content ID="ListaVistorias" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <asp:GridView ID="dgvVistorias" class="gridview" runat="server" OnRowCommand="dgvVistorias_RowCommand" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnConsulta" runat="server"
                            CommandName="Consultar"
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                            Text="Consultar"
                            OnClick="btnConsulta_Click" />
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
                            OnClientClick="abrirModalOcorrencias()" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:BoundField DataField="DataVistoria" HeaderText="Data Vistoria" />
                <asp:BoundField DataField="Descricao" HeaderText="Descricao" />
                <asp:BoundField DataField="Localidade" HeaderText="Localidade" />
                <asp:BoundField DataField="UsuarioId" HeaderText="Id do Usuario" />
                <asp:ImageField DataImageUrlField="Imagem" ControlStyle-Height="100" ControlStyle-Width="100" runat="server" HeaderText="Imagem">
                    <ControlStyle Height="100px" Width="100px"></ControlStyle>
                </asp:ImageField>

            </Columns>
        </asp:GridView>
    </div>
    
</asp:Content>

