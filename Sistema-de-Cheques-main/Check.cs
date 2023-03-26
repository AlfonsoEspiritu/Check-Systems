using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.AxHost;

namespace Sistema_de_Cheques
{
    internal class Check
    {
        public int Id { get; set; }
        public string Invoice { get; set; }
        public decimal Mount { get; set; }
        public DateTime Date { get; set; }
        public int Beneficiary { get; set; }
        public int Concept { get; set; }
        public int Account { get; set; }
        public bool State { get; set; }

        private DataBaseConnection dataBase = new DataBaseConnection();

        private Account account = new Account();

        public Check() { }

        public Check(int id, string invoice, decimal mount, DateTime date, int beneficiary, int concept, int account, bool state)
        {
            Id = id;
            Invoice = invoice;
            Mount = mount;
            Date = date;
            Beneficiary = beneficiary;
            Concept = concept;
            Account = account;
            State = state;
        }

        /*
            Metodo para agregar un nuevo beneficiario a la base de datos
        */
        private int GetLastInvoice()
        {

            //  SELECT COUNT(id), 
            //(SELECT TOP 1 invoice FROM[Checks] WHERE account = 1 order by id desc), 
            //(SELECT firstInvoice FROM[Accounts] WHERE id = 1), 
            //(SELECT lastInvoice FROM[Accounts] WHERE id = 1) 
            //FROM[Checks] WHERE account = 1;

            string query = "SELECT COUNT(id)," +
                            $"(SELECT TOP 1 invoice FROM [Checks] WHERE account = {User.ActiveAccount.Id} order by id desc)," +
                            $"(SELECT firstInvoice FROM [Accounts] WHERE id = {User.ActiveAccount.Id})," +
                            $"(SELECT lastInvoice FROM [Accounts] WHERE id = {User.ActiveAccount.Id})" +
                            $"FROM [Checks] WHERE account = {User.ActiveAccount.Id};";

            SqlCommand command = new SqlCommand(query, dataBase.Connection);
            try
            {
                dataBase.Connection.Open();
                command.CommandText = query;
                SqlDataReader checksSQL = command.ExecuteReader();
                int total = 0;
                int lastCheck = 0;
                int firstInvoice = 0;
                int lastInvoice = 0;
                if (checksSQL != null)
                {
                    while (checksSQL.Read())
                    {
                        // id, nombre, dirección, telefono, descripcion, estado
                        total = checksSQL.GetInt32(0);
                        lastCheck = total != 0 ? int.Parse(checksSQL.GetString(1)) : 0;
                        firstInvoice = checksSQL.GetInt32(2);
                        lastInvoice = checksSQL.GetInt32(3);
                    }
                }
                if (lastCheck == lastInvoice) return -1;

                return firstInvoice + total;
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
            return -1;
        }

        /**
            Método usado para crear un cheque dentro de la base de datos
         */
        public void CreateCheckSQL(decimal mount, DateTime date, int beneficiary, int concept)
        {
            int invoice = GetLastInvoice();
            if (invoice == -1)
            {
                MessageBox.Show(
                    $"Haz llegado al limite de tu chequera",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }
            string query = "INSERT INTO [Checks] values (" +
                        $"'{invoice}'," +
                        $"{beneficiary}," +
                        $"{mount}," +
                        $"'{date.Year}-{date.Month}-{date.Day}'," +
                        $"1," +
                        $"{User.ActiveAccount.Id}," +
                        $"{concept});";

            //string query = "INSERT INTO [CHECKS] VALUES ('2', 1, 80, '2023/12/28', 1, 1, 1)";
            SqlCommand command = new SqlCommand(query, dataBase.Connection);
            try
            {
                dataBase.Connection.Open();
                command.CommandText = query;
                command.ExecuteNonQuery();
                MessageBox.Show(
                    $"Cheque registrado exitosamente",
                    "Registro de cheques",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                account.MakeDeposit(-mount);
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
            Metodo que retorna una lista con todos los cheques registrado
         */
        public List<Check> GetChecksSLQ()
        {
            string query = $"SELECT *  FROM [Checks] WHERE account = {User.ActiveAccount.Id}";
            SqlCommand command = new SqlCommand(query, dataBase.Connection);
            List<Check> chekcs = new List<Check>();
            try
            {
                dataBase.Connection.Open();
                command.CommandText = query;
                SqlDataReader checksSQL = command.ExecuteReader();
                if (checksSQL != null)
                {
                    while (checksSQL.Read())
                    {
                        // id, nombre, dirección, telefono, descripcion, estado
                        int id = checksSQL.GetInt32(0);
                        string invoice = checksSQL.GetString(1);
                        int beneficiary = checksSQL.GetInt32(2);
                        decimal mount = checksSQL.GetDecimal(3);
                        DateTime date = checksSQL.GetDateTime(4);
                        bool state = checksSQL.GetBoolean(5);
                        int account = checksSQL.GetInt32(6);
                        int concept = checksSQL.GetInt32(7);
                        chekcs.Add(new Check(id, invoice, mount, date, beneficiary, concept, account, state));
                    }
                }
                return chekcs;
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
            return chekcs;
        }

        /**
            Metodo para obtener una lista de cheques en base a filtros
            Filtros disponibles:
                'id': busca en base al id ingresado
                'name': busca un nombre que coincida con la cadena ingresada
                'phone': busca un numero de telefono que coincida con la cadena ingresada
                'active': busca en base al estado ingresado
        */
        public List<Check> GetChecksByValuesSQL(List<string> filters, string benficiary, string[] mounts, DateTime[] dates, string[] invoices, string concept)
        {
            List<string> actualFilters = new List<string>();
            if (filters.Contains("beneficiary")) actualFilters.Add($"(beneficiary = {benficiary})");
            if (filters.Contains("concept")) actualFilters.Add($"(concept = {concept})");
            if (filters.Contains("mount")) actualFilters.Add($"(mount >= {mounts[0]} AND mount <= {mounts[1]})");
            if (filters.Contains("invoice")) actualFilters.Add($"(invoice >= {invoices[0]} AND invoice <= {invoices[1]})");
            if (filters.Contains("date")) actualFilters.Add($"(date >= '{dates[0].Year}-{dates[0].Month}-{dates[0].Day}' AND date <= '{dates[1].Year}-{dates[1].Month}-{dates[1].Day}')");

            string query = "SELECT* FROM [Checks] WHERE ";

            if (actualFilters.Count > 0)
            {
                for (int i = 0; i < actualFilters.Count; i++) 
                {
                    query += $"{actualFilters[i]} AND ";
                }
            }

            query += $"account = {User.ActiveAccount.Id}";
            SqlCommand command = new SqlCommand(query, dataBase.Connection);
            List<Check> checks = new List<Check>();
            try
            {
                dataBase.Connection.Open();
                command.CommandText = query;
                SqlDataReader checksSQL = command.ExecuteReader();
                if (checksSQL != null)
                {
                    MessageBox.Show(query);
                    while (checksSQL.Read())
                    {
                        // id, invoice, beneficiary, mount, date, state, account, concept,
                        int id = checksSQL.GetInt32(0);
                        string invoice = checksSQL.GetString(1);
                        int beneficiary = checksSQL.GetInt32(2);
                        decimal mount = checksSQL.GetDecimal(3);
                        DateTime date = checksSQL.GetDateTime(4);
                        bool state = checksSQL.GetBoolean(5);
                        int account = checksSQL.GetInt32(6);
                        int conceptInt = checksSQL.GetInt32(7);
                        checks.Add(new Check(id, invoice, mount, date, beneficiary, conceptInt, account, state));
                    }
                }
                return checks;
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
            return checks;
        }

        /**
            Metodo para obtener un beneficiario en base a su Id
        */
        public Check GetCheckSQL(int id)
        {
            string query = $"SELECT *  FROM [Checks] WHERE [id]={id};";
            SqlCommand command = new SqlCommand(query, dataBase.Connection);
            Check check = null;
            try
            {
                dataBase.Connection.Open();
                command.CommandText = query;
                SqlDataReader checksSQL = command.ExecuteReader();
                if (checksSQL != null)
                {
                    while (checksSQL.Read())
                    {
                        // id, invoice, beneficiary, mount, date, state, account, concept
                        string invoice = checksSQL.GetString(1);
                        int beneficiary = checksSQL.GetInt32(2);
                        decimal mount = checksSQL.GetDecimal(3);
                        DateTime date = checksSQL.GetDateTime(4);
                        bool state = checksSQL.GetBoolean(5);
                        int account = checksSQL.GetInt32(6);
                        int concept = checksSQL.GetInt32(7);

                        check = new Check(id, invoice, mount, date, beneficiary, concept, account, state);
                    }
                }
                return check;
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
            return check;
        }

        /**
           Metodo usado para actualizar los datos de un cheque
       */
        public void UpdateCheck(Check checkUpdated)
        {
            string query = $"UPDATE[Checks] SET" +
                           $"[beneficiary] = {checkUpdated.Beneficiary}, " +
                           $"[date] = '{checkUpdated.Date.Year}-{checkUpdated.Date.Month}-{checkUpdated.Date.Day}',  " +
                           $"[concept] = {checkUpdated.Concept}, " +
                           $"[mount] = {checkUpdated.Mount}, " +
                           $"[state] = '{checkUpdated.State}' WHERE[id] = {checkUpdated.Id}; ;";
            SqlCommand command = new SqlCommand(query, dataBase.Connection);
            try
            {
                dataBase.Connection.Open();
                command.CommandText = query;
                command.ExecuteNonQuery();
                MessageBox.Show(
                    $"Cheque con folio '{checkUpdated.Invoice}' actualizado exitosamente",
                    "Registro de cheques",
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
