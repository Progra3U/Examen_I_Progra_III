﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S02_04Entidades
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
