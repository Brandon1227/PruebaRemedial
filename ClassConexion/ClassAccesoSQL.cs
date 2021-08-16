using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ClassConexion
{
    public class ClassAccesoSQL
    {
        private string cadConexion;
        public ClassAccesoSQL(string cadenaBD)
        {
            cadConexion = cadenaBD;
        }

        public SqlConnection AbrirConexion(ref string mensaje) // Metodo con parametros de referencia
        {
            SqlConnection conexion1 = new SqlConnection();
            conexion1.ConnectionString = cadConexion;
            try
            {
                conexion1.Open();
                mensaje = "Conexión abierta CORRECTAMENTE";
            }
            catch (Exception r)
            {
                conexion1 = null; //Devuelve una conexion nula
                mensaje = "Error: " + r.Message;
            }
            return conexion1;
        }


        public DataSet ConsultaDS(string querySql, SqlConnection conAbierta, ref string mensaje)
        {
            SqlCommand carrito = null;
            SqlDataAdapter trailer = null;
            DataSet DS_salida = new DataSet();

            if (conAbierta == null)
            {
                mensaje = "No hay conexion a la BD";
                DS_salida = null;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySql;
                carrito.Connection = conAbierta;

                trailer = new SqlDataAdapter();
                trailer.SelectCommand = carrito;

                try
                {
                    trailer.Fill(DS_salida, "Consulta1");
                    mensaje = "Consulta Correcta en DataSet";
                }
                catch (Exception a)
                {
                    mensaje = "Error!" + a.Message;
                }
                conAbierta.Close();
                conAbierta.Dispose();
            }
            return DS_salida;
        }

        public SqlDataReader ConsultarReader(string querySql, SqlConnection conAbierta, ref string mensaje)
        {
            SqlCommand carrito = null;
            SqlDataReader contenedor = null;

            if (conAbierta == null)
            {
                mensaje = "No hay conexion a la BD";
                contenedor = null;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySql;
                carrito.Connection = conAbierta;

                try
                {
                    contenedor = carrito.ExecuteReader();
                    mensaje = "Consulta Correcta DataReader";
                }
                catch (Exception a)
                {
                    contenedor = null;
                    mensaje = "Error!" + a.Message;
                }
            }
            return contenedor;
        }

        public Boolean MultiplesConsultasDataSet(string querySql, SqlConnection conAbierta, ref string mensaje, ref DataSet dataset1, string nomConsulta)
        {
            SqlCommand carrito = null;
            SqlDataAdapter trailer = null;
            Boolean salida = false;

            if (conAbierta == null)
            {
                mensaje = "No hay conexion a la BD";
                salida = false;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySql;
                carrito.Connection = conAbierta;

                trailer = new SqlDataAdapter();
                trailer.SelectCommand = carrito;

                try
                {
                    trailer.Fill(dataset1, nomConsulta);
                    mensaje = "Consulta correcta en el DataSet";
                    salida = true;
                }
                catch (Exception a)
                {
                    mensaje = "Error: " + a.Message;
                }
                conAbierta.Close();
                conAbierta.Dispose();
            }
            return salida;
        }

        public Boolean ModificaBDInsegura(string sentenciaSql, SqlConnection conAbierta, ref string mensaje)
        {
            SqlCommand carrito = null;
            //SqlDataReader contenedor = null;
            Boolean salida = false;
            if (conAbierta == null)
            {
                mensaje = "No hay conexion a la BD";
                salida = false;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = sentenciaSql;
                carrito.Connection = conAbierta;

                try
                {
                    carrito.ExecuteNonQuery();
                    mensaje = "Modificacion Correcta";
                    salida = true;
                }
                catch (Exception a)
                {
                    salida = false;
                    mensaje = "Error!" + a.Message;

                }
                conAbierta.Close();
                conAbierta.Dispose();
            }
            return salida;
        }

        public Boolean InsertaEmpleadoconPar(string sentenciaSQL, SqlConnection cnab, ref string mensaje, SqlParameter par1, SqlParameter par2)
        {
            Boolean salida = false;
            SqlCommand vocho = null;

            if (cnab != null)
            {
                vocho = new SqlCommand();

                vocho.CommandText = sentenciaSQL;

                //Agregar los parametros
                vocho.Parameters.Add(par1);
                vocho.Parameters.Add(par2);

                vocho.Connection = cnab;
                try
                {
                    vocho.ExecuteNonQuery();
                    mensaje = "modificado con parámetros Correcta";
                    salida = true;

                }
                catch (Exception w)
                {
                    mensaje = "Error: " + w.Message;
                    salida = false;
                }

            }
            else
            {
                mensaje = "no hay conexion a la base de datos";
            }
            return salida;
        }

        public Boolean ModificaBDunPocoMasSegura(string sentenciaSQL, SqlConnection cnab, ref string mensaje, SqlParameter[] parametros)
        {
            Boolean salida = false;
            SqlCommand vocho = null;

            if (cnab != null)
            {
                vocho = new SqlCommand();

                vocho.CommandText = sentenciaSQL;

                //Agregar los parametros
                foreach (SqlParameter p in parametros)
                {
                    vocho.Parameters.Add(p);
                }

                vocho.Connection = cnab;
                try
                {
                    vocho.ExecuteNonQuery();
                    mensaje = "modificado con parámetros Correcta";
                    salida = true;

                }
                catch (Exception w)
                {
                    mensaje = "Error: " + w.Message;
                    salida = false;
                }

            }
            else
            {
                mensaje = "no hay conexion a la base de datos";
            }
            return salida;
        }

        public SqlDataReader ModificaBDunPocoMasSeguraDS(string sentenciaSQL, SqlConnection cnab, ref string mensaje, SqlParameter[] parametros)
        {

            SqlCommand vocho = null;
            SqlDataReader resultado = null;

            if (cnab != null)
            {
                vocho = new SqlCommand();

                vocho.CommandText = sentenciaSQL;

                //Agregar los parametros
                foreach (SqlParameter p in parametros)
                {
                    vocho.Parameters.Add(p);
                }

                vocho.Connection = cnab;
                try
                {
                    resultado = vocho.ExecuteReader();
                    mensaje = "modificado con parámetros Correcta";


                }
                catch (Exception w)
                {
                    mensaje = "Error: " + w.Message;

                }

            }
            else
            {
                mensaje = "no hay conexion a la base de datos";
            }
            return resultado;
        }
    }
}