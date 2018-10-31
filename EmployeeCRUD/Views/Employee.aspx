﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="EmployeeCRUD.Views.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hfEmployeeID" runat="server" />

            <table>

                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="EPF"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEPF" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Department"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDepartment" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Designation"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox>
                    </td>
                </tr>
              
                 <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                    </td>
                </tr>
                   <tr>
                    <td colspan="2">
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </td>
                </tr>

            </table>


            <br />
            <asp:GridView ID="grdEmployees" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="EPF" HeaderText="EPF" />
                    <asp:BoundField DataField="Department" HeaderText="Department" />
                    <asp:BoundField DataField="Designation" HeaderText="Designation" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkView" runat="server" CommandArgument='<%# Eval("EmployeeID") %>' OnClick="lnkView_Click">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>


            </asp:GridView>

        </div>
    </form>
</body>
</html>
