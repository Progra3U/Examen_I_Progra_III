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
                sentencia.PETICION = @"INSERT INTO RegistroPersonal VALUES (@nombreEmpleado, @identificacion, @posicion,
                                                                            @area, @fechaEntrada, @horaEntrada, @fechaSalida, @horaSalida)";

                #region Definicion de parametros
                //SqlParameter codEmpleado = new SqlParameter();
                //codEmpleado.SqlDbType = System.Data.SqlDbType.Int;
                //codEmpleado.ParameterName = "@codEmpleado";
                //codEmpleado.Value = Regpersonal.codEmpleado;

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

                SqlParameter fechaEntrada = new SqlParameter();
                fechaEntrada.SqlDbType = System.Data.SqlDbType.NVarChar;
                fechaEntrada.ParameterName = "@fechaEntrada";
                fechaEntrada.Value = Regpersonal.fechaEntrada;

                SqlParameter horaEntrada = new SqlParameter();
                horaEntrada.SqlDbType = System.Data.SqlDbType.NVarChar;
                horaEntrada.ParameterName = "@horaEntrada";
                horaEntrada.Value = Regpersonal.horaEntrada;

                SqlParameter fechaSalida = new SqlParameter();
                fechaSalida.SqlDbType = System.Data.SqlDbType.NVarChar;
                fechaSalida.ParameterName = "@fechaSalida";
                fechaSalida.Value = Regpersonal.fechaSalida;

                SqlParameter horaSalida = new SqlParameter();
                horaSalida.SqlDbType = System.Data.SqlDbType.NVarChar;
                horaSalida.ParameterName = "@horaSalida";
                horaSalida.Value = Regpersonal.horaSalida;
                #endregion

                #region  Agregando en la lista de valores 
                //lstparametros.Add(codEmpleado);
                lstparametros.Add(nombreEmpleado);
                lstparametros.Add(identificacion);
                lstparametros.Add(posicion);
                lstparametros.Add(area);
                lstparametros.Add(fechaEntrada);
                lstparametros.Add(horaEntrada);
                lstparametros.Add(fechaSalida);
                lstparametros.Add(horaSalida);
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

                sentencia.PETICION = @"UPDATE RegistroPersonal SET nombreEmpleado= @nombreEmpleado, identificacion= @identificacion, posicion= @posicion, area= @area
                                                                    WHERE codEntrada=@codEntrada";
                //, 
                //fechaEntrada = @fechaEntrada, horaEntrada = @horaEntrada, fechaSalida = @fechaSalida, horaSalida = @horaSalida

                #region Definicion de parametros
                SqlParameter codEntrada = new SqlParameter();
                codEntrada.SqlDbType = System.Data.SqlDbType.Int;
                codEntrada.ParameterName = "@codEmpleado";
                codEntrada.Value = Regpersonal.codEntrada;

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

                /*SqlParameter fechaEntrada = new SqlParameter();
                fechaEntrada.SqlDbType = System.Data.SqlDbType.NVarChar;
                fechaEntrada.ParameterName = "--/--/--";
                fechaEntrada.Value = Regpersonal.fechaEntrada;

                SqlParameter horaEntrada = new SqlParameter();
                horaEntrada.SqlDbType = System.Data.SqlDbType.NVarChar;
                horaEntrada.ParameterName = "--:--";
                horaEntrada.Value = Regpersonal.horaEntrada;

                SqlParameter fechaSalida = new SqlParameter();
                fechaSalida.SqlDbType = System.Data.SqlDbType.NVarChar;
                fechaSalida.ParameterName = "--/--/--";
                fechaSalida.Value = Regpersonal.fechaSalida;

                SqlParameter horaSalida = new SqlParameter();
                horaSalida.SqlDbType = System.Data.SqlDbType.NVarChar;
                horaSalida.ParameterName = "--:--";
                horaSalida.Value = Regpersonal.horaSalida;*/
                #endregion

                #region  Agregando en la lista de valores 
                lstparametros.Add(codEntrada);
                lstparametros.Add(nombreEmpleado);
                lstparametros.Add(identificacion);
                lstparametros.Add(posicion);
                lstparametros.Add(area);
                /*lstparametros.Add(fechaEntrada);
                lstparametros.Add(horaEntrada);
                lstparametros.Add(fechaSalida);
                lstparametros.Add(horaSalida);*/
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

        public static int ModificarHoraEntrada(RegistroPersonal Regpersonal)
        {
            try
            {
                ArrayList lstparametros = new ArrayList(); //se define lista de valores
                SQLSentencia sentencia = new SQLSentencia();

                //sentencia.PETICION = @"UPDATE RegistroPersonal SET fechaEntrada= @fechaEntrada, horaEntrada= @horaEntrada WHERE codEmpleado=@codEmpleado";
                sentencia.PETICION = @"INSERT INTO RegistroPersonal VALUES (@nombreEmpleado, @identificacion, @posicion,
                                                                            @area, @fechaEntrada, @horaEntrada, @fechaSalida, @horaSalida)";

                #region Definicion de parametros
                //SqlParameter codEmpleado = new SqlParameter();
                //codEmpleado.SqlDbType = System.Data.SqlDbType.Int;
                //codEmpleado.ParameterName = "@codEmpleado";
                //codEmpleado.Value = Regpersonal.codEmpleado;

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

                SqlParameter fechaEntrada = new SqlParameter();
                fechaEntrada.SqlDbType = System.Data.SqlDbType.NVarChar;
                fechaEntrada.ParameterName = "@fechaEntrada";
                fechaEntrada.Value = Regpersonal.fechaEntrada;

                SqlParameter horaEntrada = new SqlParameter();
                horaEntrada.SqlDbType = System.Data.SqlDbType.NVarChar;
                horaEntrada.ParameterName = "@horaEntrada";
                horaEntrada.Value = Regpersonal.horaEntrada;

                SqlParameter fechaSalida = new SqlParameter();
                fechaSalida.SqlDbType = System.Data.SqlDbType.NVarChar;
                fechaSalida.ParameterName = "@fechaSalida";
                fechaSalida.Value = Regpersonal.fechaSalida;

                SqlParameter horaSalida = new SqlParameter();
                horaSalida.SqlDbType = System.Data.SqlDbType.NVarChar;
                horaSalida.ParameterName = "@horaSalida";
                horaSalida.Value = Regpersonal.horaSalida;

                #endregion

                #region  Agregando en la lista de valores 
                //lstparametros.Add(codEmpleado);
                lstparametros.Add(nombreEmpleado);
                lstparametros.Add(identificacion);
                lstparametros.Add(posicion);
                lstparametros.Add(area);
                lstparametros.Add(fechaEntrada);
                lstparametros.Add(horaEntrada);
                lstparametros.Add(fechaSalida);
                lstparametros.Add(horaSalida);
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

        public static int ModificarHoraSalida(RegistroPersonal Regpersonal)
        {
            try
            {
                ArrayList lstparametros = new ArrayList(); //se define lista de valores
                SQLSentencia sentencia = new SQLSentencia();

                sentencia.PETICION = @"UPDATE RegistroPersonal SET fechaSalida= @fechaSalida, horaSalida= @horaSalida WHERE codEntrada=@codEntrada";

                #region Definicion de parametros
                SqlParameter codEntrada = new SqlParameter();
                codEntrada.SqlDbType = System.Data.SqlDbType.Int;
                codEntrada.ParameterName = "@codEntrada";
                codEntrada.Value = Regpersonal.codEntrada;

                SqlParameter fechaSalida = new SqlParameter();
                fechaSalida.SqlDbType = System.Data.SqlDbType.NVarChar;
                fechaSalida.ParameterName = "@fechaSalida";
                fechaSalida.Value = Regpersonal.fechaSalida;

                SqlParameter horaSalida = new SqlParameter();
                horaSalida.SqlDbType = System.Data.SqlDbType.NVarChar;
                horaSalida.ParameterName = "@HoraSalida";
                horaSalida.Value = Regpersonal.horaSalida;
                #endregion

                #region  Agregando en la lista de valores 
                lstparametros.Add(codEntrada);
                lstparametros.Add(fechaSalida);
                lstparametros.Add(horaSalida);
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
                sentencia.PETICION = @"SELECT * FROM RegistroPersonal WHERE identificacion='" + Regpersonal.identificacion + "'";
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
