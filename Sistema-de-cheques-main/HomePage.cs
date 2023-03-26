using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Cheques
{
    public partial class HomePage : Form
    {
       
        public HomePage()
        {
            InitializeComponent();
            //Estas lineas eliminan los parpadeos del formulario o controles en la interfaz grafica (Pero no en un 100%)
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            IniLabel();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            button6_Click(null, e);
        }

        #region Funcionalidades del formulario

        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(0,0,0));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        

        private void panelBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; 
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirForm(new AccountPage());
           // AbrirFormulario<AccountPage>();
           // CerrarTodosLosFormulariosAbiertos();
            btnCuenta.BackColor = Color.FromArgb(82, 97, 48);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (User.ActiveAccount == null)
            {
                MessageBox.Show(
                    $"Debes seleccionar una cuenta para poder continuar",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
               // AbrirForm(new SelectAccount(this));
                return;
            }
            AbrirForm(new BeneficiaryPage());
           // AbrirFormulario<BeneficiaryPage>();
            //CerrarTodosLosFormulariosAbiertos();
            btnBene.BackColor = Color.FromArgb(82, 97, 48);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (User.ActiveAccount == null)
            {
                MessageBox.Show(
                    $"Debes seleccionar una cuenta para poder continuar",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
               // AbrirForm(new SelectAccount(this));
                return;
            }
            AbrirForm(new CheckPage());
            // AbrirFormulario<CheckPage>();
            // CerrarTodosLosFormulariosAbiertos();
            btnCheques.BackColor = Color.FromArgb(82, 97, 48);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirForm(new Form4());
            //AbrirFormulario<Form4>();
          //  CerrarTodosLosFormulariosAbiertos();
            button4.BackColor = Color.FromArgb(82,97,48);
        }

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion 

        
        //Abrir Formularios y cerrar los que estén abiertos
        private Form activeForm;
        private void AbrirForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelFormularios.Controls.Add(childForm);
            panelFormularios.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            childForm.FormClosed += new FormClosedEventHandler(closedForm);
        }

        private void panelFormularios_Paint(object sender, PaintEventArgs e)
        {

        }

        /*
            Metodo para cambiar el color de los botones de opciones se les da clic
        */
        private void closedForm(object sender, FormClosedEventArgs e) {
            if (Application.OpenForms["AccountPage"] == null)
            {
                btnCuenta.BackColor = Color.FromArgb(128, 151, 75);
            }
            if (Application.OpenForms["BeneficiaryPages"] == null)
            {
                btnBene.BackColor = Color.FromArgb(128, 151, 75);
            }
            if (Application.OpenForms["CheckPage"] == null)
            {
                btnCheques.BackColor = Color.FromArgb(128, 151, 75);
            }
            if (Application.OpenForms["Form4"] == null)
            {
                button4.BackColor = Color.FromArgb(128, 151, 75);
            }
            if (Application.OpenForms["Inicio"] == null)
            {
                button6.BackColor= Color.FromArgb(128, 151, 75);
            }

        }
        private void CerrarTodosLosFormulariosAbiertos()
        {
            // Crear una copia de la colección de formularios abiertos
            Form[] formularios = Application.OpenForms.Cast<Form>().ToArray();

            // Iterar a través de la copia de la colección de formularios abiertos
            foreach (Form formulario in formularios)
            {
                // Comprobar si el formulario no ha sido eliminado y no es el formulario principal
                if (!formulario.IsDisposed && formulario.Name != "HomePage")
                {
                    // Cerrar el formulario
                    formulario.Close();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
           // AbrirForm(new SelectAccount(this));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirForm(new CreateAccount());
        }

        public void IniLabel()
        {
            lbActualUser.Text = User.ActiveAccount != null ? $"Cuenta activa: {User.ActiveAccount.Name}" : $"Selecciona una cuenta";
        }

        private void lbActualUser_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirForm(new Inicio(this));
            btnCuenta.BackColor = Color.FromArgb(82, 97, 48);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

        }
    }
}
