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
    public class LogMateria
    {
        private ClassAccesoSQL acceso = new ClassAccesoSQL(@"Data Source=DESKTOP-UJ8LE08; Initial Catalog=Bitacora2021LabsUTP; Integrated Security = true;");

        public List<EMateria> Listar_Todo(EMateria Cons, ref string mens)
        {
            List<EMateria> manC = new List<EMateria>();
            SqlParameter[] par = new SqlParameter[4];
            par[0] = new SqlParameter
            {
                ParameterName = "Id_Materia",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Cons.Id_Materia
            };
            par[1] = new SqlParameter
            {
                ParameterName = "NombreMateria",
                SqlDbType = SqlDbType.VarChar,
                Size = 120,
                Direction = ParameterDirection.Input,
                Value = Cons.NombreMateria
            };
            par[2] = new SqlParameter
            {
                ParameterName = "HorasSemena",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Cons.HorasSemana
            };
            par[3] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = Cons.Id_Materia
            };

            string query = @"select * from Materia where Id_Materia = @Id_Materia";

            SqlDataReader atrapa = null;

            atrapa = acceso.ModificaBDunPocoMasSeguraDS(query, acceso.AbrirConexion(ref mens), ref mens, par);
            EMateria devM = null;

            while (atrapa.Read())
            {
                devM = new EMateria
                {
                    Id_Materia = Convert.ToInt32(atrapa["id_Materia"]),
                    NombreMateria = Convert.ToString(atrapa["NombreMateria"]),
                    HorasSemana = Convert.ToInt32(atrapa["HorasSemana"]),
                    Extra = Convert.ToString(atrapa["Extra"])
                };
                manC.Add(devM);
            }
            return manC;
        }

        public Boolean Insertar(EMateria Tempor, ref string mens)
        {
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter
            {
                ParameterName = "Id_Materia",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Tempor.Id_Materia
            };
            param[1] = new SqlParameter
            {
                ParameterName = "NombreMateria",
                SqlDbType = SqlDbType.VarChar,
                Size = 120,
                Direction = ParameterDirection.Input,
                Value = Tempor.NombreMateria
            };
            param[2] = new SqlParameter
            {
                ParameterName = "HorasSemena",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = Tempor.HorasSemana
            };
            param[3] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = Tempor.Id_Materia
            };

            string consulta = "Insert into Materia values(@NombreMateria, @HorasSemena, @Extra);";

            Boolean Salida = false;

            Salida = acceso.ModificaBDunPocoMasSegura(consulta, acceso.AbrirConexion(ref mens), ref mens, param);

            return Salida;
        }

        public DataTable MateriaLis(ref string mens_salida)
        {
            string query = @"select * from Materia;";
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

        public Boolean EliminMateria(int id_Materia, ref string mens_salida)
        {
            SqlParameter[] params1 = new SqlParameter[1];
            params1[0] = new SqlParameter
            {
                ParameterName = "id_Materia",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = id_Materia
            };


            string sentencia = "DELETE FROM Materia WHERE id_Materia = @id_Materia; ";

            Boolean salida = false;

            salida = acceso.ModificaBDunPocoMasSegura(sentencia, acceso.AbrirConexion(ref mens_salida), ref mens_salida, params1);

            return salida;
        }

        public Boolean ActMateria(EMateria car, ref string mens_salida)
        {
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter
            {
                ParameterName = "Id_Materia",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = car.Id_Materia
            };
            param[1] = new SqlParameter
            {
                ParameterName = "NombreMateria",
                SqlDbType = SqlDbType.VarChar,
                Size = 120,
                Direction = ParameterDirection.Input,
                Value = car.NombreMateria
            };
            param[2] = new SqlParameter
            {
                ParameterName = "HorasSemena",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = car.HorasSemana
            };
            param[3] = new SqlParameter
            {
                ParameterName = "Extra",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Direction = ParameterDirection.Input,
                Value = car.Id_Materia
            };

            string sentencia = @"update Materia
                                 set NombeMateria = @NombreMateria, HorasSemena = @HorasSemena, Extra = @Extra
                                 where Id_Materia = @Id_Materia;";

            Boolean salida = false;

            salida = acceso.ModificaBDunPocoMasSegura(sentencia, acceso.AbrirConexion(ref mens_salida), ref mens_salida, param);

            return salida;
        }

    }
}
