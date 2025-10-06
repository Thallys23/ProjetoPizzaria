using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPizzaria
{
   class Conexao
    {
        MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=dbpizza;user=root;pwd=12345678"); //Instanciando MySQL Connection

        public static string msg;

        public MySqlConnection ConnectarBD()
        {
            //Tratamento de erro

            try
            {
                con.Open();

            }
            catch (Exception erro)
            {

                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return con;
        }

        public MySqlConnection DesConnectarBD()
        {
            try
            {
                con.Close();

            }
            catch (Exception erro)
            {

                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return con;
        }
    }
}
