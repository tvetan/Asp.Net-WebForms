<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="LibrarySystem.Library_System.Search" %>
<asp:Content ID="ContentSearch" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Search Results for Query
        "<asp:Literal ID="LiteralQuery" runat="server" Mode="Encode" />":
    </h1>
    <ul>

        <asp:Repeater ID="RepeaterResults" runat="server" ItemType="LibrarySystem.Models.Book" SelectMethod="RepeaterResults_GetData">
            <ItemTemplate>
                <li>
                    <asp:HyperLink 
                        NavigateUrl='<%#: String.Format("~/Library-System/BookDetails?id={0}", Item.BookId)  %>' 
                        Text='<%#:String.Format("{0} by {1}", Item.Title, Item.Author) %>' runat="server" />
                    (Category:<asp:Literal Text="<%#: Item.Category.Name %>" runat="server" /> )
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</asp:Content>
