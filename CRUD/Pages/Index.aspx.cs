using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace CRUD.Pages
{
    public partial class Index : System.Web.UI.Page
    {
        private readonly SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTable();
        }

        void CargarTable()
        {
            SqlCommand cmd = new SqlCommand("sp_load", _connection);
            cmd.CommandType = CommandType.StoredProcedure;
            _connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            gvUsuarios.DataSource = dt;
            gvUsuarios.DataBind();
            _connection.Close();
        }

        protected void BtnCreateClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/CRUD.aspx?op=C");
        }

        protected void BtnReadClick(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedRow.Cells[1].Text;
            Response.Redirect($"~/Pages/CRUD.aspx?id={id}&op=R");
        }

        protected void BtnUpdateClick(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedRow.Cells[1].Text;
            Response.Redirect($"~/Pages/CRUD.aspx?id={id}&op=U");
        }
        protected void BtnDeleteClick(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedRow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedRow.Cells[1].Text;
            Response.Redirect($"~/Pages/CRUD.aspx?id={id}&op=D");
        }
    }
}