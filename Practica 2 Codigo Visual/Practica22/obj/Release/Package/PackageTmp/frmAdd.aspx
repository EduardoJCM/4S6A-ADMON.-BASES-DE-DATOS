<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAdd.aspx.cs" Inherits="Practica22.frmAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        function SoloNumeros(e) {
            var key = window.event ? e.keyCode : e.which;

            if (key < 48 || key > 57) {
                // Permitir teclas de control como retroceso y suprimir
                if ([8, 9, 27, 13].indexOf(key) !== -1) {
                    return true;
                }
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label2" runat="server" Text="ISBN"></asp:Label>
        <asp:TextBox ID="txtIsbn" runat="server" onkeypress="return SoloNumeros(event);"></asp:TextBox>
        <p>
            <asp:Label ID="Label3" runat="server" Text="TITULO"></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="NUM. EDICIÓN"></asp:Label>
            <asp:TextBox ID="txtNEd" runat="server" onkeypress="return SoloNumeros(event);"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label6" runat="server" Text="AÑO DE PUBLICACIÓN"></asp:Label>
            <asp:TextBox ID="txtADP" runat="server" onkeypress="return SoloNumeros(event);"></asp:TextBox>
        </p>
        <p>
             <asp:Label ID="Label4" runat="server" Text="NOMBRE DE LOS AUTORES"></asp:Label>
             <asp:TextBox ID="txtNameA" runat="server"></asp:TextBox>
        </p>
        <p>
             <asp:Label ID="Label7" runat="server" Text="PAIS DE PUBLICACIÓN"></asp:Label>
             <asp:TextBox ID="txtPaisP" runat="server"></asp:TextBox>
        </p>
        <p>
             <asp:Label ID="Label8" runat="server" Text="SINOPSIS"></asp:Label>
             <asp:TextBox ID="txtSinopsis" runat="server"></asp:TextBox>
        </p>
        <p>
              <asp:Label ID="Label9" runat="server" Text="CARRERA"></asp:Label>
              <asp:TextBox ID="txtCarrera" runat="server"></asp:TextBox>
        </p>
        <p>
              <asp:Label ID="Label10" runat="server" Text="MATERIA"></asp:Label>
              <asp:TextBox ID="txtMateria" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
            <asp:Button ID="btnAtras" runat="server" OnClick="btnAtras_Click" Text="Atras" />
        </p>
    </form>
</body>
</html>
