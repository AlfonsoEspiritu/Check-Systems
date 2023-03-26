using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Cheques
{
    internal class DataBaseConnection
    {
        public string ConnectionData { get; set; }
        public string Source { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string DBName { get; set; }

        public SqlConnection Connection;

        public DataBaseConnection()
        {
            //this.Source = "DESKTOP-DT39M66\\SQLEXPRESS";
            //this.User = "david";
            //this.Password = "123";
            this.Source = "DESKTOP-5JB90L7\\SQLEXPRESS";
            this.User = "paco";
            this.Password = "1234";
            this.DBName = "SistemaDeCheques";
            ConnectionData = $"Data Source={Source};Initial Catalog={DBName};User ID={User};Password={Password}";
            Connection = new SqlConnection(ConnectionData);
        }


        /**
            Metodo que verifica el estado de la conexión a la base de datos
        */
        public string VerifyConnection()
        {
            try
            {
                Connection.Open();
                Connection.Close();
                return "Todo OK";
            }
            catch (Exception ex)
            {
                return $"ERROR...\n{ex}";
            }
        }
    }
}
