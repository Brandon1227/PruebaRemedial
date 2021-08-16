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
    public partial class Cuatrimestre : System.Web.UI.Page
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

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string m = "";
            ECuatrimestre ICua = new ECuatrimestre
            {
                id_Cuatrimestre = 0,
                Periodo = txtPeriodo.Text,
                Anio = Convert.ToInt32(txtAnio.Text),
                Inicio = Convert.ToDateTime(txtInicio.Text),
                Fin = Convert.ToDateTime(txtFin.Text),
                Extra = txtExtra.Text
            };
            try
            {
                Cuat.Insertar(ICua, ref m);
                lbResp.Visible = true;
                lbResp.Text = "Inserción correcta.";
                CargarGV();
            }
            catch(Exception EX)
            {
                lbResp.Text = EX.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string men = "";
            int ID = Convert.ToInt32(txtElimina.Text);
            if (txtElimina.Text != null)
            {
                Cuat.EliminCuatri(ID, ref men);
                CargarGV();
            }
            else
            {
                lbResp.Text = "No hay que eliminar.";
            }
        }

        protected void CargarGV()
        {
            string m = "";
            GridView1.DataSource = Cuat.CuatriLis(ref m);
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow recolec = null;
            recolec = GridView1.SelectedRow;
            int id = Convert.ToInt32(recolec.Cells[1].Text);

            txtElimina.Text = id.ToString();
            txtActID.Text = id.ToString();
            txtActPeriodo.Text = recolec.Cells[2].Text;
            txtAnio.Text = recolec.Cells[3].Text;
            txtActInicio.Text = recolec.Cells[4].Text;
            txtActFin.Text = recolec.Cells[5].Text;
            txtActExtra.Text = recolec.Cells[6].Text;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string m = "";
            ECuatrimestre Actualiza = new ECuatrimestre
            {
                id_Cuatrimestre = Convert.ToInt32(txtActID.Text),
                Periodo = txtActPeriodo.Text,
                Anio = Convert.ToInt32(txtActAño.Text),
                Inicio = Convert.ToDateTime(txtActInicio.Text),
                Fin = Convert.ToDateTime(txtActFin.Text),
                Extra = txtActExtra.Text
            };
            Boolean ActB = Cuat.ActCuatrimestre(Actualiza, ref m);

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
    }
}