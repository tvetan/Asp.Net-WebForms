using LibrarySystem.Models;
using System;
using Error_Handler_Control;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem.Admin
{
    public partial class EditCategories : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            //LibrarySystemEntities context = new LibrarySystemEntities();
            //this.ListViewCategories.DataSource = context.Categories.ToList();
            //this.ListViewCategories.DataBind();
            
        }
      
        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            this.PanelCreate.Visible = true;
            this.ButtonCreate.Visible = false;
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.PanelCreate.Visible = false;
            this.ButtonCreate.Visible = true;
        }

        protected void ButtonCreateCategory_Click(object sender, EventArgs e)
        {
            string name = this.TextBoxCategoryName.Text;
            this.TextBoxCategoryName.Text = "";
            if (string.IsNullOrEmpty(name))
            {
                ErrorSuccessNotifier.AddErrorMessage("Category name cannot be empty.");
                this.PanelCreate.Visible = false;
                this.ButtonCreate.Visible = true;
                return;
            }

            if (name.Length > 148)
            {
                ErrorSuccessNotifier.AddErrorMessage("Category name is too long.");
                this.PanelCreate.Visible = false;
                this.ButtonCreate.Visible = true;
                return;
            }

            LibrarySystemEntities context = new LibrarySystemEntities();
            Category category = new Category()
            {
                Name = name
            };
            context.Categories.Add(category);
            context.SaveChanges();
            ErrorSuccessNotifier.AddSuccessMessage("Category created.");
            this.GridViewCategories.SetPageIndex(this.GridViewCategories.PageIndex);
            this.PanelCreate.Visible = false;
            this.ButtonCreate.Visible = true;
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();
            string name = this.TextBoxEditCategory.Text;
            if (string.IsNullOrEmpty(name))
            {
                ErrorSuccessNotifier.AddErrorMessage("The category title cannot be empty");
                this.PanelUpdate.Visible = false;
                this.ButtonCreate.Visible = true;
                return;
            }

            if (name.Length > 148)
            {
                ErrorSuccessNotifier.AddErrorMessage("The category title is too long");
                this.PanelUpdate.Visible = false;
                this.ButtonCreate.Visible = true;
                return;
            }

            int id = Convert.ToInt32(ViewState["categoryId"]);
            Response.Write(id);
            Category category = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            category.Name = name;
            context.SaveChanges();
            ErrorSuccessNotifier.AddSuccessMessage("Category modified.");
            this.PanelUpdate.Visible = false;
            this.ButtonCreate.Visible = true;
        }

        protected void ButtonCancelEdit_Click(object sender, EventArgs e)
        {
            this.PanelUpdate.Visible = false;
            this.ButtonCreate.Visible = true ;
        }

        protected void ButtonEditCategory_Command(object sender, CommandEventArgs e)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();
            int id = Convert.ToInt32(e.CommandArgument);
            this.PanelUpdate.Visible = true;
            this.ButtonCreate.Visible = false;
            this.TextBoxEditCategory.Text = context.Categories.FirstOrDefault(x => x.CategoryId == id).Name;
            ViewState["categoryId"] = id;
        }

        protected void ButtonEdit_Command(object sender, CommandEventArgs e)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();
            string name = this.TextBoxEditCategory.Text;
            if (string.IsNullOrEmpty(name))
            {
                ErrorSuccessNotifier.AddErrorMessage("The category title cannot be empty");
                this.PanelUpdate.Visible = false;
                this.ButtonCreate.Visible = true;
                return;
            }

            if (name.Length > 148)
            {
                ErrorSuccessNotifier.AddErrorMessage("The category name is too long");
                this.PanelUpdate.Visible = false;
                this.ButtonCreate.Visible = true;
                return;
            }


            int id = Convert.ToInt32(ViewState["categoryId"]);
            Category category = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            category.Name = name;
            context.SaveChanges();
            ErrorSuccessNotifier.AddSuccessMessage("Category modified.");
            this.GridViewCategories.SetPageIndex(this.GridViewCategories.PageIndex);
            this.PanelUpdate.Visible = false;
            this.ButtonCreate.Visible = true;
        }

        protected void ButtonDeleteConfirmation_Command(object sender, CommandEventArgs e)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();
            int id = Convert.ToInt32(e.CommandArgument);
            this.PanelDelete.Visible = true;
            this.ButtonCreate.Visible = false;
            this.TextBoxDeleteCategory.Text = context.Categories.FirstOrDefault(x => x.CategoryId == id).Name;
            ViewState["categoryDeleteId"] = id;
        }


        // todo make it go to the next page if doesnt have more elements
        protected void ButtonDelete_Command(object sender, CommandEventArgs e)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();

            int id = Convert.ToInt32(ViewState["categoryDeleteId"]);
            Category category = context.Categories.FirstOrDefault(x => x.CategoryId == id);
            context.Books.RemoveRange(category.Books);
            context.Categories.Remove(category);
            context.SaveChanges();
            ErrorSuccessNotifier.AddSuccessMessage("Category Deleted.");
            this.GridViewCategories.SetPageIndex(this.GridViewCategories.PageIndex);
            this.GridViewCategories.SetPageIndex(0);
            this.PanelDelete.Visible = false;
            this.ButtonCreate.Visible = true;
        }

        protected void ButtonCalcelDelete_Click(object sender, EventArgs e)
        {
            ErrorSuccessNotifier.AddSuccessMessage("Category wasn't deleted.");
            this.PanelDelete.Visible = false;
            this.ButtonCreate.Visible = true;
        }

        protected void ListViewCategories_Sorting(object sender, ListViewSortEventArgs e)
        {
            
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<LibrarySystem.Models.Category> ListViewCategories_GetData()
        {
            LibrarySystemEntities context = new LibrarySystemEntities();
            return context.Categories;
        }
    }
}