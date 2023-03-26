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
	public partial class CreateAccount : Form
	{
		Account account = new Account();

		public CreateAccount()
		{
			InitializeComponent();
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnActualizar_Click(object sender, EventArgs e)
		{
			if (!AccountValidations()) return;

			string name = txtName.Text;
			decimal mount = decimal.Parse(txtMount.Text);
			string bankName = txtBankName.Text;
			string accountNumber = txtAccountNumber.Text;
			int firstInvoice = int.Parse(txtFirstInvoice.Text);
			int lastInvoice = int.Parse(txtLastInvoice.Text);


            if (!account.CreateAccount(mount, name, bankName, accountNumber, firstInvoice, lastInvoice))
			{
				MessageBox.Show(
					"La cuenta no pudo ser creada",
					"Registro incorrecto",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}
			MessageBox.Show(
				"Cuenta creada correctamente",
				"Registro correcto",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
			this.Close();

		}

		private bool AccountValidations()
		{
			decimal deposit = 0;
            if (!decimal.TryParse(txtMount.Text, out deposit))
            {
                MessageBox.Show(
                    "Monto inicial invalido",
                    "Problema en el registro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                CleanTextBoxes();
                return false;
            }

			if(!HelperMethods.IsNumeric(txtAccountNumber.Text))
			{
				MessageBox.Show(
					"Número de cuenta invalido",
					"Problema en el registro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				CleanTextBoxes();
				return false;
			}

            if (!HelperMethods.IsNumeric(txtFirstInvoice.Text) || !HelperMethods.IsNumeric(txtLastInvoice.Text))
            {
                MessageBox.Show(
                    "Los folios deben ser númericos",
                    "Problema en el registro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                CleanTextBoxes();
                return false;
            }

			if(int.Parse(txtFirstInvoice.Text) >= int.Parse(txtLastInvoice.Text))
			{
                MessageBox.Show(
					"El folio inicial debe ser menor al folio final",
					"Problema en el registro",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
                CleanTextBoxes();
                return false;
            }

            return true;
		}

		private void CleanTextBoxes()
		{
			txtAccountNumber.Text = "";
			txtMount.Text = "";
			txtBankName.Text = "";
			txtName.Text = "";
			txtFirstInvoice.Text = "";
			txtLastInvoice.Text = "";
		}

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtBankName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtFirstInvoice_TextChanged(object sender, EventArgs e)
        {

        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {

        }
    }
}
