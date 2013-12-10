using Error_Handler_Control;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace LibrarySystem.Admin
{
    public partial class EditBooks : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();
            this.BookDropDownCreate.DataSource = context.Categories.ToList();
            this.BookDropDownCreate.DataBind();

            this.DropDownListUpdateCategory.DataSource = context.Categories.ToList();
            this.DropDownListUpdateCategory.DataBind();
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            this.PanelCreate.Visible = true;
            this.ButtonCreate.Visible = false;
            this.PanelDelete.Visible = false;
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.PanelCreate.Visible = false;
            this.ButtonCreate.Visible = true;
            this.PanelUpdate.Visible = false;
        }

        //here
        protected void ButtonCreateBook_Click(object sender, EventArgs e)
        {
            string title = this.TextBoxTitleCreate.Text;
            string author = this.TextBoxAuthorCreate.Text;
            string isbn = this.TextBoxISBNCreate.Text;
            string description = this.TextBoxDescriptionCreate.Text;
            string website = this.TextBoxWebSiteCreate.Text;
            int categoryId = Convert.ToInt32(this.BookDropDownCreate.SelectedItem.Value);

            if (string.IsNullOrEmpty(title))
            {
                ErrorSuccessNotifier.AddErrorMessage("Book title cannot be empty.");
                this.PanelCreate.Visible = false;
                this.ButtonCreate.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(author))
            {
                ErrorSuccessNotifier.AddErrorMessage("Book author cannot be empty.");
                this.PanelCreate.Visible = false;
                this.ButtonCreate.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(isbn))
            {
                ErrorSuccessNotifier.AddErrorMessage("Book isbn cannot be empty.");
                this.PanelCreate.Visible = false;
                this.ButtonCreate.Visible = true;
                return;
            }

            LibrarySystemEntities context = new LibrarySystemEntities();
            Book book = new Book()
            {
                Title = title,
                Author = author,
                ISBN = isbn,
                Description = description,
                CategoryId = categoryId,
                Web_Site = website
            };

            context.Books.Add(book);
            context.SaveChanges();

            //ErrorSuccessNotifier.AddSuccessMessage("Category created.");
            this.GridViewBooks.SetPageIndex(this.GridViewBooks.PageIndex);
            this.PanelCreate.Visible = false;
            this.ButtonCreate.Visible = true;
        }

        protected void ButtonCancelEdit_Click(object sender, EventArgs e)
        {
            this.PanelUpdate.Visible = false;
            this.ButtonCreate.Visible = true;
        }

        protected void ButtonEditBook_Command(object sender, CommandEventArgs e)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();
            int id = Convert.ToInt32(e.CommandArgument);
            this.PanelUpdate.Visible = true;
            this.ButtonCreate.Visible = false;
            this.PanelDelete.Visible = false;
            this.TextBoxUpdateTitle.Text = context.Books.FirstOrDefault(x => x.BookId == id).Title;
            this.TextBoxUpdateAuthor.Text = context.Books.FirstOrDefault(x => x.BookId == id).Author;
            this.TextBoxUpdateISBN.Text = context.Books.FirstOrDefault(x => x.BookId == id).ISBN;
            this.TextBoxUpdateWebSite.Text = context.Books.FirstOrDefault(x => x.BookId == id).Web_Site;
            this.TextBoxUpdateDescription.Text = context.Books.FirstOrDefault(x => x.BookId == id).Description;
            this.DropDownListUpdateCategory.SelectedValue = context.Books.FirstOrDefault(x => x.BookId == id).CategoryId.ToString();
            ViewState["bookId"] = id;
        }
  
        protected void ButtonUpdate_Command(object sender, CommandEventArgs e)
        {
            string title = this.TextBoxUpdateTitle.Text;
            string author = this.TextBoxUpdateAuthor.Text;
            string isbn = this.TextBoxUpdateISBN.Text;
            string description = this.TextBoxUpdateDescription.Text;
            string website = this.TextBoxUpdateWebSite.Text;
            int categoryId = Convert.ToInt32(this.DropDownListUpdateCategory.SelectedItem.Value);

            if (string.IsNullOrEmpty(title))
            {
                ErrorSuccessNotifier.AddErrorMessage("Book title cannot be empty.");
                this.PanelCreate.Visible = false;
                this.ButtonCreate.Visible = true;
                return;
            }

            if (title.Length > 150)
            {
                ErrorSuccessNotifier.AddErrorMessage("Book title too long");
                this.PanelCreate.Visible = false;
                this.ButtonCreate.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(author))
            {
                ErrorSuccessNotifier.AddErrorMessage("Book author cannot be empty.");
                this.PanelCreate.Visible = false;
                this.ButtonCreate.Visible = true;
                return;
            }

            if (author.Length > 150)
            {
                ErrorSuccessNotifier.AddErrorMessage("Book author too long");
                this.PanelCreate.Visible = false;
                this.ButtonCreate.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(isbn))
            {
                ErrorSuccessNotifier.AddErrorMessage("Book isbn cannot be empty.");
                this.PanelCreate.Visible = false;
                this.ButtonCreate.Visible = true;
                return;
            }

            if (isbn.Length > 150)
            {
                ErrorSuccessNotifier.AddErrorMessage("Book isbn too long");
                this.PanelCreate.Visible = false;
                this.ButtonCreate.Visible = true;
                return;
            }

            if (website.Length > 150)
            {
                ErrorSuccessNotifier.AddErrorMessage("Book web site too long");
                this.PanelCreate.Visible = false;
                this.ButtonCreate.Visible = true;
                return;
            }
            LibrarySystemEntities context = new LibrarySystemEntities();
            int id = Convert.ToInt32(ViewState["bookId"]);
            Book book = context.Books.FirstOrDefault(x => x.BookId == id);

            book.Title = title;
            book.Author = author;
            book.ISBN = isbn;
            book.Description = description;
            book.CategoryId = categoryId;
            book.Web_Site = website;

            context.SaveChanges();
            this.GridViewBooks.SetPageIndex(this.GridViewBooks.PageIndex);
            ErrorSuccessNotifier.AddSuccessMessage("Book modified.");
            this.PanelCreate.Visible = false;
            this.PanelUpdate.Visible = false;
            this.ButtonCreate.Visible = true;
            this.PanelDelete.Visible = false;
        }

        protected void ButtonDeleteConfirmation_Command(object sender, CommandEventArgs e)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();
            int id = Convert.ToInt32(e.CommandArgument);
            this.PanelDelete.Visible = true;
            this.ButtonCreate.Visible = false;
            this.PanelCreate.Visible = false;
            this.PanelUpdate.Visible = false;

            this.TextBoxDeleteBook.Text = context.Books.FirstOrDefault(x => x.BookId == id).Title;
            ViewState["bookDeleteId"] = id;
        }


        protected void ButtonDelete_Command(object sender, CommandEventArgs e)
        {
            LibrarySystemEntities context = new LibrarySystemEntities();

            int id = Convert.ToInt32(ViewState["bookDeleteId"]);
            Book book = context.Books.FirstOrDefault(x => x.BookId == id);
            context.Books.Remove(book);
            context.SaveChanges();
            ErrorSuccessNotifier.AddSuccessMessage("Book Deleted.");
            this.GridViewBooks.SetPageIndex(this.GridViewBooks.PageIndex);



            this.GridViewBooks.SetPageIndex(0);
            this.PanelDelete.Visible = false;
            this.ButtonCreate.Visible = true;
        }

        protected void ButtonCalcelDelete_Click(object sender, EventArgs e)
        {
            ErrorSuccessNotifier.AddSuccessMessage("Book wasn't deleted.");
            this.PanelDelete.Visible = false;
            this.ButtonCreate.Visible = true;
        }

        public IQueryable<LibrarySystem.Models.Book> GridViewBooks_GetData()
        {
            LibrarySystemEntities context = new LibrarySystemEntities();
            return context.Books.OrderBy(x => x.Title);
        }


        public string Cut(string param)
        {
            if (param == null)
            {
                return param;
            }
            if (param.Length <= 20)
            {
                return param;
            }

            return param.Substring(0, 20) + "...";
        }
     
    }
}