using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Clientes_NV
{
    public partial class frm_clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                limpiar_controles();
                consultar_datos();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            limpiar_controles();
        }

        public void limpiar_controles()
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox3.Text = string.Empty;
            Calendar1.SelectedDate = DateTime.Now;
            DropDownList1.SelectedValue = "1";
            Button1.Text = "Grabar";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet result = new DataSet();
                SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=db_clientes;User ID=sa;Password=desa*P2022");
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("STP_CLIENTES",conn);
                da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                da.SelectCommand.Parameters.Add("@tipo",System.Data.SqlDbType.Int).Value = 2;
                da.SelectCommand.Parameters.Add("@identificacion", System.Data.SqlDbType.VarChar, 50).Value = TextBox1.Text.ToString();
                da.SelectCommand.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 50).Value = TextBox2.Text.ToString();
                da.SelectCommand.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar, 50).Value = TextBox3.Text.ToString();
                da.SelectCommand.Parameters.Add("@fecha_nacimiento", System.Data.SqlDbType.Date).Value = Calendar1.SelectedDate.ToShortDateString();
                da.SelectCommand.Parameters.Add("@estado", System.Data.SqlDbType.Bit).Value = DropDownList1.SelectedValue;

                da.Fill(result);

                consultar_datos();

                conn.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());               
            }
        }

        public void consultar_datos()
        {
            try
            {
                DataSet result = new DataSet();
                SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=db_clientes;User ID=sa;Password=desa*P2022");
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("STP_CLIENTES", conn);
                da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

                da.SelectCommand.Parameters.Add("@tipo", System.Data.SqlDbType.Int).Value = 1;


                da.Fill(result);

                if (result.Tables.Count > 0 )
                {
                    GridView1.DataSource = result.Tables[0];
                    GridView1.DataBind();
                }



                conn.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }

    }
}