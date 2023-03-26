using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Sistema_de_Cheques
{
    public partial class UpdateCheck : Form
    {
        int checkId;
        Check check = new Check();
        Concept concept = new Concept();
        Beneficiary beneficiary = new Beneficiary();
        CheckPage checkPage;
        public UpdateCheck(int id)
        {
            InitializeComponent();
            this.checkId = id;
        }

        public UpdateCheck(CheckPage checkPage, int id)
        {
            InitializeComponent();
            this.checkPage = checkPage; 
            this.checkId = id;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            txtBeneficiary.Enabled = !txtBeneficiary.Enabled;
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            txtDate.Enabled = !txtDate.Enabled;
        }

        private void btnConcept_Click(object sender, EventArgs e)
        {
            txtConcept.Enabled = !txtConcept.Enabled;
        }

        private void btnMount_Click(object sender, EventArgs e)
        {
            txtMount.Enabled = !txtMount.Enabled;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!CheckValidations()) return;
            Check checkUpdated = check.GetCheckSQL(checkId);

            decimal actualMount = checkUpdated.Mount;
            decimal newMount = decimal.Parse(txtMount.Text);

            checkUpdated.Beneficiary = txtBeneficiary.SelectedIndex + 1;
            checkUpdated.Date = txtDate.Value;
            checkUpdated.Concept = txtConcept.SelectedIndex + 1;
            checkUpdated.Mount = newMount;
            checkUpdated.State = cbState.Checked;

            if (!SetBalance(actualMount, newMount)) return;

            check.UpdateCheck(checkUpdated);


            if (checkPage != null) checkPage.UpdateChecksTable();
            this.Close();
        }

        private bool SetBalance(decimal actualMount, decimal newMount)
        {
            Account account = new Account();

            decimal diference = actualMount - newMount;

            if (diference < 0 && User.ActiveAccount.Balance < Math.Abs(diference))
            {
                MessageBox.Show(
                    "El monto ingresado dejaria tu cuenta en negativos",
                    "Problema con la actualización",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            account.MakeDeposit(diference);

            return true;
        }

        private bool CheckValidations()
        {
            if (!HelperMethods.IsMoney(txtMount.Text))
            {
                MessageBox.Show(
                    "Solo puedes ingresar montos numericas",
                    "Problema con la actualización",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (txtConcept.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "No puedes dejar el cheque sin ningun concepto",
                    "Problema con la actualización",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            if (txtBeneficiary.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "No puedes dejar el cheque sin ningun beneficiario",
                    "Problema con la actualización",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void InitTextBoxes()
        {
            Check checkInit = check.GetCheckSQL(checkId);
            txtInvoice.Text = checkInit.Invoice.ToString();
            txtBeneficiary.SelectedIndex = checkInit.Beneficiary - 1;
            txtDate.Value = checkInit.Date;
            txtConcept.SelectedIndex = checkInit.Concept - 1;
            txtMount.Text = checkInit.Mount.ToString();
            cbState.Checked = checkInit.State;
        }

        private void UpdateCheck_Load(object sender, EventArgs e)
        {
            InitCBChecks();
            InitCBConcepts();
            InitTextBoxes();
        }


        /**
            Metodo que carga los conceptos disponibles dentro del combo box
        */
        private void InitCBConcepts()
        {
            txtConcept.Items.Clear();

            foreach (Concept concept in concept.GetConceptsSLQ())
            {
                txtConcept.Items.Add(concept.Name);
            }
        }


        /**
            Metodo que carga los beneficiarios disponibles dentro del combo box
        */
        public void InitCBChecks()
        {
            txtBeneficiary.Items.Clear();

            foreach (Beneficiary beneficiary in beneficiary.GetBeneficiariesSLQ())
            {
                int row = txtBeneficiary.Items.Add(beneficiary.Name);
            }
        }
    }
}
