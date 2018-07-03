using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using S02_04Entidades;
using S02_03AccedoDatos;

namespace S02_02LogicaNegocio
{
    public class Logica
    {
        public static int AgregarPersonal(RegistroPersonal Regpersonal)
        {
            try
            {
                ArrayList lstparametros = new ArrayList(); //se define lista de valores
                SQLSentencia sentencia = new SQLSentencia();

                //Armo la peticion
                sentencia.PETICION = @"INSERT INTO RegistroPersonal VALUES (@codEmpleado, @nombreEmpleado, @identificacion, @posicion,
                                                                            @area, @Fecha, @HoraEntrada, @HoraSalida)";

                #region Definicion de parametros
                SqlParameter codEmpleado = new SqlParameter();
                codEmpleado.SqlDbType = System.Data.SqlDbType.Int;
                codEmpleado.ParameterName = "@codEmpleado";
                codEmpleado.Value = Regpersonal.codEmpleado;

                SqlParameter nombreEmpleado = new SqlParameter();
                nombreEmpleado.SqlDbType = System.Data.SqlDbType.NVarChar;
                nombreEmpleado.ParameterName = "@nombreEmpleado";
                nombreEmpleado.Value = Regpersonal.nombreEmpleado;

                SqlParameter identificacion = new SqlParameter();
                identificacion.SqlDbType = System.Data.SqlDbType.NVarChar;
                identificacion.ParameterName = "@identificacion";
                identificacion.Value = Regpersonal.identificacion;

                SqlParameter posicion = new SqlParameter();
                posicion.SqlDbType = System.Data.SqlDbType.NVarChar;
                posicion.ParameterName = "@posicion";
                posicion.Value = Regpersonal.posicion;

                SqlParameter area = new SqlParameter();
                area.SqlDbType = System.Data.SqlDbType.NVarChar;
                area.ParameterName = "@area";
                area.Value = Regpersonal.area;

                SqlParameter Fecha = new SqlParameter();
                Fecha.SqlDbType = System.Data.SqlDbType.NVarChar;
                Fecha.ParameterName = "@Fecha";
                Fecha.Value = Regpersonal.Fecha;

                SqlParameter HoraEntrada = new SqlParameter();
                HoraEntrada.SqlDbType = System.Data.SqlDbType.NVarChar;
                HoraEntrada.ParameterName = "@HoraEntrada";
                HoraEntrada.Value = Regpersonal.HoraEntrada;

                SqlParameter HoraSalida = new SqlParameter();
                HoraSalida.SqlDbType = System.Data.SqlDbType.NVarChar;
                HoraSalida.ParameterName = "@HoraSalida";
                HoraSalida.Value = Regpersonal.HoraSalida;
                #endregion

                #region  Agregando en la lista de valores 
                lstparametros.Add(codEmpleado);
                lstparametros.Add(nombreEmpleado);
                lstparametros.Add(identificacion);
                lstparametros.Add(posicion);
                lstparametros.Add(area);
                lstparametros.Add(Fecha);
                lstparametros.Add(HoraEntrada);
                lstparametros.Add(HoraSalida);
                #endregion

                //Asigna al atributo de la clase SQLSentencia la lista de valores
                sentencia.LSTPARAMETROS = lstparametros;

                Acceso objconexion = new Acceso();
                return objconexion.Ejecutar_TSQL(sentencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ModificarPersonal(RegistroPersonal Regpersonal)
        {
            try
            {
                ArrayList lstparametros = new ArrayList(); //se define lista de valores
                SQLSentencia sentencia = new SQLSentencia();

                sentencia.PETICION = @"UPDATE RegistroPersonas SET nombreEmpleado= @nombreEmpleado, identificacion= @identificacion, posicion= @posicion, 
                                                                     area= @area, Fecha= @Fecha, HoraEntrada= @HoraEntrada, HoraSalida= @HoraSalida
                                                                     WHERE codEmpleado=@codEmpleado";

                #region Definicion de parametros
                SqlParameter codEmpleado = new SqlParameter();
                codEmpleado.SqlDbType = System.Data.SqlDbType.Int;
                codEmpleado.ParameterName = "@codEmpleado";
                codEmpleado.Value = Regpersonal.codEmpleado;

                SqlParameter nombreEmpleado = new SqlParameter();
                nombreEmpleado.SqlDbType = System.Data.SqlDbType.NVarChar;
                nombreEmpleado.ParameterName = "@nombreEmpleado";
                nombreEmpleado.Value = Regpersonal.nombreEmpleado;

                SqlParameter identificacion = new SqlParameter();
                identificacion.SqlDbType = System.Data.SqlDbType.NVarChar;
                identificacion.ParameterName = "@identificacion";
                identificacion.Value = Regpersonal.identificacion;

                SqlParameter posicion = new SqlParameter();
                posicion.SqlDbType = System.Data.SqlDbType.NVarChar;
                posicion.ParameterName = "@posicion";
                posicion.Value = Regpersonal.posicion;

                SqlParameter area = new SqlParameter();
                area.SqlDbType = System.Data.SqlDbType.NVarChar;
                area.ParameterName = "@area";
                area.Value = Regpersonal.area;

                SqlParameter Fecha = new SqlParameter();
                Fecha.SqlDbType = System.Data.SqlDbType.NVarChar;
                Fecha.ParameterName = "@Fecha";
                Fecha.Value = Regpersonal.Fecha;

                SqlParameter HoraEntrada = new SqlParameter();
                HoraEntrada.SqlDbType = System.Data.SqlDbType.NVarChar;
                HoraEntrada.ParameterName = "@HoraEntrada";
                HoraEntrada.Value = Regpersonal.HoraEntrada;

                SqlParameter HoraSalida = new SqlParameter();
                HoraSalida.SqlDbType = System.Data.SqlDbType.NVarChar;
                HoraSalida.ParameterName = "@HoraSalida";
                HoraSalida.Value = Regpersonal.HoraSalida;
                #endregion

                #region  Agregando en la lista de valores 
                lstparametros.Add(codEmpleado);
                lstparametros.Add(nombreEmpleado);
                lstparametros.Add(identificacion);
                lstparametros.Add(posicion);
                lstparametros.Add(area);
                lstparametros.Add(Fecha);
                lstparametros.Add(HoraEntrada);
                lstparametros.Add(HoraSalida);
                #endregion

                //Asigna al atributo de la clase SQLSentencia la lista de valores
                sentencia.LSTPARAMETROS = lstparametros;

                Acceso objconexion = new Acceso();
                return objconexion.Ejecutar_TSQL(sentencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<RegistroPersonal> ObtenerPersonal()
        {
            try
            {
                SQLSentencia sentencia = new SQLSentencia();

                sentencia.PETICION = @"SELECT * from RegistroPersonal";

                Acceso objacceso = new Acceso();

                return objacceso.ObtenerPersonal(sentencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<RegistroPersonal> BuscarPersonal(RegistroPersonal Regpersonal)
        {
            try
            {
                SQLSentencia sentencia = new SQLSentencia();
                sentencia.PETICION = @"SELECT * FROM RegistroPersonal WWHERE codEmpleado='" + Regpersonal.codEmpleado + "'";
                S02_03AccedoDatos.Acceso objAcceso = new S02_03AccedoDatos.Acceso();
                return objAcceso.ObtenerPersonal(sentencia);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
