using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using S04_03AccedoDatos;
using S04_04Entidades;


namespace S04_02LogicaNegocio
{
    public class Logica
    {
        #region USUARIOS

        public static int AgregarUsuario(Usuarios usuario)
        {
            try
            {
                ArrayList lstparametros = new ArrayList(); //se define lista de valores
                SQLSentencia sentencia = new SQLSentencia();

                //Armo la peticion
                sentencia.PETICION = @"INSERT INTO Usuarios VALUES (@nombreUsuario, @pass, @activo)";

                //Defino parametros y sus caracteristicas
                SqlParameter nomusuarioparametro = new SqlParameter();
                nomusuarioparametro.SqlDbType = System.Data.SqlDbType.NVarChar;
                nomusuarioparametro.ParameterName = "@nombreUsuario";
                nomusuarioparametro.Value = usuario.nombreUsuario;

                SqlParameter passparametro = new SqlParameter();
                passparametro.SqlDbType = System.Data.SqlDbType.NVarChar;
                passparametro.ParameterName = "@pass";
                passparametro.Value = usuario.pass;

                SqlParameter activoparametro = new SqlParameter();
                activoparametro.SqlDbType = System.Data.SqlDbType.Bit;
                activoparametro.ParameterName = "@activo";
                activoparametro.Value = usuario.activo;

                //Agregando en la lista de valores 
                lstparametros.Add(nomusuarioparametro);
                lstparametros.Add(passparametro);
                lstparametros.Add(activoparametro);

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

        public static List<Usuarios> ObtenerUsuarios()
        {
            try
            {
                SQLSentencia sentencia = new SQLSentencia();

                sentencia.PETICION = @"SELECT nombreUsuario, pass, activo from Usuarios";

                Acceso objacceso = new Acceso();

                return objacceso.ObtenerUsuarios(sentencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ModificarUsuarios(Usuarios usuario)
        {
            try
            {
                ArrayList lstparametros = new ArrayList(); //se define lista de valores
                SQLSentencia sentencia = new SQLSentencia();

                sentencia.PETICION = @"UPDATE Usuarios SET pass = @pass, activo = @activo WHERE nombreUsuario = @nombreUsuario";

                //Defino parametros y sus caracteristicas
                SqlParameter nomusuarioparametro = new SqlParameter();
                nomusuarioparametro.SqlDbType = System.Data.SqlDbType.NVarChar;
                nomusuarioparametro.ParameterName = "@nombreUsuario";
                nomusuarioparametro.Value = usuario.nombreUsuario;

                SqlParameter passparametro = new SqlParameter();
                passparametro.SqlDbType = System.Data.SqlDbType.NVarChar;
                passparametro.ParameterName = "@pass";
                passparametro.Value = usuario.pass;

                SqlParameter activoparametro = new SqlParameter();
                activoparametro.SqlDbType = System.Data.SqlDbType.Bit;
                activoparametro.ParameterName = "@activo";
                activoparametro.Value = usuario.activo;

                //Agregando en la lista de valores 
                lstparametros.Add(nomusuarioparametro);
                lstparametros.Add(passparametro);
                lstparametros.Add(activoparametro);

                //Asigna al atributo de la clase SQLSentencia la lista de valores
                sentencia.LSTPARAMETROS = lstparametros;

                Acceso objacceso = new Acceso();
                return objacceso.Ejecutar_TSQL(sentencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int EliminarUsuarios(Usuarios usuario)
        {
            try
            {
                ArrayList lstparametros = new ArrayList(); //se define lista de valores
                SQLSentencia sentencia = new SQLSentencia();

                sentencia.PETICION = @"DELETE FROM Usuarios WHERE nombreUsuario = @nombreUsuario";

                //Defino parametros y sus caracteristicas
                SqlParameter nomusuarioparametro = new SqlParameter();
                nomusuarioparametro.SqlDbType = System.Data.SqlDbType.NVarChar;
                nomusuarioparametro.ParameterName = "@nombreUsuario";
                nomusuarioparametro.Value = usuario.nombreUsuario;

                //Agregando en la lista de valores 
                lstparametros.Add(nomusuarioparametro);

                //Asigna al atributo de la clase SQLSentencia la lista de valores
                sentencia.LSTPARAMETROS = lstparametros;

                Acceso objacceso = new Acceso();
                return objacceso.Ejecutar_TSQL(sentencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool VerificarUsuario(Usuarios usuario)
        {
            try
            {
                ArrayList lstparametros = new ArrayList(); //se define lista de valores

                SQLSentencia sentencia = new SQLSentencia();
                sentencia.PETICION = @"SELECT nombreUsuario, pass, activo from Usuarios where nombreUsuario = @nombreUsuario and pass = @pass and activo = 1";

                //Defino parametros y sus caracteristicas
                SqlParameter nomusuarioparametro = new SqlParameter();
                nomusuarioparametro.SqlDbType = System.Data.SqlDbType.NVarChar;
                nomusuarioparametro.ParameterName = "@nombreUsuario";
                nomusuarioparametro.Value = usuario.nombreUsuario;

                SqlParameter passparametro = new SqlParameter();
                passparametro.SqlDbType = System.Data.SqlDbType.NVarChar;
                passparametro.ParameterName = "@pass";
                passparametro.Value = usuario.pass;

                //Agregando en la lista de valores 
                lstparametros.Add(nomusuarioparametro);
                lstparametros.Add(passparametro);

                //Asigna al atributo de la clase SQLSentencia la lista de valores
                sentencia.LSTPARAMETROS = lstparametros;

                Acceso objacceso = new Acceso();

                //Aqui consulto si la ejecución de la peticion devuelve resultados
                //SI devuelve el usuario esta correcto
                //NO devuelve las credenciales no estan bien
                if (objacceso.ObtenerUsuarios(sentencia).Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static List<Perfiles> ObtenerPerfilesPorUsuario(Usuarios usuario)
        {
            try
            {
                ArrayList lstparametros = new ArrayList(); //se define lista de valores

                SQLSentencia sentencia = new SQLSentencia();
                sentencia.PETICION = @"Select p.codPerfil from perfiles p inner join UsuariosPorPerfiles uxp on p.codperfil = uxp.codperfil where uxp.nomusuario = @nomusuario";

                //Defino parametros y sus caracteristicas
                SqlParameter nomusuarioparametro = new SqlParameter();
                nomusuarioparametro.SqlDbType = System.Data.SqlDbType.NVarChar;
                nomusuarioparametro.ParameterName = "@nombreUsuario";
                nomusuarioparametro.Value = usuario.nombreUsuario;

                //Agregando en la lista de valores 
                lstparametros.Add(nomusuarioparametro);

                //Asigna al atributo de la clase SQLSentencia la lista de valores
                sentencia.LSTPARAMETROS = lstparametros;

                Acceso objacceso = new Acceso();
                return objacceso.ObtenerPerfilesPorUsuario(sentencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region PERFILES

        public static int AgregarPerfil(Perfiles perfil)
        {
            try
            {
                ArrayList lstparametros = new ArrayList(); //se define lista de valores
                SQLSentencia sentencia = new SQLSentencia();

                //Armo la peticion
                sentencia.PETICION = @"INSERT INTO Perfiles VALUES (@codPerfil, @nombrePerfil, @activo)";

                //Defino parametros y sus caracteristicas
                SqlParameter codPerfil = new SqlParameter();
                codPerfil.SqlDbType = System.Data.SqlDbType.Int;
                codPerfil.ParameterName = "@codPerfil";
                codPerfil.Value = perfil.codPerfil;

                SqlParameter nombrePerfil = new SqlParameter();
                nombrePerfil.SqlDbType = System.Data.SqlDbType.NVarChar;
                nombrePerfil.ParameterName = "@nombrePerfil";
                nombrePerfil.Value = perfil.nombrePerfil;

                SqlParameter activo = new SqlParameter();
                activo.SqlDbType = System.Data.SqlDbType.Bit;
                activo.ParameterName = "@activo";
                activo.Value = perfil.activo;

                //Agregando en la lista de valores 
                lstparametros.Add(codPerfil);
                lstparametros.Add(nombrePerfil);
                lstparametros.Add(activo);

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

        public static List<Perfiles> ObtenerPerfiles()
        {
            try
            {
                SQLSentencia sentencia = new SQLSentencia();

                sentencia.PETICION = @"SELECT codPerfil, nombrePerfil, activo from Perfiles";

                Acceso objacceso = new Acceso();

                return objacceso.ObtenerPerfiles(sentencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ModificarPerfil(Perfiles perfil)
        {
            try
            {
                ArrayList lstparametros = new ArrayList(); //se define lista de valores
                SQLSentencia sentencia = new SQLSentencia();

                sentencia.PETICION = @"UPDATE Perfiles SET nombrePerfil = @nombrePerfil, activo = @activo WHERE codPerfil = @codPerfil";

                //Defino parametros y sus caracteristicas
                SqlParameter codPerfil = new SqlParameter();
                codPerfil.SqlDbType = System.Data.SqlDbType.Int;
                codPerfil.ParameterName = "@codPerfil";
                codPerfil.Value = perfil.codPerfil;

                SqlParameter nombrePerfil = new SqlParameter();
                nombrePerfil.SqlDbType = System.Data.SqlDbType.NVarChar;
                nombrePerfil.ParameterName = "@nombrePerfil";
                nombrePerfil.Value = perfil.nombrePerfil;

                SqlParameter activo = new SqlParameter();
                activo.SqlDbType = System.Data.SqlDbType.Bit;
                activo.ParameterName = "@activo";
                activo.Value = perfil.activo;

                //Agregando en la lista de valores 
                lstparametros.Add(codPerfil);
                lstparametros.Add(nombrePerfil);
                lstparametros.Add(activo);

                //Asigna al atributo de la clase SQLSentencia la lista de valores
                sentencia.LSTPARAMETROS = lstparametros;

                Acceso objacceso = new Acceso();
                return objacceso.Ejecutar_TSQL(sentencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int EliminarPerfil(Perfiles perfil)
        {
            try
            {
                ArrayList lstparametros = new ArrayList(); //se define lista de valores
                SQLSentencia sentencia = new SQLSentencia();

                sentencia.PETICION = @"DELETE FROM Perfiles WHERE codPerfil = @codPerfil";

                //Defino parametros y sus caracteristicas
                SqlParameter codPerfil = new SqlParameter();
                codPerfil.SqlDbType = System.Data.SqlDbType.NVarChar;
                codPerfil.ParameterName = "@codPerfil";
                codPerfil.Value = perfil.codPerfil;

                //Agregando en la lista de valores 
                lstparametros.Add(codPerfil);

                //Asigna al atributo de la clase SQLSentencia la lista de valores
                sentencia.LSTPARAMETROS = lstparametros;

                Acceso objacceso = new Acceso();
                return objacceso.Ejecutar_TSQL(sentencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
