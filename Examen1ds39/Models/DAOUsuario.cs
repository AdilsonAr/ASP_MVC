﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Examen1ds39.Models
{
    public class DAOUsuario
    {
        private SqlConnection con;
        private SqlCommand cmd;

        public Usuario findOne(string nombre, string pass)
        {
            Usuario usuario = new Usuario();
            string command = "select*from usuarios where nombre_usuario='{0}' and contra='{1}'";
            cmd.CommandText = string.Format(command, nombre, pass);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                usuario.cod_user = int.Parse(data[0].ToString());
                usuario.nombre_usuario = data[1].ToString();
                usuario.contra = data[2].ToString();
                usuario.nivel_usuario = data[3].ToString();
                return usuario;
            }
            return null;
        }
    }
}