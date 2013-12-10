<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCategories.aspx.cs" Inherits="LibrarySystem.Admin.EditCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="GridViewCategories" ItemType="LibrarySystem.Models.Category" DataKeyNames="CategoryId" 
                  AutoGenerateColumns="false" AllowSorting="true" AllowPaging="true" PageSize="5"
       SelectMethod="ListViewCategories_GetData" >
     

        <Columns>

            <asp:BoundField  DataField="Name" HeaderText="Category Name" SortExpression="Name"/>
            <%-- <asp:Literal Text='<%#: Item.Name %>' runat="server" />--%>
            
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button Text="Edit" ID="ButtonEditCategory" 
                                CommandName="EditCategory" CommandArgument="<%# Item.CategoryId %>" OnCommand="ButtonEditCategory_Command" runat="server" />
                    <asp:Button Text="Delete" CommandName="DeleteCategory" OnCommand="ButtonDeleteConfirmation_Command"
                                CommandArgument="<%# Item.CategoryId %>" 
                                runat="server" />
                </ItemTemplate>

            </asp:TemplateField>
        </Columns>

        <EmptyDataTemplate>
            No Data Available
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:Button Text="Create New" ID="ButtonCreate" OnClick="ButtonCreate_Click" Visible="true" runat="server" />
    <div class="container">
        <div class="span4">
            <asp:Panel runat="server" ID="PanelCreate" Visible="false">
                <fieldset>
                    <div class="well">Create New Category </div>
                    Category
                    <asp:TextBox ID="TextBoxCategoryName" runat="server"  /> <br />

                    <asp:Button Text="Create" ID="ButtonCreateCategory" OnClick="ButtonCreateCategory_Click" runat="server" />
                    <asp:Button ID="ButtonCancel" Text="Cancel" OnClick="ButtonCancel_Click" runat="server" />
                </fieldset>
            </asp:Panel>

        </div>
    </div>

    <div class="container">
        <div class="span4">
            <asp:Panel runat="server" ID="PanelUpdate" Visible="false">
                <fieldset>
                    <div class="well">Edit Category </div>
                    Category
                    <asp:TextBox ID="TextBoxEditCategory" runat="server"  /> <br />
                    <%--<asp:HiddenField runat="server" ID="HiddenFieldIdEdit"/>--%>
                    <asp:Button Text="Save"  ID="ButtonEdit" OnCommand="ButtonEdit_Command" CommandName="EditCategoryCommand"
                                runat="server" />
                    <asp:Button Text="Cancel" ID="ButtonCancelEdit"   OnClick="ButtonCancelEdit_Click" runat="server" />
                </fieldset>
            </asp:Panel>

        </div>
    </div>

    <div class="container">
        <div class="span4">
            <asp:Panel runat="server" ID="PanelDelete" Visible="false">
                <fieldset>
                    <div class="well">Edit Category </div>
                    Category
                    <asp:TextBox ID="TextBoxDeleteCategory" ReadOnly="true" runat="server"  /> <br />
                    <%--<asp:HiddenField runat="server" ID="HiddenFieldIdEdit"/>--%>
                    <asp:Button Text="Yes"  ID="ButtonDelete" OnCommand="ButtonDelete_Command" CommandName="EditCategoryCommand"
                                runat="server" />
                    <asp:Button Text="No" ID="ButtonCalcelDelete"   OnClick="ButtonCalcelDelete_Click" runat="server" />
                </fieldset>
            </asp:Panel>

        </div>
    </div>
    <asp:HyperLink NavigateUrl="~/Library" Text="Back to Books" runat="server" />
</asp:Content>
