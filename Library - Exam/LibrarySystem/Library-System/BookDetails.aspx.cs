using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem.Library_System
{
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            int id = int.Parse(Request.Params["id"]);
            LibrarySystem.Models.LibrarySystemEntities context = new Models.LibrarySystemEntities();
            this.FormViewBook.DataSource = context.Books.Where(x => x.BookId == id).ToList();
            this.FormViewBook.DataBind();
        }
    }
}