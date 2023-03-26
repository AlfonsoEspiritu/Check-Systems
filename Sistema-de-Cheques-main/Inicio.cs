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
    public partial class Inicio : Form
    {
        private HomePage dashboardForm;
        public Inicio(HomePage dashboardForm)
        {
            InitializeComponent();
            this.dashboardForm = dashboardForm;
        }
        private Form activeForm;

        //Abrir Formularios y cerrar los que estén abiertos
    


        private void button5_Click(object sender, EventArgs e)
        {
            //AbrirForm(new CreateAccount(this));
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //AbrirForm(new SelectAccount(this));
        }


        public void IniLabel()
        {
            lbActualUser.Text = User.ActiveAccount != null ? $"Cuenta activa: {User.ActiveAccount.Name}" : $"Selecciona una cuenta";
        }
        private void lbActualUser_Click(object sender, EventArgs e)
        {

        }
    }
}
