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
    public partial class AccountPage : Form
    {
        public AccountPage()
        {
            InitializeComponent();
            InitTextBoxes();
        }

        /**
            Metodo para abrir la ventana que realiza los depositos
        */
        private void btnDepositar_Click(object sender, EventArgs e)
        {
            DepostiPage frmDos = new DepostiPage(this);
            frmDos.ShowDialog();
        }

        /**
            Metodo para actualizar la información desplegada en pantalla,
            colocando los datos del usuario loggeado
        */
        public void InitTextBoxes()
        {
            if (User.ActiveAccount != null)
            {
                txtSaldo.Text = User.ActiveAccount.Balance.ToString();
                txtName.Text = User.ActiveAccount.Name.ToString();
                txtBankName.Text = User.ActiveAccount.BankName.ToString();
            }
            txtUsername.Text = User.Username.ToString();
        }

		private void button1_Click(object sender, EventArgs e)
		{
            CreateAccount createAccount = new CreateAccount();
            createAccount.Show();
		}

		private void button2_Click(object sender, EventArgs e)
		{
            SelectAccount selectAccount = new SelectAccount(this);
            selectAccount.Show();
		}

		private void btnActualizar_Click(object sender, EventArgs e)
		{
            if (User.ActiveAccount == null)
            {
				MessageBox.Show(
					$"Necesitas seleccionar una cuenta para poder continuar",
					"Sin cuenta seleccionada",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
				);
                return;
			}
            UpdateAccount updateAccount = new UpdateAccount(this);
            updateAccount.Show();
		}
    }
}
