using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Examen1ds39.Models
{
    public class DAOCliente
    {
        private SqlConnection con;
        private SqlCommand cmd;
        public DAOCliente()
        {
            this.con = new SqlConnection();
            this.cmd = new SqlCommand();
            this.con.ConnectionString = @"Data Source=ARKGB; Initial Catalog=examen1ds39; user id=adventure; password=Itca123!";
        }
        public List<Cliente> findAll()
        {
            List<Cliente> lista = new List<Cliente>();
            cmd.CommandText = "select*from clientes";
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                Cliente cli = new Cliente();
                cli.cod_cliente = int.Parse(data[0].ToString());
                cli.nombres= data[1].ToString();
                cli.apellidos= data[2].ToString();
                cli.dui= data[3].ToString();
                cli.direccion= data[4].ToString();
                cli.nit= data[5].ToString();
                lista.Add(cli);
            }
            cmd.Connection.Close();
            return lista;
        }

        public Cliente findByCod_cliente(int codigo)
        {
            Cliente cli = new Cliente();
            cmd.CommandText = "select*from clientes where cod_cliente="+codigo + ";";
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                cli.cod_cliente = int.Parse(data[0].ToString());
                cli.nombres = data[1].ToString();
                cli.apellidos = data[2].ToString();
                cli.dui = data[3].ToString();
                cli.direccion = data[4].ToString();
                cli.nit = data[5].ToString();
            }
            cmd.Connection.Close();
            return cli;
        }

        public List<Cliente> findByNombresLike(string clave)
        {
            List<Cliente> lista = new List<Cliente>();
            String comand= "select*from clientes where nombres like('%{0}%');";
            cmd.CommandText = string.Format(comand, clave);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                Cliente cli = new Cliente();
                cli.cod_cliente = int.Parse(data[0].ToString());
                cli.nombres = data[1].ToString();
                cli.apellidos = data[2].ToString();
                cli.dui = data[3].ToString();
                cli.direccion = data[4].ToString();
                cli.nit = data[5].ToString();
                lista.Add(cli);
            }
            cmd.Connection.Close();
            return lista;
        }

        public List<Cliente> findByApellidosLike(string clave)
        {
            List<Cliente> lista = new List<Cliente>();
            String comand = "select*from clientes where apellidos like('%{0}%');";
            cmd.CommandText = string.Format(comand, clave);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                Cliente cli = new Cliente();
                cli.cod_cliente = int.Parse(data[0].ToString());
                cli.nombres = data[1].ToString();
                cli.apellidos = data[2].ToString();
                cli.dui = data[3].ToString();
                cli.direccion = data[4].ToString();
                cli.nit = data[5].ToString();
                lista.Add(cli);
            }
            cmd.Connection.Close();
            return lista;
        }

        public List<Cliente> findByDUI(string dui)
        {
            List<Cliente> lista = new List<Cliente>();
            cmd.CommandText = "select*from clientes where dui=" + dui + ";";
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                Cliente cli = new Cliente();
                cli.cod_cliente = int.Parse(data[0].ToString());
                cli.nombres = data[1].ToString();
                cli.apellidos = data[2].ToString();
                cli.dui = data[3].ToString();
                cli.direccion = data[4].ToString();
                cli.nit = data[5].ToString();
                lista.Add(cli);
            }
            cmd.Connection.Close();
            return lista;
        }

        public List<Cliente> findByDireccionLike(string clave)
        {
            List<Cliente> lista = new List<Cliente>();
            String comand = "select*from clientes where direccion like('%{0}%');";
            cmd.CommandText = string.Format(comand, clave);
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                Cliente cli = new Cliente();
                cli.cod_cliente = int.Parse(data[0].ToString());
                cli.nombres = data[1].ToString();
                cli.apellidos = data[2].ToString();
                cli.dui = data[3].ToString();
                cli.direccion = data[4].ToString();
                cli.nit = data[5].ToString();
                lista.Add(cli);
            }
            cmd.Connection.Close();
            return lista;
        }

        public List<Cliente> findByNIT(string nit)
        {
            List<Cliente> lista = new List<Cliente>();
            cmd.CommandText = "select*from clientes where nit=" + nit+";";
            cmd.Connection = con;
            cmd.Connection.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                Cliente cli = new Cliente();
                cli.cod_cliente = int.Parse(data[0].ToString());
                cli.nombres = data[1].ToString();
                cli.apellidos = data[2].ToString();
                cli.dui = data[3].ToString();
                cli.direccion = data[4].ToString();
                cli.nit = data[5].ToString();
                lista.Add(cli);
            }
            cmd.Connection.Close();
            return lista;
        }

        public bool save(Cliente cli)
        {
            string command = "insert into clientes (nombres,apellidos,dui,direccion,nit) values ('{0}','{1}','{2}','{3}','{4}');";
            cmd.CommandText = string.Format(command, cli.nombres, cli.apellidos, cli.dui, cli.direccion, cli.nit);
            cmd.Connection = con;
            cmd.Connection.Open();
            int rows=cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            if (rows > 0)
            {
                return true;
            }
            else
            {              
                return false;
            }
            
        }

        public bool update(Cliente cli)
        {
            string command = "update clientes set nombres='{0}',apellidos='{1}',dui='{2}',direccion='{3}',nit='{4}' where cod_cliente={5};";
            cmd.CommandText = string.Format(command, cli.nombres, cli.apellidos, cli.dui, cli.direccion, cli.nit, cli.cod_cliente);
            cmd.Connection = con;
            cmd.Connection.Open();
            int rows = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool delete(int cod)
        {
            cmd.CommandText = "delete clientes where cod_cliente=" + cod + ";";
            cmd.Connection = con;
            cmd.Connection.Open();
            int rows = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}