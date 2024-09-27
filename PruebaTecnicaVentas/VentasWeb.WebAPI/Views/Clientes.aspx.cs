using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace VentasWeb.WebAPI.Views
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void ReloadBtn_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_DataBinding(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this,
                                    GetType(),
                                     "key",
                                     "runScript(hideSpinner);",
                                     true);

        }
    }
}