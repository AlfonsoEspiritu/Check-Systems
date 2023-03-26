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
    public partial class CreateBeneficiary : Form
    {
        public CheckPage checkPage;
        Beneficiary beneficiary = new Beneficiary();

        public CreateBeneficiary()
        {
            InitializeComponent();
        }

        public CreateBeneficiary(CheckPage checkPage)
        {
            InitializeComponent();
            this.checkPage = checkPage;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!IsDataValid()) return;
            beneficiary.CreateBeneficiarySQL(txtName.Text, txtAddress.Text, txtPhone.Text, txtDescription.Text);
            if (checkPage != null) checkPage.InitCBBeneficiaries();
            this.Close();
        }

        private bool IsDataValid()
        {
            if (!HelperMethods.IsNumeric(txtPhone.Text))
            {
                MessageBox.Show("El telefono debe tener formato numerico",
                "Problema en el registro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }


            bool verification = txtAddress.Text.Equals("")
                || txtDescription.Text.Equals("")
                || txtName.Text.Equals("")
                || txtPhone.Text.Equals("");

            if (verification)
            {
                MessageBox.Show("Debes llenar todos los campos para poder registrar un beneficiario",
                "Problema en el registro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
