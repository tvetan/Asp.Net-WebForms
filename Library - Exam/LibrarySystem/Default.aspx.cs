using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class _Default : Page
    {
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

        public IList<Book> GetDataSourse(int id)
        {
            List<Book> list = new List<Book>();
            LibrarySystemEntities context = new LibrarySystemEntities();
            list = context.Books.Where(x => x.CategoryId == id).ToList();

            return list;
        }

        protected void ButtonSearch_Command(object sender, CommandEventArgs e)
        {
            string param = this.TextBoxSearchParam.Text;
            Response.Redirect("~/Library-System/Search?q=" + param);
        }
    }
}