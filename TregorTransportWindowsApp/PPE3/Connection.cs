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
    public partial class Connection : Form
    {
        public Connection()
        {
            InitializeComponent();
            tbxMotDePasse.UseSystemPasswordChar = true;
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckbxAfficher_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbxAfficher.Checked)
            {
                tbxMotDePasse.UseSystemPasswordChar = false;
            }
            else
            {
                tbxMotDePasse.UseSystemPasswordChar = true;
            }
        }

        private void btnEntrer_Click(object sender, EventArgs e)
        {
            using (tregortransportEntities context = new tregortransportEntities())
            {
                var connect = from u in context.user
                              where u.nom == tbxIdentifiant.Text && u.password==tbxMotDePasse.Text
                              select new
                              {
                                  
                              };
                if (connect.Count() == 1)
                {
                    new Menu().Show();
                    this.Hide();
                }
                else
                {
                    lblIncorrect.Visible = true;
                }
            }
            
        }

        private void Connection_Load(object sender, EventArgs e)
        {
        }

    }
}
