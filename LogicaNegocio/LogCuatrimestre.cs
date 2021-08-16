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
    public class LogCuatrimestre
    {
        private ClassAccesoSQL acceso = new ClassAccesoSQL(@"Data Source=DESKTOP-UJ8LE08; Initial Catalog=Bitacora2021LabsUTP; Integrated Security = true;");

        public List<ECuatrimestre> Listar_Todo(ECuatrimestre Cons, ref string mens)
        {
            List<ECuatrimestre> manC = new List<ECuatrimestre>();
            SqlParameter[] par = new SqlParameter[6];
            par[0] = new SqlParameter
            {
                ParameterName = "Id_Cuatrimestre",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Cons.id_Cuatrimestre
            };
            par[1] = new SqlParameter
            {
                ParameterName = "Periodo",
                SqlDbType = SqlDbType.VarChar,
                Size = 30,
                Direction = ParameterDirection.Input,
                Value = Cons.Periodo
            };
            par[2] = new SqlParameter
            {
                ParameterName = "Anio",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Cons.Anio
            };
            par[3] = new SqlParameter
            {
                ParameterName = "Inicio",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = Cons.Inicio
            };
            par[4] = new SqlParameter
            {
                ParameterName = "Fin",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = Cons.Fin
            };
            par[5] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = Cons.Extra
            };

            string query = @"select * from Cuatrimestre where Id_Cuatrimestre = @Id_Cuatrimestre";

            SqlDataReader atrapa = null;

            atrapa = acceso.ModificaBDunPocoMasSeguraDS(query, acceso.AbrirConexion(ref mens), ref mens, par);
            ECuatrimestre devM = null;

            while (atrapa.Read())
            {
                devM = new ECuatrimestre
                {
                    id_Cuatrimestre = Convert.ToInt32(atrapa["id_Cuatrimestre"]),
                    Periodo = Convert.ToString(atrapa["Periodo"]),
                    Anio = Convert.ToInt32(atrapa["Anio"]),
                    Inicio = Convert.ToDateTime(atrapa["Inicio"]),
                    Fin = Convert.ToDateTime(atrapa["Fin"]),
                    Extra = Convert.ToString(atrapa["Extra"])
                };
                manC.Add(devM);
            }
            return manC;
        }

        public Boolean Insertar(ECuatrimestre Tempor, ref string mens)
        {
            SqlParameter[] par = new SqlParameter[6];
            par[0] = new SqlParameter
            {
                ParameterName = "Id_Cuatrimestre",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Tempor.id_Cuatrimestre
            };
            par[1] = new SqlParameter
            {
                ParameterName = "Periodo",
                SqlDbType = SqlDbType.VarChar,
                Size = 30,
                Direction = ParameterDirection.Input,
                Value = Tempor.Periodo
            };
            par[2] = new SqlParameter
            {
                ParameterName = "Anio",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Tempor.Anio
            };
            par[3] = new SqlParameter
            {
                ParameterName = "Inicio",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = Tempor.Inicio
            };
            par[4] = new SqlParameter
            {
                ParameterName = "Fin",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = Tempor.Fin
            };
            par[5] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = Tempor.Extra
            };

            string consulta = "Insert into Cuatrimestre values(@Periodo, @Anio, @Inicio, @Fin, @Extra);";

            Boolean Salida = false;

            Salida = acceso.ModificaBDunPocoMasSegura(consulta, acceso.AbrirConexion(ref mens), ref mens, par);

            return Salida;
        }

        public DataTable CuatriLis(ref string mens_salida)
        {
            string query = @"select * from Cuatrimestre;";
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

        public Boolean EliminCuatri(int id_Cuatrimestre, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "id_Cuatrimestre",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id_Cuatrimestre
            };


            string sentencia = "DELETE FROM Cuatrimestre WHERE id_Cuatrimestre = @id_Cuatrimestre; ";

            Boolean salida = false;

            salida = acceso.ModificaBDunPocoMasSegura(sentencia, acceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public Boolean ActCuatrimestre(ECuatrimestre car, ref string mens_salida)
        {
            SqlParameter[] par = new SqlParameter[6];
            par[0] = new SqlParameter
            {
                ParameterName = "Id_Cuatrimestre",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = car.id_Cuatrimestre
            };
            par[1] = new SqlParameter
            {
                ParameterName = "Periodo",
                SqlDbType = SqlDbType.VarChar,
                Size = 30,
                Direction = ParameterDirection.Input,
                Value = car.Periodo
            };
            par[2] = new SqlParameter
            {
                ParameterName = "Anio",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = car.Anio
            };
            par[3] = new SqlParameter
            {
                ParameterName = "Inicio",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = car.Inicio
            };
            par[4] = new SqlParameter
            {
                ParameterName = "Fin",
                SqlDbType = SqlDbType.Date,
                Direction = ParameterDirection.Input,
                Value = car.Fin
            };
            par[5] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = car.Extra
            };

            string sentencia = @"update Cuatrimestre
                                 set Periodo = @Periodo, Anio = @Anio, Inicio = @Inicio, Fin = @Fin, Extra = @Extra
                                 where id_Cuatrimestre = @id_Cuatrimestre;";

            Boolean salida = false;

            salida = acceso.ModificaBDunPocoMasSegura(sentencia, acceso.AbrirConexion(ref mens_salida), ref mens_salida, par);

            return salida;
        }
    }
}
