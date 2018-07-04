using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using S01_01Entidades;


namespace S01_03AccedoDatos
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

        public List<Usuarios> ObtenerUsuarios(SQLSentencia objsentencia)
        {
            List<Usuarios> lstresultados = new List<Usuarios>();
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = objsentencia.PETICION;
                cmd.Connection = objconexion;
                cmd.CommandType = System.Data.CommandType.Text;

                if (objsentencia.LSTPARAMETROS != null)
                    if (objsentencia.LSTPARAMETROS.Count > 0)
                        cmd.Parameters.AddRange(objsentencia.LSTPARAMETROS.ToArray());

                SqlDataAdapter objcarga = new SqlDataAdapter(cmd);
                objcarga.Fill(dt);

                foreach (System.Data.DataRow item in dt.Rows)
                {
                    Usuarios usuario = new Usuarios();

                    usuario.nombreUsuario = item.ItemArray[0].ToString();
                    usuario.pass = item.ItemArray[1].ToString();
                    usuario.activo = Convert.ToBoolean(item.ItemArray[2].ToString());

                    lstresultados.Add(usuario);
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
    }
    #endregion
}