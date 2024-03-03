using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica22
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClsDaoLibros ObjLibros = new ClsDaoLibros();
            DataTable datos = ObjLibros.CargarDatosGridView();
            GridView1.DataSource = datos;
            GridView1.DataBind();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAdd.aspx");
        }
    }
}