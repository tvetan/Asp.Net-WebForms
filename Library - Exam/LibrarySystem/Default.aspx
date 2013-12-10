<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibrarySystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <h1> Books </h1>
        <div class="form-seach pull-right">
            <div class="append">
                <asp:TextBox ID="TextBoxSearchParam" runat="server" />
                <asp:Button ID="ButtonSearch" Text="Search" runat="server" CommandName="Search"
                            OnCommand="ButtonSearch_Command" />
            </div>
        </div>
        <asp:ListView runat="server" ID="ListViewCategories" ItemType="LibrarySystem.Models.Category"
                      SelectMethod="ListViewCategories_GetData" >
            <LayoutTemplate>
                <div class="container">

                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>

                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="span3">
                    <h3>
                        <asp:Literal Text="<%#: Item.Name %>" runat="server" />
                    </h3>
                    <ul>
                        <asp:ListView runat="server" ItemType="LibrarySystem.Models.Book" DataSource="<%# GetDataSourse(Item.CategoryId) %>">
                            <ItemTemplate>
                                <li>
                                    <asp:HyperLink 
                                        NavigateUrl='<%#: string.Format("~/Library-System/BookDetails?id={0}",Item.BookId) %>' 
                                        Text="<%#: Item.Title %>" runat="server" />
                                </li>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                No books in this category.
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </ul>
                </div>
            </ItemTemplate>

        </asp:ListView>
    </div>

</asp:Content>
