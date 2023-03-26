using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sistema_de_Cheques
{
	internal class User
	{
		public static int Id { get; set; }
		public static string Username { get; set; }
		public static Account ActiveAccount { get; set; }

		private DataBaseConnection dataBase = new DataBaseConnection();

		/**
			Método para comprobar las credenciales de un usuario dentro de la
			base de datos
		*/
		public bool LogUser(string username, string password)
		{
			string query = $"SELECT [id], [username] FROM [Users] where username = '{username}' AND password = '{password}'";
			SqlCommand command = new SqlCommand(query, dataBase.Connection);
			try
			{
				dataBase.Connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				if (reader != null)
				{
					if (reader.Read())
					{
						HomePage homePage = new HomePage();
						User.Id = reader.GetInt32(0);
						User.Username = reader.GetString(1);
						return true;
					}
				}
				else
				{
					return false;
				}

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
			return false;
		}

        /**
			Método para crear/registrar un usario dentro de la base de datos
		*/
        public bool CreateUser(string username, string password)
		{
			string query = "INSERT INTO [Users] values (" +
						$"'{username}'," +
						$"'{password}');";
			SqlCommand command = new SqlCommand(query, dataBase.Connection);
			try
			{
				dataBase.Connection.Open();
				command.CommandText = query;
				command.ExecuteNonQuery();
				MessageBox.Show(
					$"Usuario '{username}' creado exitosamente",
					"Registro de usuario",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information
				);
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Sin información",
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
			Método usado para verificar si la disponibilidad de un nombre
			de usuario dentro de la base de datos
		*/
        public bool IsUsernameAvailable(string username)
		{
			string query = $"SELECT [username] FROM [Users] where username = '{username}'";
			SqlCommand command = new SqlCommand(query, dataBase.Connection);
			try
			{
				dataBase.Connection.Open();
				SqlDataReader reader = command.ExecuteReader();

				if (reader != null)
				{
					if (reader.Read())
					{
						return true;
					}
				}
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
			return false;
		}
	}
}
