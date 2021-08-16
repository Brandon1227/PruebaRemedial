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
    public class LogGrupoCuatri
    {
        private ClassAccesoSQL acceso = new ClassAccesoSQL(@"Data Source=DESKTOP-UJ8LE08; Initial Catalog=Bitacora2021LabsUTP; Integrated Security = true;");

        public List<EGrupoCuatrimestre> Listar_Todo(EGrupoCuatrimestre Cons, ref string mens)
        {
            List<EGrupoCuatrimestre> manC = new List<EGrupoCuatrimestre>();
            SqlParameter[] par = new SqlParameter[7];
            par[0] = new SqlParameter
            {
                ParameterName = "id_GruCuat",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Cons.id_GruCuat
            };
            par[1] = new SqlParameter
            {
                ParameterName = "F_ProgEd",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Cons.F_ProgEd
            };
            par[2] = new SqlParameter
            {
                ParameterName = "F_Grupo",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Cons.F_Grupo
            };
            par[3] = new SqlParameter
            {
                ParameterName = "F_Cuatri",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Cons.F_Cuatri
            };
            par[4] = new SqlParameter
            {
                ParameterName = "Turno",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = Cons.Turno
            };
            par[5] = new SqlParameter
            {
                ParameterName = "Modalidad",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = Cons.Modalidad
            };
            par[6] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = Cons.Extra
            };


            string query = @"select * from GrupoCuatrimestre where id_GruCuat = @id_GruCuat";

            SqlDataReader atrapa = null;

            atrapa = acceso.ModificaBDunPocoMasSeguraDS(query, acceso.AbrirConexion(ref mens), ref mens, par);
            EGrupoCuatrimestre devM = null;

            while (atrapa.Read())
            {
                devM = new EGrupoCuatrimestre
                {
                    id_GruCuat = Convert.ToInt32(atrapa["id_GruCuat"]),
                    F_ProgEd = Convert.ToInt32(atrapa["F_ProgEd"]),
                    F_Grupo = Convert.ToInt32(atrapa["F_Grupo"]),
                    F_Cuatri = Convert.ToInt32(atrapa["F_Cuatri"]),
                    Turno = Convert.ToString(atrapa["Turno"]),
                    Modalidad = Convert.ToString(atrapa["Modalidad"]),
                    Extra = Convert.ToString(atrapa["Extra"])
                };
                manC.Add(devM);
            }
            return manC;
        }

        public Boolean Insertar(EGrupoCuatrimestre Tempor, ref string mens)
        {
            SqlParameter[] par = new SqlParameter[7];
            par[0] = new SqlParameter
            {
                ParameterName = "id_GruCuat",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Tempor.id_GruCuat
            };
            par[1] = new SqlParameter
            {
                ParameterName = "F_ProgEd",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Tempor.F_ProgEd
            };
            par[2] = new SqlParameter
            {
                ParameterName = "F_Grupo",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Tempor.F_Grupo
            };
            par[3] = new SqlParameter
            {
                ParameterName = "F_Cuatri",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Tempor.F_Cuatri
            };
            par[4] = new SqlParameter
            {
                ParameterName = "Turno",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = Tempor.Turno
            };
            par[5] = new SqlParameter
            {
                ParameterName = "Modalidad",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = Tempor.Modalidad
            };
            par[6] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = Tempor.Extra
            };

            string consulta = "Insert into GrupoCuatrimestre values(@F_ProgEd, @F_Grupo, @F_Cuatri, @Turno, @Modalidad, @Extra);";

            Boolean Salida = false;

            Salida = acceso.ModificaBDunPocoMasSegura(consulta, acceso.AbrirConexion(ref mens), ref mens, par);

            return Salida;
        }

        public DataTable GrupoCuaLis(ref string mens_salida)
        {
            string query = @"select * from GrupoCuatrimestre;";
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

        public DataTable GruposSalonesLis(ref string mens_salida)
        {
            string query = @"select * from Grupo;";
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

        public Boolean EliminGrupoCuatri(int id_Cuatrimestre, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "id_GruCuat",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id_Cuatrimestre
            };


            string sentencia = "DELETE FROM GrupoCuatrimestre WHERE id_GruCuat = @id_GruCuat; ";

            Boolean salida = false;

            salida = acceso.ModificaBDunPocoMasSegura(sentencia, acceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public Boolean ActGrupoCuatrimestre(EGrupoCuatrimestre car, ref string mens_salida)
        {
            SqlParameter[] par = new SqlParameter[7];
            par[0] = new SqlParameter
            {
                ParameterName = "id_GruCuat",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = car.id_GruCuat
            };
            par[1] = new SqlParameter
            {
                ParameterName = "F_ProgEd",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = car.F_ProgEd
            };
            par[2] = new SqlParameter
            {
                ParameterName = "F_Grupo",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = car.F_Grupo
            };
            par[3] = new SqlParameter
            {
                ParameterName = "F_Cuatri",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = car.F_Cuatri
            };
            par[4] = new SqlParameter
            {
                ParameterName = "Turno",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = car.Turno
            };
            par[5] = new SqlParameter
            {
                ParameterName = "Modalidad",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = car.Modalidad
            };
            par[6] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = car.Extra
            };

            string sentencia = @"update GrupoCuatrimestre
                                 set Turno = @Turno, Modalidad = @Modalidad, Extra = @Extra
                                 where id_Cuatrimestre = @id_Cuatrimestre;";

            Boolean salida = false;

            salida = acceso.ModificaBDunPocoMasSegura(sentencia, acceso.AbrirConexion(ref mens_salida), ref mens_salida, par);

            return salida;
        }
    }
}
