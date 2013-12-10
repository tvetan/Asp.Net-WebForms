using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Error_Handler_Control;
using System.Data.Entity;
namespace LibrarySystem.Library_System
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Preload(object sender, EventArgs e)
        {
            string param = Request.Params["q"];
            if (param.Length > 150)
            {
                ErrorSuccessNotifier.AddErrorMessage("The provided param is too big");
                return;
            }
            this.LiteralQuery.Text = param;
        }

        public IQueryable<Book> RepeaterResults_GetData()
        {
            string param = Request.Params["q"];
            LibrarySystemEntities context = new LibrarySystemEntities();
            var result = context.Books.Include(x => x.Category).Where(x => x.Title.Contains(param) || x.Author.Contains(param));
            return result.OrderBy(x => x.Title).ThenBy(x => x.Author);

        }
    }
}