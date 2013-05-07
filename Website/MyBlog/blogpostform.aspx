<%@ Page Title="" Language="C#" MasterPageFile="~/website.Master" AutoEventWireup="true" CodeBehind="blogpostform.aspx.cs" Inherits="MyBlog.blogpostform" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="titleform">
        <asp:TextBox ID="titlebox" runat="server" Width="270px"></asp:TextBox></div>
    <div id="postform">
        <asp:TextBox ID="postformarea" runat="server" 
            TextMode="MultiLine" Width="66%" Height="200px"></asp:TextBox></div>
    <div id="button">
        <asp:Button ID="postconfirm" runat="server" Text="Post" 
            onclick="postconfirm_Click" />
        <asp:Button ID="postcancel" runat="server" Text="Cancel" 
            onclick="postcancel_Click" /></div>
</asp:Content>
