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

    public partial class Grupo_Cuatrimestre : System.Web.UI.Page
    {
        LogCarrera Car = null;
        LogCuatrimestre Cuat = null;
        LogGrupoCuatri Grup = null;
        LogMateria Mat = null;
        LogProgEduc Prog = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                lbResp.Visible = false;
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
            CargarGV_Salon();
            CargarGV_PE();
            CargarGV_Cuatri();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string m = "";
            EGrupoCuatrimestre IGrup = new EGrupoCuatrimestre
            {
                id_GruCuat = 0,
                F_ProgEd = Convert.ToInt32(txtProg.Text),
                F_Grupo = Convert.ToInt32(txtGrupo.Text),
                F_Cuatri = Convert.ToInt32(txtCuatri.Text),
                Turno = txtTurno.Text,
                Modalidad = txtModalidad.Text,
                Extra = txtExtra.Text
            };
            try
            {
                Grup.Insertar(IGrup, ref m);
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
                Grup.EliminGrupoCuatri(ID, ref men);
                lbResp.Visible = true;
                lbResp.Text = "Eliminación Exitosa.";
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
            GridView1.DataSource = Grup.GrupoCuaLis(ref m);
            GridView1.DataBind();
        }

        protected void CargarGV_Salon()
        {
            string m = "";
            GridView2.DataSource = Grup.GruposSalonesLis(ref m);
            GridView2.DataBind();
        }

        protected void CargarGV_PE()
        {
            string m = "";
            GridView3.DataSource = Prog.ProgEduLis(ref m);
            GridView3.DataBind();
        }

        protected void CargarGV_Cuatri()
        {
            string m = "";
            GridView4.DataSource = Cuat.CuatriLis(ref m);
            GridView4.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow recolec = null;
            recolec = GridView1.SelectedRow;
            int id = Convert.ToInt32(recolec.Cells[1].Text);

            txtElimina.Text = id.ToString();
            txtActID.Text = id.ToString();
            txtActTurno.Text = recolec.Cells[5].Text;
            txtActModalidad.Text = recolec.Cells[6].Text;
            txtExtra.Text = recolec.Cells[7].Text;
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow recolec = null;
            recolec = GridView2.SelectedRow;
            int id = Convert.ToInt32(recolec.Cells[1].Text);

            txtGrupo.Text = id.ToString();
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow recolec = null;
            recolec = GridView3.SelectedRow;
            int id = Convert.ToInt32(recolec.Cells[1].Text);

            txtProg.Text = id.ToString();
        }

        protected void GridView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string m = "";
            GridViewRow recolec = null;
            recolec = GridView4.SelectedRow;
            int id = Convert.ToInt32(recolec.Cells[1].Text);

            txtCuatri.Text = id.ToString();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            string m = "";
            EGrupoCuatrimestre Actualiza = new EGrupoCuatrimestre
            {
                id_GruCuat = Convert.ToInt32(txtActID.Text),
                F_ProgEd = Convert.ToInt32(txtProg.Text),
                F_Grupo = Convert.ToInt32(txtGrupo.Text),
                F_Cuatri = Convert.ToInt32(txtCuatri.Text),
                Turno = txtActTurno.Text,
                Modalidad = txtActModalidad.Text,
                Extra = txtActExtra.Text
            };
            Boolean ActB = Grup.ActGrupoCuatrimestre(Actualiza, ref m);

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