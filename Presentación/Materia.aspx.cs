using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LogicaNegocio;
using EntidadesBD;

namespace Presentación
{
    public partial class Materia : System.Web.UI.Page
    {
        LogCarrera Car = null;
        LogCuatrimestre Cuat = null;
        LogGrupoCuatri Grup = null;
        LogMateria Mat = null;
        LogProgEduc Prog = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbResp.Visible = false;
            if (IsPostBack == false)
            {
                Car = new LogCarrera();
                Cuat = new LogCuatrimestre();
                Grup = new LogGrupoCuatri();
                Mat = new LogMateria();
                Prog = new LogProgEduc();

                Session["Car"] = Car;
                Session["Cuat"] = Cuat;
                Session["Grup"] = Grup;
                Session["Mat"] = Mat;
                Session["Prog"] = Prog;
            }
            else
            {
                Car = (LogCarrera)Session["Car"];
                Cuat = (LogCuatrimestre)Session["Cuat"];
                Grup = (LogGrupoCuatri)Session["Grup"];
                Mat = (LogMateria)Session["Mat"];
                Prog = (LogProgEduc)Session["Prog"];
            }
            CargarGV();
        }

        protected void btnActuliza_Click(object sender, EventArgs e)
        {
            string m = "";
            EMateria Actualiza = new EMateria
            {
                Id_Materia = Convert.ToInt32(TextBox2.Text),
                NombreMateria = TextBox3.Text,
                HorasSemana = Convert.ToInt32(TextBox4.Text),
                Extra = TextBox5.Text
            };
            Boolean ActB = Mat.ActMateria(Actualiza, ref m);

            if (ActB != false)
            {
                CargarGV();
            }
            else
            {
                lbResp.Visible = true;
                lbResp.Text = "No se actualizo.";
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string m = "";
            EMateria IMat = new EMateria
            {
                Id_Materia = 0,
                NombreMateria = txtMateria.Text,
                HorasSemana = Convert.ToInt32(txtHoras.Text),
                Extra = txtExtra.Text
            };
            try
            {
                Mat.Insertar(IMat, ref m);
                lbResp.Visible = true;
                lbResp.Text = "Inserción correcta.";
                CargarGV();
            }
            catch(Exception ex)
            {
                lbResp.Visible = true;
                lbResp.Text = ex.Message;
            }
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            string men = "";
            int ID = Convert.ToInt32(txtEliminar.Text);
            if (txtEliminar.Text != null)
            {
                Mat.EliminMateria(ID, ref men);
                lbResp.Visible = true;
                lbResp.Text = "Eliminacion Exitosa.";
                CargarGV();
            }
            else
            {
                lbResp.Visible = true;
                lbResp.Text = "No hay que eliminar.";
            }
        }

        protected void CargarGV()
        {
            string m = "";
            GridView1.DataSource = Mat.MateriaLis(ref m);
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow recolec = null;
            recolec = GridView1.SelectedRow;
            int id = Convert.ToInt32(recolec.Cells[1].Text);

            txtEliminar.Text = id.ToString();
            TextBox2.Text = id.ToString();
            TextBox3.Text = recolec.Cells[2].Text;
            TextBox4.Text = recolec.Cells[3].Text;
            TextBox5.Text = recolec.Cells[4].Text;
        }
    }
}