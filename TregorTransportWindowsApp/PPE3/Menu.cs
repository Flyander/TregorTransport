using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPE3
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }


        private void btnBus_Click(object sender, EventArgs e)
        {
            new MenuLigne().Show();
            this.Hide();
        }

        private void btnChauffeur_Click(object sender, EventArgs e)
        {
            new MenuChauffeur().Show();
            this.Hide();
        }
    }
}
