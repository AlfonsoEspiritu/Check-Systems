using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Sistema_de_Cheques
{
    internal class Beneficiary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        private DataBaseConnection dataBase = new DataBaseConnection();


        public Beneficiary() { }

        public Beneficiary(int id, string name, string address, string phone, string description, bool active) 
        { 
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Description = description;
            Active = active;
        }

        /**
            Metodo para agregar un nuevo beneficiario a la base de datos
        */
        public void CreateBeneficiarySQL(string name, string address, string phone, string description)
        {
            string query = "INSERT INTO [Beneficiaries] values (" +
                        $"'{name}'," +
                        $"'{address}'," +
                        $"'{phone}'," +
                        $"'{description}'," +
                        $"1);";
            SqlCommand command = new SqlCommand(query, dataBase.Connection);
            try
            {
                dataBase.Connection.Open();
                command.CommandText = query;
                command.ExecuteNonQuery();
                MessageBox.Show(
                    $"Beneficiario '{name}' registrado exitosamente",
                    "Registro de beneficiarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
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
        }

        /*
            Metodo para obtener una lista con todos los beneficiarios registrados
        */
        public List<Beneficiary> GetBeneficiariesSLQ()
        {
            string query = "SELECT *  FROM [Beneficiaries]";
            SqlCommand command = new SqlCommand(query, dataBase.Connection);
            List<Beneficiary> beneficiaries = new List<Beneficiary>();
            try
            {
                dataBase.Connection.Open();
                command.CommandText = query;
                SqlDataReader beneficiariesSQL = command.ExecuteReader();
                if (beneficiariesSQL != null )
                {
                    while(beneficiariesSQL.Read())
                    {
                        // id, nombre, dirección, telefono, descripcion, estado
                        int id = beneficiariesSQL.GetInt32(0);
                        string name = beneficiariesSQL.GetString(1);
                        string address = beneficiariesSQL.GetString(2);
                        string phone = beneficiariesSQL.GetString(3);
                        string description = beneficiariesSQL.GetString(4);
                        bool active = beneficiariesSQL.GetBoolean(5);
                        beneficiaries.Add(new Beneficiary(id, name, address, phone, description, active));
                    }
                }
                return beneficiaries;
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
            return beneficiaries;
        }

        /**
            Metodo para obtener un beneficiario en base a su Id
        */
        public Beneficiary GetBeneficiarySQL(int id)
        {
            string query = $"SELECT *  FROM [Beneficiaries] WHERE [Id]='{id}';";
            SqlCommand command = new SqlCommand(query, dataBase.Connection);
            Beneficiary beneficiary = null;
            try
            {
                dataBase.Connection.Open();
                command.CommandText = query;
                SqlDataReader beneficiariesSQL = command.ExecuteReader();
                if (beneficiariesSQL != null)
                {
                    while (beneficiariesSQL.Read())
                    {
                        // id, nombre, dirección, telefono, descripcion, estado
                        string name = beneficiariesSQL.GetString(1);
                        string address = beneficiariesSQL.GetString(2);
                        string phone = beneficiariesSQL.GetString(3);
                        string description = beneficiariesSQL.GetString(4);
                        bool active = beneficiariesSQL.GetBoolean(5);
                        beneficiary = new Beneficiary(id, name, address, phone, description, active);
                    }
                }
                return beneficiary;
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
            return beneficiary;
        }

        /**
            Metodo para obtener una lista de beneficiarios en base a un filtro
            Filtros disponibles:
                'id': busca en base al id ingresado
                'name': busca un nombre que coincida con la cadena ingresada
                'phone': busca un numero de telefono que coincida con la cadena ingresada
                'active': busca en base al estado ingresado
        */
        public List<Beneficiary> GetBeneficiariesByValuesSQL(string searchValue, string filter)
        {
            //SELECT* FROM[Beneficiaries] WHERE[Id] = '6' OR[Name] LIKE '%DS%' OR[Phone] LIKE '%4%' OR[Active] = '0';
            string query = "";

            if (filter.Equals("id")) query = $"SELECT* FROM [Beneficiaries] WHERE [Id] = '{searchValue}'";
            if (filter.Equals("name"))
            {
                query = $"SELECT* FROM [Beneficiaries] WHERE [Name] LIKE '%{searchValue}%'";
                if (searchValue.Equals("")) query = $"SELECT* FROM [Beneficiaries] WHERE [Name] = '{searchValue}'";
            }
            if (filter.Equals("phone"))
            {
                query = $"SELECT* FROM [Beneficiaries] WHERE [Phone] LIKE '%{searchValue}%'";
                if (searchValue.Equals("")) query = $"SELECT* FROM [Beneficiaries] WHERE [Phone] = '{searchValue}'";
            }
            if (filter.Equals("active")) query = $"SELECT* FROM [Beneficiaries] WHERE [active] = '{searchValue}'";

            SqlCommand command = new SqlCommand(query, dataBase.Connection);
            List<Beneficiary> beneficiaries = new List<Beneficiary>();
            try
            {
                dataBase.Connection.Open();
                command.CommandText = query;
                SqlDataReader beneficiariesSQL = command.ExecuteReader();
                if (beneficiariesSQL != null)
                {
                    while (beneficiariesSQL.Read())
                    {
                        // id, nombre, dirección, telefono, descripcion, estado
                        int id = beneficiariesSQL.GetInt32(0);
                        string name = beneficiariesSQL.GetString(1);
                        string address = beneficiariesSQL.GetString(2);
                        string phone = beneficiariesSQL.GetString(3);
                        string description = beneficiariesSQL.GetString(4);
                        bool active = beneficiariesSQL.GetBoolean(5);
                        beneficiaries.Add(new Beneficiary(id, name, address, phone, description, active));
                    }
                }
                return beneficiaries;
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
            return beneficiaries;
        }

        /**
            Metodo usado para actualizar los datos de un beneficiario
        */
        public void UpdateBeneficiary(Beneficiary beneficiaryUpdated)
        {
            string query = $"UPDATE[Beneficiaries] SET" +
                           $"[name] = '{beneficiaryUpdated.Name}', " +
                           $"[Address] = '{beneficiaryUpdated.Address}',  " +
                           $"[Phone] = '{beneficiaryUpdated.Phone}', " +
                           $"[description] = '{beneficiaryUpdated.Description}', " +
                           $"[active] = '{beneficiaryUpdated.Active}' WHERE[id] = {beneficiaryUpdated.Id}; ;";
            SqlCommand command = new SqlCommand(query, dataBase.Connection);
            try
            {
                dataBase.Connection.Open();
                command.CommandText = query;
                command.ExecuteNonQuery();
                MessageBox.Show(
                    $"Beneficiario '{beneficiaryUpdated.Name}' actualizado exitosamente",
                    "Registro de beneficiarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
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
        }
    }
}
