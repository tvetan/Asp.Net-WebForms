<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="LibrarySystem.Library_System.BookDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView runat="server" ID="FormViewBook" ItemType="LibrarySystem.Models.Book">
        <ItemTemplate>
            <h1> Book Details</h1>
            <div class="well">
                <asp:Literal Text="<%#: Item.Title %>" runat="server" /> <br />
            </div>
            <p>
                by
                <asp:Literal Text="<%#: Item.Author %>" runat="server" /> <br />
            </p>
            <p></p>
            ISBN
            <asp:Literal Text="<%#: Item.ISBN %>" runat="server" /> <br />
            </p>
            <p>
                Web Site
                <asp:HyperLink NavigateUrl="<%#: Item.Web_Site %>" Text="<%#: Item.Web_Site %>" runat="server" /> <br />
            </p>
            <asp:Literal Text="<%#: Item.Description %>" runat="server" /> <br />
        </ItemTemplate>
    </asp:FormView>
    <asp:HyperLink NavigateUrl="~/Library" Text="Back to Books" runat="server" />

</asp:Content>
