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
    public partial class CreateConcept : Form
    {
        Concept concept = new Concept();

        public CheckPage checkPage;
        public CreateConcept()
        {
            InitializeComponent();
        }

        public CreateConcept(CheckPage checkPage)
        {
            InitializeComponent();
            this.checkPage = checkPage;
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            concept.CreateConceptSQL(name);
            if (checkPage != null) checkPage.InitCBConcepts();
            this.Close();
        }
    }
}
