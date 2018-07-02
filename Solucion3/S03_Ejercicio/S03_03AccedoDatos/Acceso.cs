using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using S03_04Entidades;
using System.Collections;

namespace S03_03AccedoDatos
{
    public class Acceso
    {
        #region ATRIBUTOS

        private string strconexion = Properties.Settings.Default.conexion;
        private SqlConnection objconexion;

        #endregion

        #region CONSTRUCTOR

        public Acceso()
        {
            try
            {
                objconexion = new SqlConnection(strconexion);
                ABRIR();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CERRAR();
            }
        }

        private void ABRIR()
        {
            if (objconexion.State == System.Data.ConnectionState.Closed)
                objconexion.Open();

        }

        private void CERRAR()
        {
            if (objconexion.State == System.Data.ConnectionState.Open)
                objconexion.Close();

        }

        #endregion

        #region METODOS 

        public int Ejecutar_TSQL(SQLSentencia objsentencia)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                //ASigna la peticion a ejecutar
                cmd.CommandText = objsentencia.PETICION;
                cmd.Connection = objconexion;
                cmd.CommandType = System.Data.CommandType.Text;

                //Tiene asignado parametros? 
                if (objsentencia.LSTPARAMETROS.Count > 0)
                    //Agrega como parte de la configuracion los parametros a ejecutar
                    cmd.Parameters.AddRange(objsentencia.LSTPARAMETROS.ToArray());

                ABRIR();
                return cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }
        }

        public List<RegistroPersonas> ObtenerPersonas(SQLSentencia objsentencia)
        {
            List<RegistroPersonas> lstresultados = new List<RegistroPersonas>();
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = objsentencia.PETICION;
                cmd.Connection = objconexion;
                cmd.CommandType = System.Data.CommandType.Text;

                if (objsentencia.LSTPARAMETROS != null)
                    cmd.Parameters.AddRange(objsentencia.LSTPARAMETROS.ToArray());

                SqlDataAdapter objcarga = new SqlDataAdapter(cmd);
                objcarga.Fill(dt);

                foreach (System.Data.DataRow item in dt.Rows)
                {
                    RegistroPersonas RegPerson = new RegistroPersonas();

                    RegPerson.identificacion = Convert.ToInt32(item.ItemArray[0].ToString());
                    RegPerson.nombre = item.ItemArray[1].ToString();
                    RegPerson.apellido = item.ItemArray[2].ToString();
                    RegPerson.edad = Convert.ToInt32(item.ItemArray[3].ToString());
                    RegPerson.correo = item.ItemArray[4].ToString();
                    RegPerson.tetefono = Convert.ToInt32(item.ItemArray[5].ToString());
                    RegPerson.pais = item.ItemArray[6].ToString();
                    RegPerson.ciudad = item.ItemArray[7].ToString();
                    RegPerson.detalles = item.ItemArray[8].ToString();

                    lstresultados.Add(RegPerson);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CERRAR();
            }

            return lstresultados;
        }

       

       

        #endregion
    }
}
