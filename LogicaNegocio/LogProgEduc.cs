using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using EntidadesBD;
using ClassConexion;

namespace LogicaNegocio
{
    public class LogProgEduc
    {
        private ClassAccesoSQL acceso = new ClassAccesoSQL(@"Data Source=DESKTOP-UJ8LE08; Initial Catalog=Bitacora2021LabsUTP; Integrated Security = true;");

        public List<EProgramaEducativo> Listar_Todo(EProgramaEducativo Cons, ref string mens)
        {
            List<EProgramaEducativo> manC = new List<EProgramaEducativo>();
            SqlParameter[] par = new SqlParameter[4];
            par[0] = new SqlParameter
            {
                ParameterName = "Id_pe",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Cons.Id_pe
            };
            par[1] = new SqlParameter
            {
                ParameterName = "ProgramaEd",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = Cons.ProgramaEd
            };
            par[2] = new SqlParameter
            {
                ParameterName = "F_Carrera",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Cons.F_Carrera
            };
            par[3] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = Cons.Extra
            };

            string query = @"select * from ProgramaEducativo where Id_pe = @Id_pe";

            SqlDataReader atrapa = null;

            atrapa = acceso.ModificaBDunPocoMasSeguraDS(query, acceso.AbrirConexion(ref mens), ref mens, par);
            EProgramaEducativo devM = null;

            while (atrapa.Read())
            {
                devM = new EProgramaEducativo
                {
                    Id_pe = Convert.ToInt32(atrapa["Id_pe"]),
                    ProgramaEd = Convert.ToString(atrapa["ProgramaEd"]),
                    F_Carrera = Convert.ToInt32(atrapa["F_Carrera"]),
                    Extra = Convert.ToString(atrapa["Extra"])
                };
                manC.Add(devM);
            }
            return manC;
        }

        public Boolean Insertar(EProgramaEducativo Tempor, ref string mens)
        {
            SqlParameter[] par = new SqlParameter[4];
            par[0] = new SqlParameter
            {
                ParameterName = "Id_pe",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Tempor.Id_pe
            };
            par[1] = new SqlParameter
            {
                ParameterName = "ProgramaEd",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = Tempor.ProgramaEd
            };
            par[2] = new SqlParameter
            {
                ParameterName = "F_Carrera",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Tempor.F_Carrera
            };
            par[3] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = Tempor.Extra
            };

            string consulta = "Insert into ProgramaEducativo values(@Periodo, @Anio, @Inicio, @Fin, @Extra);";

            Boolean Salida = false;

            Salida = acceso.ModificaBDunPocoMasSegura(consulta, acceso.AbrirConexion(ref mens), ref mens, par);

            return Salida;
        }

        public DataTable ProgEduLis(ref string mens_salida)
        {
            string query = @"select * from ProgramaEducativo;";
            DataSet cont = null;
            DataTable TF = null;
            cont = acceso.ConsultaDS(query, acceso.AbrirConexion(ref mens_salida), ref mens_salida);

            if (cont != null)
            {
                TF = cont.Tables[0];
                if (TF.Rows.Count == 0)
                {
                    TF.Rows.Add(TF.NewRow());
                }
            }
            return TF;
        }

        public Boolean EliminProgEdu(int Id_pe, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "Id_pe",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Id_pe
            };

            string sentencia = "DELETE FROM ProgramaEducativo WHERE Id_pe = @Id_pe; ";

            Boolean salida = false;

            salida = acceso.ModificaBDunPocoMasSegura(sentencia, acceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public Boolean ActCuatrimestre(EProgramaEducativo car, ref string mens_salida)
        {
            SqlParameter[] par = new SqlParameter[4];
            par[0] = new SqlParameter
            {
                ParameterName = "Id_pe",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = car.Id_pe
            };
            par[1] = new SqlParameter
            {
                ParameterName = "ProgramaEd",
                SqlDbType = SqlDbType.VarChar,
                Size = 150,
                Direction = ParameterDirection.Input,
                Value = car.ProgramaEd
            };
            par[2] = new SqlParameter
            {
                ParameterName = "F_Carrera",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = car.F_Carrera
            };
            par[3] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = car.Extra
            };

            string sentencia = @"update ProgramaEducativo
                                 set ProgramaEd = @ProgramaEd, Extra = @Extra
                                 where Id_pe = @Id_pe;";

            Boolean salida = false;

            salida = acceso.ModificaBDunPocoMasSegura(sentencia, acceso.AbrirConexion(ref mens_salida), ref mens_salida, par);

            return salida;
        }
    }
}
