<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="DependencyInjectionWithWebForms._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Literal ID="lit_mensagem" runat="server"></asp:Literal>
            <asp:Button ID="btn_add" runat="server" Text="Add" />
        </div>
    </form>
</body>
</html>
