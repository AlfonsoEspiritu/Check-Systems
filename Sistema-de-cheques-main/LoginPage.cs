using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using Microsoft.VisualBasic.ApplicationServices;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Sistema_de_Cheques
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private string phUsername = "Usuario";
        private string phPassword = "Contraseña";


		private User user = new User();
		DataBaseConnection dataBase = new DataBaseConnection();

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void RealeseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        /*
            Metodo usado que da formato de placeholder al TextBox
        */
        private void textBox1_Enter(object sender, EventArgs e)
        {
            HelperMethods.placeholderController(txtUser, phUsername);
        }

        /*
            Metodo usado que da formato de placeholder al TextBox
        */
        private void txtUser_Leave(object sender, EventArgs e)
        {
            HelperMethods.placeholderController(txtUser, phUsername);
        }

        /*
            Metodo usado que da formato de placeholder al TextBox
        */
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            HelperMethods.placeholderController(txtPassword, phPassword);
        }

        /*
            Metodo usado que da formato de placeholder al TextBox
        */
        private void txtPassword_Leave(object sender, EventArgs e)
        {
            HelperMethods.placeholderController(txtPassword, phPassword);
        }

        /*
            Metodo usado para detener la ejecución de la aplicación
        */
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*
            Metodo usado para minimizar la ventana actual
        */
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            RealeseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            RealeseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        /*
            Metodo usado desplegar el formulario de registro de usuario
        */
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpPage form2 = new SignUpPage();
            form2.Show();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }


        /*
            Metodo que valida los datos del inicio de sesión de un usuario
        */
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Verificar que todos los campos tengan texto
            if (!IsDataValid())
            {
                MessageBox.Show("Debes llenar todos los campos para poder continuar",
                                "Problema en el registro",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            string username = txtUser.Text;
            string password = txtPassword.Text;

            if (!user.LogUser(username, password))
            {
				MessageBox.Show("Usuario o contraseña incorrecto",
								"Problema en el inicio de sesión",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
                return;
			}
            //HomePage homePage= new HomePage();
            //this.Visible = false;
            //homePage.Show();
            Dashboard dash = new Dashboard();
            this.Visible= false;
            dash.Show();
        }


        /*
            Metodo que valida que los campos del formulario no esten vacios al iniciar sesión
        */
        private bool IsDataValid()
        {
            bool verification = txtUser.Text.Contains(phUsername)
                                || txtPassword.Text.Contains(phPassword);
            return !verification;
        }

        /*
            Metodo que limpia el formulario de inicio de sesión
        */
        private void CleanTextBoxes()
        {
            HelperMethods.placeholderDesign(txtUser, phUsername);
            HelperMethods.placeholderDesign(txtPassword, phPassword);
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }
    }
}