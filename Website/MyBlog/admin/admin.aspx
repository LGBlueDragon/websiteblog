<%@ Page Title="" Language="C#" MasterPageFile="~/website.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="MyBlog.blogpostform" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="div_title"><h1>Create Post</h1></div>
    <div id="div_postframe">
        <div id="div_title">
            <asp:TextBox ID="textbox_title" runat="server" Width="270px"></asp:TextBox></div>
        <div id="div_content">
            <asp:TextBox ID="textbox_content" runat="server" TextMode="MultiLine" Width="66%" Height="200px"></asp:TextBox></div>
        <div id="div_buttons">
            <asp:Button ID="button_confirmpost" runat="server" Text="Post" OnClick="button_confirmpost_Click" />
            <asp:Button ID="button_cancelpost" runat="server" Text="Cancel" OnClick="button_cancelpost_Click" /></div>
    </div>
</asp:Content>
