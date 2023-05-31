using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD.Pages
{
    public partial class CRUD : System.Web.UI.Page
    {
        private readonly SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string sID = "-1";
        public static string sOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Obtener el Id
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"]!=null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                    tbDate.TextMode = TextBoxMode.DateTime;
                }

                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();
                    switch (sOpc)
                    {
                        case "C":
                            this.lblTitulo.Text = "Ingresar nuevo Usuario";
                            this.btnCreate.Visible = true;
                            break;
                        case "R":
                            this.lblTitulo.Text = "Consulta de Usuario";
                            break;
                        case "U":
                            this.lblTitulo.Text = "Modificar Usuario";
                            this.btnUpdate.Visible = true;
                            break;
                        case "D":
                            this.lblTitulo.Text = "Eliminar Usuario";
                            this.btnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        void CargarDatos()
        {
            _connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_read", _connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            tbNombre.Text = row[1].ToString();
            tbEdad.Text = row[2].ToString();
            tbEmail.Text = row[3].ToString();
            DateTime d = (DateTime)row[4];
            tbDate.Text = d.ToString("dd/MM/yyyy");
            _connection.Close();
        }

        protected void BtnCreateClick(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_create", _connection);
            _connection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbNombre.Text;
            cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = tbEdad.Text;
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = tbEmail.Text;
            cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = tbDate.Text;
            cmd.ExecuteNonQuery();
            _connection.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnUpdateClick(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_update", _connection);
            _connection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tbNombre.Text;
            cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = tbEdad.Text;
            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = tbEmail.Text;
            cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = tbDate.Text;
            cmd.ExecuteNonQuery();
            _connection.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnDeleteClick(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_delete", _connection);
            _connection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = sID;
            cmd.ExecuteNonQuery();
            _connection.Close();
            Response.Redirect("Index.aspx");
        }

        protected void BtnVolverClick(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}