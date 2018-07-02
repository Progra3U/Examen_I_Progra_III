using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S01_03AccedoDatos;
using S01_01Entidades;
using System.Collections;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace S01_02LogicaNegocio
{
    public class LN
    {
        #region USUARIOS

       
        public static List<Usuario> ObtenerUsuarios()
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
        public static int ModificarUsuarios(Usuario usuarios)
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
                nomusuarioparametro.Value = usuarios.nombreUsuario;

                SqlParameter passparametro = new SqlParameter();
                passparametro.SqlDbType = System.Data.SqlDbType.NVarChar;
                passparametro.ParameterName = "@pass";
                passparametro.Value = usuarios.pass;

                SqlParameter activoparametro = new SqlParameter();
                activoparametro.SqlDbType = System.Data.SqlDbType.Bit;
                activoparametro.ParameterName = "@activo";
                activoparametro.Value = usuarios.activo;

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

        public static bool VerificarUsuario(Usuario usuario)
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
    }
    #endregion

}


