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
    public partial class Carrera : System.Web.UI.Page
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

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            string m = "";
            ECarrera ICar = new ECarrera
            {
                id_Carrera = 0,
                nombreCarrera = txtInsert.Text
            };
            try
            {
                Car.Insertar(ICar, ref m);
                lbResp.Visible = true;
                lbResp.Text = "Inserción correcta.";
                CargarGV();
            }
            catch(Exception ex)
            {
                lbResp.Text = ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string men = "";
            int ID = Convert.ToInt32(txtEliminar.Text);
            if (txtEliminar.Text != null)
            {
                Car.EliminCarrera(ID, ref men);
                lbResp.Text = "Eliminación Exitosa.";
                lbResp.Visible = true;
                CargarGV();
            }
            else
            {
                lbResp.Text = "No hay que eliminar.";
                lbResp.Visible = true;
            }
        }

        protected void CargarGV()
        {
            string m = "";
            GridView1.DataSource = Car.CarreraLis(ref m);
            GridView1.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow recolec = null;
            recolec = GridView1.SelectedRow;
            int id = Convert.ToInt32(recolec.Cells[1].Text);

            txtEliminar.Text = id.ToString();
            txtIdAct.Text = id.ToString();
            txtActCarr.Text = recolec.Cells[2].Text;
        }

        protected void btnActualiza_Click(object sender, EventArgs e)
        {
            string m = "";
            ECarrera Actualiza = new ECarrera
            {
                id_Carrera = Convert.ToInt32(txtIdAct.Text),
                nombreCarrera = txtActCarr.Text
            };
            Boolean ActB = Car.ActCarrera(Actualiza, ref m);

            if(ActB != false)
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