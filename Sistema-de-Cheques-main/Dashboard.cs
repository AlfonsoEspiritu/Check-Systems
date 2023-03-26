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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void customizeDesign()
        {
            panelInicioSubmenu.Visible = false;
            panelCuentaSubmenu.Visible = false;
            panelChequesSubmenu.Visible = false;
            panelBeneSubmenu.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelInicioSubmenu.Visible=true)
                panelInicioSubmenu.Visible= false;
            if (panelCuentaSubmenu.Visible = true)
                panelCuentaSubmenu.Visible = false;
            if (panelChequesSubmenu.Visible = true)
                panelChequesSubmenu.Visible = false;
            if (panelBeneSubmenu.Visible = true)
                panelBeneSubmenu.Visible = false;
        }
        private void showShubMenu(Panel submenu)
        {
            if(submenu.Visible==false)
            {
                hideSubMenu();
                submenu.Visible=true;
            }
            else
            {
                submenu.Visible=false;
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            showShubMenu(panelInicioSubmenu);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new CreateAccount());
            //codigo
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            openChildForm(new SelectAccount());
            //codigo
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //codigo
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
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
            openChildForm(new UpdateAccount(this));
            hideSubMenu();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            openChildForm(new DepostiPage(this));
            //codigo
            hideSubMenu();
        }

        private void panelCuentaSubmenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            //codigo
            hideSubMenu();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //codigo
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openChildForm(new SearchBeneciaryPage(this));
            //codigo
            hideSubMenu();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //codigo
            openChildForm(new CreateConcept());
            hideSubMenu();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            openChildForm(new SearchChecks(this));
            //codigo
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (User.ActiveAccount == null)
            {
                MessageBox.Show(
                    $"Debes seleccionar una cuenta para poder continuar",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                openChildForm(new SelectAccount(this));
                return;
            }
            openChildForm(new AccountPage());
            showShubMenu(panelCuentaSubmenu);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (User.ActiveAccount == null)
            {
                MessageBox.Show(
                    $"Debes seleccionar una cuenta para poder continuar",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                openChildForm(new SelectAccount(this));
                return;
            }
            openChildForm(new BeneficiaryPage());
            showShubMenu(panelBeneSubmenu);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (User.ActiveAccount == null)
            {
                MessageBox.Show(
                    $"Debes seleccionar una cuenta para poder continuar",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                openChildForm(new SelectAccount(this));
                return;
            }
            openChildForm(new CheckPage());
            showShubMenu(panelChequesSubmenu);
        }

        private Form activeForm = null;

        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock= DockStyle.Fill;
            panelContenedor.Controls.Add(childForm);
            panelContenedor.Tag =  childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
