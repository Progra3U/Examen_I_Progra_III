using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using S02_04Entidades;

namespace S02_03AccedoDatos
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

        public List<RegistroPersonal> ObtenerPersonal(SQLSentencia objsentencia)
        {
            List<RegistroPersonal> lstresultados = new List<RegistroPersonal>();
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
                    RegistroPersonal RegPersonal = new RegistroPersonal();

                    RegPersonal.codEntrada = Convert.ToInt32(item.ItemArray[0].ToString());
                    RegPersonal.nombreEmpleado = item.ItemArray[1].ToString();
                    RegPersonal.identificacion = Convert.ToInt32(item.ItemArray[2].ToString());
                    RegPersonal.posicion = item.ItemArray[3].ToString();
                    RegPersonal.area = item.ItemArray[4].ToString();
                    RegPersonal.fechaEntrada = item.ItemArray[5].ToString(); //convertir a nvarchar  en db
                    RegPersonal.horaEntrada = item.ItemArray[6].ToString(); //crear item en db como nvarchar 
                    RegPersonal.fechaSalida= item.ItemArray[7].ToString();
                    RegPersonal.horaSalida = item.ItemArray[8].ToString(); //crear item en db como nvarchar 

                    lstresultados.Add(RegPersonal);
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
