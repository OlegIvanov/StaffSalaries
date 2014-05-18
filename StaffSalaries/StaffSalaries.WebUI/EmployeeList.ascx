﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeList.ascx.cs" Inherits="StaffSalaries.WebUI.EmployeeList" %>

<span>Job Title:</span>
<asp:DropDownList ID="ddlJobList" runat="server" AutoPostBack="true" DataValueField="Id" DataTextField="Name"></asp:DropDownList>
<p>Employees/Salary:</p>
<asp:GridView ID="gvEmployeeList" runat="server" AutoGenerateColumns="false">
    <Columns>
        <asp:TemplateField ItemStyle-Width="300" HeaderStyle-HorizontalAlign="Left" HeaderStyle-BackColor="LightGray">
            <HeaderTemplate>
                <asp:LinkButton CommandName="SortAndOrderByFullName" runat="server" Text="FullName" Font-Bold="false"></asp:LinkButton>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("FullName") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:HiddenField ID="hfEmployeeId" runat="server" Value='<%# Eval("Id") %>' />
                <%# Eval("FullName") %>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="220" HeaderStyle-HorizontalAlign="Left" HeaderStyle-BackColor="LightGray" ItemStyle-HorizontalAlign="Right">
            <HeaderTemplate>
                <asp:LinkButton CommandName="SortAndOrderBySalary" runat="server" Text="Salary" Font-Bold="false"></asp:LinkButton>
            </HeaderTemplate>
            <ItemTemplate>
                <%# Eval("Salary") %>
            </ItemTemplate>
            <EditItemTemplate>
                <div style="text-align:left">
                    <asp:TextBox ID="tbSalary" runat="server" Text='<%# Eval("Salary") %>' Width="200" Height="20" BorderStyle="Inset"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSalary" runat="server" ControlToValidate="tbSalary" Display="Dynamic" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvSalary" runat="server" ControlToValidate="tbSalary" Type="Currency" MinimumValue="0" MaximumValue="1000000000" Display="Dynamic" Text="*" ForeColor="Red"></asp:RangeValidator>
                </div>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="true" />
    </Columns>
</asp:GridView>
<asp:Panel ID="pPagination" runat="server">
    <asp:Literal runat="server" Text="Pages:"></asp:Literal>&nbsp;
</asp:Panel>