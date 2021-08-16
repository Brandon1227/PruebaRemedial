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
    public partial class Programa_Educativo : System.Web.UI.Page
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
            CargarGV_Carrera();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string m = "";
            EProgramaEducativo ProEdu = new EProgramaEducativo
            {
                Id_pe = 0,
                ProgramaEd = txtProgra.Text,
                F_Carrera = Convert.ToInt32(txtCarrera.Text),
                Extra = txtExtra.Text
            };
            try
            {
                Prog.Insertar(ProEdu, ref m);
                lbResp.Visible = true;
                lbResp.Text = "Inserción correcta.";
                CargarGV();
            }
            catch(Exception ex)
            {
                lbResp.Text = ex.Message;
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string men = "";
            int ID = Convert.ToInt32(txtEliminar.Text);
            if(txtEliminar.Text != null)
            {
                Prog.EliminProgEdu(ID, ref men);
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
            GridView1.DataSource = Prog.ProgEduLis(ref m);
            GridView1.DataBind();
        }

        protected void CargarGV_Carrera()
        {
            string m = "";
            GridView2.DataSource = Car.CarreraLis(ref m);
            GridView2.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow recolec = null;
            recolec = GridView1.SelectedRow;
            int id = Convert.ToInt32(recolec.Cells[1].Text);

            txtEliminar.Text = id.ToString();
            txtActID.Text = id.ToString();
            txtActProg.Text = recolec.Cells[2].Text;
            txtActExtra.Text = recolec.Cells[4].Text;
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow recolec = null;
            recolec = GridView2.SelectedRow;
            int id = Convert.ToInt32(recolec.Cells[1].Text);

            txtCarrera.Text = id.ToString();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string m = "";
            EProgramaEducativo ProEdu = new EProgramaEducativo
            {
                Id_pe = Convert.ToInt32(txtActID.Text),
                ProgramaEd = txtActProg.Text,
                F_Carrera = Convert.ToInt32(txtCarrera.Text),
                Extra = txtActExtra.Text
            };
            Boolean ActB = Prog.ActCuatrimestre(ProEdu, ref m);

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