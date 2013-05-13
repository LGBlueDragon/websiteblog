<%@ Page Title="" Language="C#" MasterPageFile="~/website.Master" AutoEventWireup="true" CodeBehind="blog.aspx.cs" Inherits="MyBlog.blogcomments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div id="blogrolldiv2"><asp:Label ID="blogroll2" runat="server" Text="BlogRoll"></asp:Label></div>
    <hr />
    <div id ="labelcommentsdiv"><asp:Label ID="labelcomments" runat="server" Text="CommentRoll"></asp:Label></div>
    <hr />
    <div id="printcommentdiv"><asp:TextBox ID="printcomment" runat="server" 
            TextMode="MultiLine" Height="90px" Width="208px"></asp:TextBox>
        <asp:Button ID="printcommentok"
            runat="server" Text="Post" onclick="printcommentok_Click" /></div>
</asp:Content>
