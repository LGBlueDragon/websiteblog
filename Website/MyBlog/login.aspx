<%@ Page Title="" Language="C#" MasterPageFile="~/website.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MyBlog.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/index.aspx">
    </asp:Login>
</asp:Content>
