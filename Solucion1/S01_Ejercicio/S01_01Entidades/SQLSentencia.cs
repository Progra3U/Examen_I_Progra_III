using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;  //Proveedor de SQL
using System.Collections; //Libreria para manejo de conexiones


namespace S01_01Entidades
{
    public class SQLSentencia
    {
        private string peticion;
        private ArrayList lstparametros;

        public SQLSentencia()
        {
            this.peticion = String.Empty;
        }

        public ArrayList LSTPARAMETROS
        {
            set { this.lstparametros = value; }
            get { return this.lstparametros; }
        }

        public string PETICION
        {
            set { this.peticion = value; }
            get { return this.peticion; }
        }

    }
}

