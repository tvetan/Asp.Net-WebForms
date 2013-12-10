<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditBooks.aspx.cs" Inherits="LibrarySystem.Admin.EditBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit Books</h1>

    <asp:GridView runat="server" ID="GridViewBooks" ItemType="LibrarySystem.Models.Book" DataKeyNames="CategoryId" 
                  AutoGenerateColumns="false" AllowSorting="true" AllowPaging="true" PageSize="5"
                  SelectMethod="GridViewBooks_GetData" >

        <Columns>

            <%--<asp:BoundField  DataField="Title" HeaderText="Title" SortExpression="Title"/>--%>

            <asp:TemplateField ControlStyle-Width="200" HeaderText="Title" SortExpression="Title">
                <ItemTemplate>
                    <asp:Literal Text="<%#:Cut(  Item.Title) %>"   runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ControlStyle-Width="200" HeaderText="Author" SortExpression="Author">
                <ItemTemplate >
                    <asp:Literal  Text="<%#: Cut( Item.Author) %>"   runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField ControlStyle-Width="200" HeaderText="ISBN" SortExpression="ISBN">
                <ItemTemplate>
                    <asp:Literal Text="<%#:Cut(Item.ISBN) %>"   runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ControlStyle-Width="200" HeaderText="Web Site" SortExpression="Web_Site">
                <ItemTemplate>
                    <asp:HyperLink Text="<%#: Cut( Item.Web_Site) %>" NavigateUrl="<%#: Item.Web_Site %>"   runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ControlStyle-Width="200" HeaderText="Category Name" >
                <ItemTemplate>
                    <asp:Literal Text="<%#: Cut( Item.Category.Name) %>"   runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button Text="Edit" ID="ButtonEditCategory" 
                                CommandName="EditCategory" CommandArgument="<%# Item.BookId %>" 
                                OnCommand="ButtonEditBook_Command" runat="server" />
                    <asp:Button Text="Delete" CommandName="DeleteCategory" OnCommand="ButtonDeleteConfirmation_Command"
                                CommandArgument="<%# Item.BookId %>" 
                                runat="server" />
                </ItemTemplate>

            </asp:TemplateField>
        </Columns>

        <EmptyDataTemplate>
            No Data Available
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:Button Text="Create New" ID="ButtonCreate" 
                OnClick="ButtonCreate_Click" Visible="true" runat="server" />
    <div class="container">
        <div class="span4">
            <asp:Panel runat="server" ID="PanelCreate" Visible="false">
                <fieldset>
                    <div class="well">Create New Book </div>
                    Title:
                    <asp:TextBox ID="TextBoxTitleCreate" runat="server"  /> <br />
                    Author(s):
                    <asp:TextBox ID="TextBoxAuthorCreate" runat="server"  /> <br />
                    ISBN:
                    <asp:TextBox ID="TextBoxISBNCreate" runat="server"  /> <br />

                    Web site:
                    <asp:TextBox ID="TextBoxWebSiteCreate" runat="server"  /> <br />

                    Description:
                    <asp:TextBox TextMode="MultiLine" ID="TextBoxDescriptionCreate" runat="server"  /> <br />

                    Category:
                    <asp:DropDownList runat="server" ID="BookDropDownCreate"  DataTextField="Name"
                                      DataValueField="CategoryId">
                    </asp:DropDownList> <br />

                    <asp:Button Text="Create" ID="ButtonCreateCategory" OnClick="ButtonCreateBook_Click" runat="server" />
                    <asp:Button ID="ButtonCancel" Text="Cancel" OnClick="ButtonCancel_Click" runat="server" />
                </fieldset>
            </asp:Panel>

        </div>
    </div>

    <div class="container">
        <div class="span4">
            <asp:Panel runat="server" ID="PanelUpdate" Visible="false">
                <fieldset>
                    <div class="well">Update New Book </div>
                    Title:
                    <asp:TextBox ID="TextBoxUpdateTitle" runat="server"  /> <br />
                    Author(s):
                    <asp:TextBox ID="TextBoxUpdateAuthor" runat="server"  /> <br />
                    ISBN:
                    <asp:TextBox ID="TextBoxUpdateISBN" runat="server"  /> <br />

                    Web site:
                    <asp:TextBox ID="TextBoxUpdateWebSite" runat="server"  /> <br />

                    Description:
                    <asp:TextBox TextMode="MultiLine" ID="TextBoxUpdateDescription" runat="server"  /> <br />

                    Category:
                    <asp:DropDownList runat="server" ID="DropDownListUpdateCategory"  DataTextField="Name"
                                      DataValueField="CategoryId">
                    </asp:DropDownList> <br />

                    <asp:Button Text="Save" ID="ButtonUpdate" CommandName="UpdateBook"
                                OnCommand="ButtonUpdate_Command" runat="server" />
                    <asp:Button  Text="Cancel" ID="Button2" OnClick="ButtonCancel_Click" runat="server" />
                </fieldset>
            </asp:Panel>

        </div>
    </div>

    <div class="container">
        <div class="span4">
            <asp:Panel runat="server" ID="PanelDelete" Visible="false">
                <fieldset>
                    <div class="well">Confirm Book Deletion?</div>
                    Category
                    <asp:TextBox ID="TextBoxDeleteBook" ReadOnly="true" runat="server"  /> <br />
                    <asp:Button Text="Yes"  ID="ButtonDelete" OnCommand="ButtonDelete_Command" CommandName="EditCategoryCommand"
                                runat="server" />
                    <asp:Button Text="No" ID="ButtonCalcelDelete"   OnClick="ButtonCalcelDelete_Click" runat="server" />
                </fieldset>
            </asp:Panel>

        </div>
    </div>
    <asp:HyperLink NavigateUrl="~/Library" Text="Back to Books" runat="server" />

</asp:Content>
