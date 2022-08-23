<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Laboratorinis.aspx.cs" Inherits="LD2.Laboratorinis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link rel="stylesheet" type="text/css" href="StyleSheet.css">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="LD2_11. Krepšinis."></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Rodyti!" />
            <br />
            <br />
            <asp:Table ID="Table1" runat="server" GridLines="Both">
            </asp:Table>
            <br />
            <asp:Table ID="Table2" runat="server" GridLines="Both">
            </asp:Table>
            <br />
            <asp:Label ID="Label2" runat="server" Text="REZULTATAI:"></asp:Label>
            <br />
            <br />
            <asp:Table ID="Table3" runat="server" GridLines="Both">
            </asp:Table>
            <asp:Table ID="Table4" runat="server" GridLines="Both">
            </asp:Table>
            <asp:Table ID="Table5" runat="server" GridLines="Both">
            </asp:Table>
            <br />
            <asp:Table ID="Table6" runat="server" GridLines="Both">
            </asp:Table>
            <asp:Table ID="Table7" runat="server" GridLines="Both">
            </asp:Table>
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Table ID="Table8" runat="server" GridLines="Both">
            </asp:Table>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
