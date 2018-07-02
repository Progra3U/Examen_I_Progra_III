using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using S03_03AccedoDatos;
using S03_04Entidades;
using System.Text.RegularExpressions;

namespace S03_02LogicaNegocio
{
    public class Logica
    {
        //Metodo para Agregar la informacion en la tabla RegistroPersonas
        public static int AgregarPersona(RegistroPersonas Regperson)
        {
            try
            {
                ArrayList lstparametros = new ArrayList(); //se define lista de valores
                SQLSentencia sentencia = new SQLSentencia();

                //Armo la peticion
                sentencia.PETICION = @"INSERT INTO RegistroPersonas VALUES (@identificacion, @nombre, @apellido, @edad,
                                                                            @correo, @tetefono, @pais, @ciudad, @detalles)";

                //Defino parametros y sus caracteristicas
                SqlParameter identificacion = new SqlParameter();
                identificacion.SqlDbType = System.Data.SqlDbType.Int;
                identificacion.ParameterName = "@identificacion";
                identificacion.Value = Regperson.identificacion;

                SqlParameter nombre = new SqlParameter();
                nombre.SqlDbType = System.Data.SqlDbType.NVarChar;
                nombre.ParameterName = "@nombre";
                nombre.Value = Regperson.nombre;

                SqlParameter apellido = new SqlParameter();
                apellido.SqlDbType = System.Data.SqlDbType.NVarChar;
                apellido.ParameterName = "@apellido";
                apellido.Value = Regperson.apellido;

                SqlParameter edad = new SqlParameter();
                edad.SqlDbType = System.Data.SqlDbType.Int;
                edad.ParameterName = "@edad";
                edad.Value = Regperson.edad;

                SqlParameter correo = new SqlParameter();
                correo.SqlDbType = System.Data.SqlDbType.NVarChar;
                correo.ParameterName = "@correo";
                correo.Value = Regperson.correo;

                SqlParameter tetefono = new SqlParameter();
                tetefono.SqlDbType = System.Data.SqlDbType.Int;
                tetefono.ParameterName = "@tetefono";
                tetefono.Value = Regperson.tetefono;

                SqlParameter pais = new SqlParameter();
                pais.SqlDbType = System.Data.SqlDbType.NVarChar;
                pais.ParameterName = "@pais";
                pais.Value = Regperson.pais;

                SqlParameter ciudad = new SqlParameter();
                ciudad.SqlDbType = System.Data.SqlDbType.NVarChar;
                ciudad.ParameterName = "@ciudad";
                ciudad.Value = Regperson.ciudad;

                SqlParameter detalles = new SqlParameter();
                detalles.SqlDbType = System.Data.SqlDbType.NVarChar;
                detalles.ParameterName = "@detalles";
                detalles.Value = Regperson.detalles;

                //Agregando en la lista de valores 
                lstparametros.Add(identificacion);
                lstparametros.Add(nombre);
                lstparametros.Add(apellido);
                lstparametros.Add(edad);
                lstparametros.Add(correo);
                lstparametros.Add(tetefono);
                lstparametros.Add(pais);
                lstparametros.Add(ciudad);
                lstparametros.Add(detalles);

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

        //Metodo para Modificar la informacion en la tabla RegistroPersonas
        public static int ModificarPersona(RegistroPersonas Regperson)
        {
            try
            {
                ArrayList lstparametros = new ArrayList(); //se define lista de valores
                SQLSentencia sentencia = new SQLSentencia();

                sentencia.PETICION = @"UPDATE RegistroPersonas SET nombre= @nombre, apellido= @apellido, edad= @edad, correo= @correo, 
                                                                     tetefono= @tetefono, pais= @pais, ciudad= @ciudad, detalles= @detalles 
                                                                     WHERE identificacion=@identificacion";

                //Defino parametros y sus caracteristicas
                SqlParameter nombre = new SqlParameter();
                nombre.SqlDbType = System.Data.SqlDbType.NVarChar;
                nombre.ParameterName = "@nombre";
                nombre.Value = Regperson.nombre;

                SqlParameter apellido = new SqlParameter();
                apellido.SqlDbType = System.Data.SqlDbType.NVarChar;
                apellido.ParameterName = "@apellido";
                apellido.Value = Regperson.apellido;

                SqlParameter edad = new SqlParameter();
                edad.SqlDbType = System.Data.SqlDbType.Int;
                edad.ParameterName = "@edad";
                edad.Value = Regperson.edad;

                SqlParameter correo = new SqlParameter();
                correo.SqlDbType = System.Data.SqlDbType.NVarChar;
                correo.ParameterName = "@correo";
                correo.Value = Regperson.correo;

                SqlParameter tetefono = new SqlParameter();
                tetefono.SqlDbType = System.Data.SqlDbType.Int;
                tetefono.ParameterName = "@tetefono";
                tetefono.Value = Regperson.tetefono;

                SqlParameter pais = new SqlParameter();
                pais.SqlDbType = System.Data.SqlDbType.NVarChar;
                pais.ParameterName = "@pais";
                pais.Value = Regperson.pais;

                SqlParameter ciudad = new SqlParameter();
                ciudad.SqlDbType = System.Data.SqlDbType.NVarChar;
                ciudad.ParameterName = "@ciudad";
                ciudad.Value = Regperson.ciudad;

                SqlParameter detalles = new SqlParameter();
                detalles.SqlDbType = System.Data.SqlDbType.NVarChar;
                detalles.ParameterName = "@detalles";
                detalles.Value = Regperson.detalles;

                SqlParameter identificacion = new SqlParameter();
                identificacion.SqlDbType = System.Data.SqlDbType.Int;
                identificacion.ParameterName = "@identificacion";
                identificacion.Value = Regperson.identificacion;

                //Agregando en la lista de valores 
                lstparametros.Add(nombre);
                lstparametros.Add(apellido);
                lstparametros.Add(edad);
                lstparametros.Add(correo);
                lstparametros.Add(tetefono);
                lstparametros.Add(pais);
                lstparametros.Add(ciudad);
                lstparametros.Add(detalles);
                lstparametros.Add(identificacion);

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

        //Metodo para eliminar la informacion en la tabla RegistroPersonas
        public static int EliminarPersona(RegistroPersonas Regperson)
        {
            try
            {
                ArrayList lstparametros = new ArrayList(); //se define lista de valores
                SQLSentencia sentencia = new SQLSentencia();

                sentencia.PETICION = @"DELETE FROM RegistroPersonas WHERE identificacion=@identificacion";

                //Defino parametros y sus caracteristicas
                SqlParameter identificacion = new SqlParameter();
                identificacion.SqlDbType = System.Data.SqlDbType.Int;
                identificacion.ParameterName = "@identificacion";
                identificacion.Value = Regperson.identificacion;

                //Agregando en la lista de valores 
                lstparametros.Add(identificacion);

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

        //Metodo para obtener la informacion en la tabla RegistroPersonas
        public static List<RegistroPersonas> ObtenerPersonas()
        {
            try
            {
                SQLSentencia sentencia = new SQLSentencia();

                sentencia.PETICION = @"SELECT * from RegistroPersonas";

                Acceso objacceso = new Acceso();

                return objacceso.ObtenerPersonas(sentencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //Metodo para Buscar informacion en la tabla RegistroPersonas
        public static List<RegistroPersonas> BuscarPersona(RegistroPersonas Regperson) 
        {
            try
            {
                SQLSentencia sentencia = new SQLSentencia();
                sentencia.PETICION = @"SELECT * FROM RegistroPersonas WHERE identificacion='" + Regperson.identificacion + "'";
                S03_03AccedoDatos.Acceso objAcceso = new S03_03AccedoDatos.Acceso();
                return objAcceso.ObtenerPersonas(sentencia);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool ValidarCampoPorPatron(string patron,string valor)
        {
            try
            {
                MatchCollection lstcoincidencias = Regex.Matches(valor, patron);
                if (lstcoincidencias.Count > 0) 
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
}
