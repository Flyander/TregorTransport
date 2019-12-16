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
    public partial class Bienvenue : Form
    {
        public Bienvenue()
        {
            InitializeComponent();
        }

        private void btnWelcome_Click(object sender, EventArgs e)
        {
            new Connection().Show();
            this.Hide();
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            new MenuLigne().Show();
            this.Hide();
        }

    }
}
