﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Sistema_de_riego
{
    public class conexion
    {
        public SqlConnection LeerCadena()
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["unica"].ConnectionString);  
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
            else
            {
                cn.Open();
            }
            return cn;
        }
    }
}
