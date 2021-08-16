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
    public class LogCarrera
    {
        private ClassAccesoSQL acceso = new ClassAccesoSQL(@"Data Source=DESKTOP-UJ8LE08; Initial Catalog=Bitacora2021LabsUTP; Integrated Security = true;");

        public List<ECarrera> EnlistarCarreras(ECarrera Consulta, ref string mens)
        {
            List<ECarrera> envCar = new List<ECarrera>();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter
            {
                ParameterName = "Id_Carrera",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Consulta.id_Carrera
            };
            param[1] = new SqlParameter
            {
                ParameterName = "nombreCarrera",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = Consulta.nombreCarrera
            };

            string consulta = @"select * from Carrera where Id_Carrera = @Id_Carrera";
            SqlDataReader atrapa = null;
            atrapa = acceso.ModificaBDunPocoMasSeguraDS(consulta, acceso.AbrirConexion(ref mens), ref mens, param);
            ECarrera devC = null;
            while (atrapa.Read())
            {
                devC = new ECarrera
                {
                    id_Carrera = Convert.ToInt32(atrapa["Id_Carrera"]),
                    nombreCarrera = Convert.ToString(atrapa["nombreCarrera"]),
                };
                envCar.Add(devC);
            }
            return envCar;
        }

        public Boolean Insertar(ECarrera Tempor, ref string mens)
        {
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter
            {
                ParameterName = "Id_Carrera",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Tempor.id_Carrera
            };
            param[1] = new SqlParameter
            {
                ParameterName = "nombreCarrera",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = Tempor.nombreCarrera
            };

            string consulta = "Insert into Carrera values(@nombreCarrera);";

            Boolean Salida = false;

            Salida = acceso.ModificaBDunPocoMasSegura(consulta, acceso.AbrirConexion(ref mens), ref mens, param);

            return Salida;
        }

        public DataTable CarreraLis(ref string mens_salida)
        {
            string query = @"select * from Carrera;";
            DataSet cont = null;
            DataTable TF = null;
            cont = acceso.ConsultaDS(query, acceso.AbrirConexion(ref mens_salida), ref mens_salida);

            if(cont != null)
            {
                TF = cont.Tables[0];
                if(TF.Rows.Count == 0)
                {
                    TF.Rows.Add(TF.NewRow());
                }
            }
            return TF;
        }

        public Boolean EliminCarrera(int id_Carrera, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "id_Carrera",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id_Carrera
            };


            string sentencia = "DELETE FROM Carrera WHERE id_Carrera = @id_Carrera; ";

            Boolean salida = false;

            salida = acceso.ModificaBDunPocoMasSegura(sentencia, acceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public Boolean ActCarrera(ECarrera car, ref string mens_salida)
        {
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter
            {
                ParameterName = "Id_Carrera",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = car.id_Carrera
            };
            param[1] = new SqlParameter
            {
                ParameterName = "nombreCarrera",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = car.nombreCarrera
            };

            string sentencia = @"update Carrera
                                 set nombreCarrea = @nombreCarrera
                                 where id_Carrera = @Id_Carrera;";

            Boolean salida = false;

            salida = acceso.ModificaBDunPocoMasSegura(sentencia, acceso.AbrirConexion(ref mens_salida), ref mens_salida, param);

            return salida;
        }
    }
}
