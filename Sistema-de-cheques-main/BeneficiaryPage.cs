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
    public partial class BeneficiaryPage : Form
    {
        Beneficiary beneficiary = new Beneficiary();

        public BeneficiaryPage()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            UpdateBeneficiariesTable();
        }

        /**
            Metodo usado para realizar el registro de un beneficiario 
        */
        

        /**
            Metodo ejecutar la limpieza del formulario de beneficiario
        */
        private void btnDepositar_Click(object sender, EventArgs e)
        {
            CleanTextBoxes();
        }

        /**
            Metodo para desplegar la ventana de busqueda de beneficiarios
        */
        private void button1_Click(object sender, EventArgs e)
        {
            SearchBeneciaryPage frmDos = new SearchBeneciaryPage();
            frmDos.ShowDialog();
        }

        /**
            Metodo acciona la actualización de datos de un beneficiario
        */
        public void UpdateBeneficiariesTable()
        {
            beneficiariesTable.Rows.Clear();
            foreach (Beneficiary beneficiarySQL in beneficiary.GetBeneficiariesSLQ())
            {
                int fila = beneficiariesTable.Rows.Add();
                beneficiariesTable.Rows[fila].Cells[0].Value = beneficiarySQL.Id;
                beneficiariesTable.Rows[fila].Cells[1].Value = beneficiarySQL.Name;
                beneficiariesTable.Rows[fila].Cells[2].Value = beneficiarySQL.Address;
                beneficiariesTable.Rows[fila].Cells[3].Value = beneficiarySQL.Active ? "Activo" : "Inactivo";
            }
        }

        /**
            Metodo que limpia los campos del formulario de la pagina
        */
        private void CleanTextBoxes()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtDescription.Text = "";
            txtPhone.Text = "";
        }

        /**
            Metodo que valida que los campos del formulario no esten vacios
        */
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

        /**
            Metodo usado para validar si el usuario desea modificar al usuario seleccionada,
            de ser así deplega el formulario de actualización
        */
        private void beneficiariesTable_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = beneficiariesTable.Rows[e.RowIndex];
            int id = int.Parse(row.Cells[0].Value.ToString());
            string name = row.Cells[1].Value.ToString();

            DialogResult result = MessageBox.Show(
                $"¿Quieres ver los datos del beneficiario?\n" +
                $"Nombre: {name}",
                "Datos registrados",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            if (result.ToString().Equals("Yes"))
            {
                UpdateBenefiaryPage updateBenefiary = new UpdateBenefiaryPage(id, this);
                updateBenefiary.Show();
            }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (!IsDataValid()) return;
            beneficiary.CreateBeneficiarySQL(txtName.Text, txtAddress.Text, txtPhone.Text, txtDescription.Text);
            CleanTextBoxes();

            //Actualizar tabla de beneficiarios
            UpdateBeneficiariesTable();
        }
    }




}




