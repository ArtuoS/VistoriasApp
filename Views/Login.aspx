<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VistoriasProjeto.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Content/Login.css" rel="stylesheet" />
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divLogin">
            <asp:Table ID="tblLogin" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">
                            Usuário
                        </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox id="txtLogin" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">
                            Senha
                        </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox id="txtSenha" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button id="btnConfirmar" Text="Confirmar" runat="server" OnClick="btnConfirmar_Click"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
