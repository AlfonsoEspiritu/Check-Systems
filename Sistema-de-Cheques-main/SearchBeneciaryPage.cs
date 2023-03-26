using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Sistema_de_Cheques
{
    public partial class SearchBeneciaryPage : Form
    {
        Dashboard dashboard;

        public SearchBeneciaryPage()
        {
            InitializeComponent();
        }

        public SearchBeneciaryPage(Dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }

        Beneficiary beneficiary = new Beneficiary();
        string phName = "Nombre del beneficiario";
        string phId = "Id";
        string phPhone = "Celular";

        /*
            Metodo usado cerrar la ventana actual
        */
        private void button2_Click(object sender, EventArgs e)
        {
            if (dashboard != null) dashboard.openChildForm(new BeneficiaryPage());
            this.Close();
        }

        /*
            Metodo usado para ejectar el filtro de busqueda basa en el "Id" de un beneficiario
        */
        private void btnSearch_Click(object sender, EventArgs e)
        {
            UpdateBeneficiariesTable("id");
            CleanTextBoxes();
        }

        /*
            Metodo usado para actualizar la tabla de beneficiarios
        */
        public void UpdateBeneficiariesTable(string filter)
        {
            // 1 = id, 2 = phone, 3 = name, 4 = active
            beneficiariesTable.Rows.Clear();
            string searchValue = "";

            if (filter.Equals("id")) searchValue = txtId.Text;
            if (filter.Equals("name")) searchValue = txtName.Text;
            if (filter.Equals("phone")) searchValue = txtPhone.Text;
            if (filter.Equals("active")) searchValue = checkBox1.Checked ? "1" : "0";

            foreach (Beneficiary beneficiarySQL in beneficiary.GetBeneficiariesByValuesSQL(searchValue, filter))
            {
                int fila = beneficiariesTable.Rows.Add();
                beneficiariesTable.Rows[fila].Cells[0].Value = beneficiarySQL.Id;
                beneficiariesTable.Rows[fila].Cells[1].Value = beneficiarySQL.Name;
                beneficiariesTable.Rows[fila].Cells[2].Value = beneficiarySQL.Address;
                beneficiariesTable.Rows[fila].Cells[3].Value = beneficiarySQL.Active ? "Activo" : "Inactivo";
            }
        }

        /*
            Metodo usado limpiar el formulario de busqueda
        */
        private void CleanTextBoxes()
        {
            txtName.Text = "";
            txtId.Text = "";
            txtPhone.Text = "";
            checkBox1.Checked = false;
        }

        /*
            Metodo usado para ejectar el filtro de busqueda basa en el "Nombre" de un beneficiario
        */
        private void btnSearchName_Click(object sender, EventArgs e)
        {
            UpdateBeneficiariesTable("name");
            CleanTextBoxes();
        }

        /*
            Metodo usado para ejectar el filtro de busqueda basa en el "Telefono" de un beneficiario
        */
        private void btnSeachrPhone_Click(object sender, EventArgs e)
        {
            UpdateBeneficiariesTable("phone");
            CleanTextBoxes();
        }

        /*
            Metodo usado para ejectar el filtro de busqueda basa en el "Estado" de un beneficiario
        */
        private void btnSearchActive_Click(object sender, EventArgs e)
        {
            UpdateBeneficiariesTable("active");
            CleanTextBoxes();
        }

		private void beneficiariesTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                this.Visible = false;
				updateBenefiary.Show();
			}
		}

        public void SetIdTextBox(string value)
        {
            txtId.Text = value;
        }
	}
}
