using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Cheques
{
    public partial class SignUpPage : Form
    {
        public SignUpPage()
        {
            InitializeComponent();

        }

        // Placeholders para los TextBoxes
        string phUsername = "Usuario";
        string phPassword = "Contraseña";
        string phConfirmPassword = "Confirmar contraseña";

        DataBaseConnection dataBase = new DataBaseConnection();
        private User user = new User();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            HelperMethods.placeholderController(txtUsename, phUsername);

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            HelperMethods.placeholderController(txtUsename, phUsername);
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            HelperMethods.placeholderController(txtPassword, phPassword);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            HelperMethods.placeholderController(txtPassword, phPassword);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            HelperMethods.placeholderController(txtConfirmPassword, phConfirmPassword);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            HelperMethods.placeholderController(txtConfirmPassword, phConfirmPassword);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /*
            Metodo usado ejecutar el registro de un nuevo usuario
        */
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string username = txtUsename.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Verificación de que todos los TextBoxes tiene contenido
            if (!IsDataValid())
            {
                MessageBox.Show("Debes llenar todos los campos para poder continuar", 
                                "Problema en el registro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            if (user.IsUsernameAvailable(username))
            {
				MessageBox.Show("El nombre de usuario ya existe",
				                "Problema en el registro",
				                MessageBoxButtons.OK,
				                MessageBoxIcon.Error);
				CleanTextBoxes();
				return;
			}

            // Verifación de igualdad entre contraseñas
            if (!password.Equals(confirmPassword))
            {
                MessageBox.Show("Las contraseñas ingresadas son diferentes",
                                "Problema en el registro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                CleanTextBoxes();
                return;
            }

            // Verificación de saldo inicial valido        
            //if (!HelperMethods.IsNumeric(initialState))
            //{
            //    MessageBox.Show("El saldo inicial debe ser numerico",
            //                    "Problema en el registro",
            //                    MessageBoxButtons.OK,
            //                    MessageBoxIcon.Error);
            //    HelperMethods.placeholderDesign(txtInitialState, phInitialState);
            //    txtInitialState.Focus();
            //    return;
            //}
            if (!user.CreateUser(username, password)) return;

            this.Close();
        }

        /*
            Metodo usado para limpiar los campos del formulario
        */
        private void CleanTextBoxes()
        {
			HelperMethods.placeholderDesign(txtUsename, phUsername);
			HelperMethods.placeholderDesign(txtPassword, phPassword);
            txtPassword.UseSystemPasswordChar = false;
            HelperMethods.placeholderDesign(txtConfirmPassword, phConfirmPassword);
            txtConfirmPassword.UseSystemPasswordChar = false;
        }

        /*
            Metodo usado para validar que los campos del formulario esten completos
        */
        private bool IsDataValid()
        {
            bool verification = txtPassword.Text.Contains(phPassword)
                                || txtConfirmPassword.Text.Contains(phConfirmPassword)
                                || txtUsename.Text.Contains(phUsername);
            return !verification;
        }
    }
}
