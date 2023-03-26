using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Sistema_de_Cheques
{
    internal class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }

		public Account() { }

        public Account(int id, string name, decimal balance, string bankName, string accountNumber)
        {
            this.Id = id;
			this.Name = name;
            this.Balance = balance;
            this.Name = name;
			this.BankName = bankName;
			this.AccountNumber = accountNumber;
        }

        private DataBaseConnection dataBase = new DataBaseConnection();

        /**
            Metodo para aumentar o diminuir el balance de una cuenta
        */
        public void MakeDeposit(decimal total)
        {
			User.ActiveAccount.Balance += total;
            string query = $"UPDATE [Accounts] SET [balance] = {User.ActiveAccount.Balance} WHERE [id]='{User.ActiveAccount.Id}';";
            SqlCommand command = new SqlCommand(query, dataBase.Connection);
            try
            {
                dataBase.Connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ocurrio un error",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            finally
            {
                dataBase.Connection.Close();
            }

        }

		/**
			Método para registrar una cuenta dentro de la base de datos 
		*/
        public bool CreateAccount(decimal balance, string name, string bankName, string bankNumber, int firstInvoice, int lastInvoice)
        {
			//INSERT INTO[Accounts] values('nombre', 999999, 999999, 'bankname', 'banknumber', 2);
			string query = "INSERT INTO [Accounts] values (" +
						$"'{name}'," +
						$"{balance}," +
                        $"{balance}," +
                        $"'{bankName}'," +
                        $"'{bankNumber}'," +
                        $"{User.Id}," +
						$"{firstInvoice}," +
						$"{lastInvoice});";
			SqlCommand command = new SqlCommand(query, dataBase.Connection);
			try
			{
				dataBase.Connection.Open();
				command.CommandText = query;
				command.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Sin información {ex}",
					"",
					MessageBoxButtons.OK
				);
			}
			finally
			{
				dataBase.Connection.Close();
			}
			return false;
		}

        /**
			Método para obtener una lista con todos los usuarios registrados dentro 
			de la base de datos
		*/
        public List<Account> GetAccountsSLQ()
		{
			string query = $"SELECT [id], [name], [balance], [bankName], [bankNumber] FROM [Accounts] where [Owner] = {User.Id}";
			SqlCommand command = new SqlCommand(query, dataBase.Connection);
			List<Account> accounts = new List<Account>();
			try
			{
				dataBase.Connection.Open();
				command.CommandText = query;
				SqlDataReader accountsSQL = command.ExecuteReader();
				if (accountsSQL != null)
				{
					while (accountsSQL.Read())
					{
						// id, nombre, dirección, telefono, descripcion, estado
						int id = accountsSQL.GetInt32(0);
						string name = accountsSQL.GetString(1);
						decimal balance = accountsSQL.GetDecimal(2);
						string bankName = accountsSQL.GetString(3);
						string accountNumber = accountsSQL.GetString(4);
						accounts.Add(new Account(id, name, balance, bankName, accountNumber));
					}
				}
				return accounts;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Error, {ex}",
					"",
					MessageBoxButtons.OK
				);
			}
			finally
			{
				dataBase.Connection.Close();
			}
			return accounts;
		}

        /**
			Método para actualizar los datos de una cuenta dentro de la base de datos
		*/
        public bool UpdateAccount(Account accountUpdated)
		{
			string query = $"UPDATE[Accounts] SET" +
						   $"[name] = '{accountUpdated.Name}', " +
						   $"[bankName] = '{accountUpdated.BankName}',  " +
						   $"[bankNumber] = '{accountUpdated.AccountNumber}' " +
						   $"WHERE [id] = {accountUpdated.Id}; ;";
			SqlCommand command = new SqlCommand(query, dataBase.Connection);
			try
			{
				dataBase.Connection.Open();
				command.CommandText = query;
				command.ExecuteNonQuery();
				MessageBox.Show(
					$"Cuenta de '{accountUpdated.Name}' actualizada exitosamente",
					"Registro de beneficiarios",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);
				User.ActiveAccount.Name = accountUpdated.Name;
				User.ActiveAccount.BankName = accountUpdated.BankName;
				User.ActiveAccount.AccountNumber = accountUpdated.AccountNumber;
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					$"Error, {ex}",
					"",
					MessageBoxButtons.OK
				);
			}
			finally
			{
				dataBase.Connection.Close();
			}
			return false;
		}
	}
}
