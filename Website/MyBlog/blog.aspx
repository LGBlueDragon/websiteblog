<%@ Page Title="" Language="C#" MasterPageFile="~/website.Master" AutoEventWireup="true" CodeBehind="blog.aspx.cs" Inherits="MyBlog.blogcomments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="div_blogpost"><asp:Label ID="label_blogpost" runat="server" Text="Empty Post"></asp:Label></div>
    <hr />
    <div id ="div_blogcomments"><asp:Label ID="label_comments" runat="server" Text="Empty Comments"></asp:Label></div>
    <hr />
    <div id="div_addcomment"><asp:TextBox ID="textbox_addcomment" runat="server" 
            TextMode="MultiLine" Height="90px" Width="208px"></asp:TextBox>
        <asp:Button ID="button_addcomment"
            runat="server" Text="Post" onclick="button_addcomment_Click" /></div>
</asp:Content>
