using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Cheques
{
	public partial class SelectAccount : Form
	{
		Account account = new Account();
		AccountPage accountPage;
		Dashboard homePage;

		public SelectAccount(Dashboard home)
		{
			InitializeComponent();
			this.homePage = home;
		}
		public SelectAccount(AccountPage accountPage)
		{
			InitializeComponent();
			this.accountPage = accountPage;
		}

        public SelectAccount()
        {
            InitializeComponent();
        }

        public void UpdateBeneficiariesTable()
		{
			accountsTable.Rows.Clear();
			foreach (Account accountSQL in account.GetAccountsSLQ())
			{
				int fila = accountsTable.Rows.Add();
				accountsTable.Rows[fila].Cells[0].Value = accountSQL.Name;
				accountsTable.Rows[fila].Cells[1].Value = accountSQL.Balance;
				accountsTable.Rows[fila].Cells[2].Value = accountSQL.BankName;
				accountsTable.Rows[fila].Cells[3].Value = accountSQL.AccountNumber;
				accountsTable.Rows[fila].Cells[4].Value = accountSQL.Id;

			}
		}

		private void SelectAccount_Load(object sender, EventArgs e)
		{
			UpdateBeneficiariesTable();
			if (User.ActiveAccount != null) labelAccount.Text = $"Cuenta activa: {User.ActiveAccount.Name}";
		}

		private void accountsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex < 0) return;
			DataGridViewRow row = accountsTable.Rows[e.RowIndex];
			string name = row.Cells[0].Value.ToString();
			decimal balance = decimal.Parse(row.Cells[1].Value.ToString());
			string bankName = row.Cells[2].Value.ToString();
			string accountNumber = row.Cells[3].Value.ToString();
			int id = int.Parse(row.Cells[4].Value.ToString());

			DialogResult result = MessageBox.Show(
				$"¿Quieres usar esta cuenta bancaria?\n" +
				$"Nombre: {name}\n" +
				$"Banco: {bankName}",
				"Datos registrados",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Information
			);

			if (result.ToString().Equals("Yes"))
			{
				User.ActiveAccount = new Account(id, name, balance, bankName, accountNumber);
				labelAccount.Text = $"Cuenta activa: {User.ActiveAccount.Name}";
				if (accountPage != null) accountPage.InitTextBoxes();
				//if (homePage != null) homePage.IniLabel();
				//this.Close();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

        private void button2_Click(object sender, EventArgs e)
        {
			CreateAccount createAccount = new CreateAccount();
			createAccount.Show();
        }

        private void labelAccount_Click(object sender, EventArgs e)
        {

        }
    }
}
