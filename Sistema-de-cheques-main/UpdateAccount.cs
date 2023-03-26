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
	public partial class UpdateAccount : Form
	{
		Account account = new Account();
		AccountPage accountPage;
		Dashboard dashboard = new Dashboard();

        public UpdateAccount()
        {
            InitializeComponent();
        }

        public UpdateAccount(Dashboard dashboard)
        {
            InitializeComponent();
			this.dashboard = dashboard;
        }
        public UpdateAccount(AccountPage accountPage)
		{
			InitializeComponent();
			this.accountPage = accountPage;
		}

		private void btnEditName_Click(object sender, EventArgs e)
		{
			txtName.Enabled = !txtName.Enabled;
		}

		private void btnEditBankName_Click(object sender, EventArgs e)
		{
			txtBankName.Enabled = !txtBankName.Enabled;
		}

		private void btnEditAccountNumber_Click(object sender, EventArgs e)
		{
			txtAccountNumber.Enabled = !txtAccountNumber.Enabled;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
            if (dashboard != null) dashboard.openChildForm(new AccountPage());
            this.Close();
		}

		private void InitTextBoxes()
		{
			if (User.ActiveAccount != null)
			{
				txtAccountNumber.Text = User.ActiveAccount?.AccountNumber;
				txtBankName.Text = User.ActiveAccount?.BankName;
				txtName.Text = User.ActiveAccount?.Name;
			}
		}

		private void UpdateAccount_Load(object sender, EventArgs e)
		{
			InitTextBoxes();
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			if (!AccountValidations()) return;
			string name = txtName.Text;
			string bankName = txtBankName.Text;
			string accountNumber = txtAccountNumber.Text;

			Account updatedAccount = new Account(User.ActiveAccount.Id, name, 0, bankName, accountNumber);

			account.UpdateAccount(updatedAccount);
			if (accountPage != null) accountPage.InitTextBoxes();
			if (dashboard != null) dashboard.openChildForm(new AccountPage());
			this.Close();
		}

		public bool AccountValidations()
		{
			decimal deposit = 0;
			if (!HelperMethods.IsNumeric(txtAccountNumber.Text))
			{
				MessageBox.Show(
					"El numero de cuenta debe tener formato numerico",
					"Problema en el deposito",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				txtAccountNumber.Text = "";
				return false;
			}

			if (txtName.Text.Equals("") || txtBankName.Equals("") || txtAccountNumber.Text.Equals(""))
			{
				MessageBox.Show(
					"El numero de cuenta debe tener formato numerico",
					"Problema en el deposito",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				txtAccountNumber.Text = "";
				return false;
			}
			return true;
		}

		private void txtName_Leave(object sender, EventArgs e)
		{
			txtName.Enabled = false;
		}

		private void txtBankName_Leave(object sender, EventArgs e)
		{
			txtBankName.Enabled = false;
		}

		private void txtAccountNumber_Leave(object sender, EventArgs e)
		{
			txtAccountNumber.Enabled = false;
		}
	}
}
