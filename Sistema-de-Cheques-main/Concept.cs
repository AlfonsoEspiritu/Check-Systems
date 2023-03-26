using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Cheques
{
    internal class Concept
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private DataBaseConnection dataBase = new DataBaseConnection();

        public Concept() { }

        public Concept(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /*
            Metodo para agregar un nuevo concepto a la base de datos
        */
        public void CreateConceptSQL(string name)
        {
            string query = "INSERT INTO [Concepts] values (" +
                        $"'{name}');";
            SqlCommand command = new SqlCommand(query, dataBase.Connection);
            try
            {
                dataBase.Connection.Open();
                command.CommandText = query;
                command.ExecuteNonQuery();
                MessageBox.Show(
                    $"Concepto '{name}' registrado exitosamente",
                    "Registro de conceptos",
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
            Metodo que retorna una lista con todos los conceptos registrados
        */
        public List<Concept> GetConceptsSLQ()
        {
            string query = "SELECT *  FROM [Concepts]";
            SqlCommand command = new SqlCommand(query, dataBase.Connection);
            List<Concept> concepts = new List<Concept>();
            try
            {
                dataBase.Connection.Open();
                command.CommandText = query;
                SqlDataReader conceptsSQL = command.ExecuteReader();
                if (conceptsSQL != null)
                {
                    while (conceptsSQL.Read())
                    {
                        // id, nombre
                        int id = conceptsSQL.GetInt32(0);
                        string name = conceptsSQL.GetString(1);
                        concepts.Add(new Concept(id, name));
                    }
                }
                return concepts;
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
            return concepts;
        }

        /**
            Metodo que retorna un concepto en base al Id ingresado
        */
        public Concept GetConceptSQL(int id)
        {
            string query = $"SELECT *  FROM [Concepts] WHERE [Id]='{id}';";
            SqlCommand command = new SqlCommand(query, dataBase.Connection);
            Concept concept = null;
            try
            {
                dataBase.Connection.Open();
                command.CommandText = query;
                SqlDataReader conceptsSQL = command.ExecuteReader();
                if (conceptsSQL != null)
                {
                    while (conceptsSQL.Read())
                    {
                        // id, nombre, dirección, telefono, descripcion, estado
                        string name = conceptsSQL.GetString(1);
                        concept = new Concept(id, name);
                    }
                }
                return concept;
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
            return concept;
        }
    }
}
