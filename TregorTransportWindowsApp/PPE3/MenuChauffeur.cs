
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PPE3
{
    public partial class MenuChauffeur : Form
    {
        public MenuChauffeur()
        {
            InitializeComponent();
        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            new Menu().Show();
            this.Hide();
        }

        private void MenuChauffeur_Load(object sender, EventArgs e)
        {
            AfficheDetailChauffeur();
            this.lireTousLesUsers();
            btnModifier.Visible = false;
        }

        private void ApresActionBtn()
        {
            btnModifier.Visible = false;
            btnSuppr.Visible = false;
            tbxPrenom.Text = "";
            tbxAdresse.Text = "";
            tbxTel.Text = "";
            tbxStatut.Text = "";
            tbxEntreprise.Text = "";
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            using (tregortransportEntities context = new tregortransportEntities())
            {
                int chauffeurID = int.Parse(cbxRechercheChauffeur.SelectedValue.ToString());
                // instantiation d'un nouveau salarié
                if (chauffeurID != 0)
                {
                    var chauffeurmaj = context.chauffeur.SingleOrDefault(c => c.id == chauffeurID);
                    if (chauffeurmaj != null)
                    {
                        chauffeurmaj.prenom = tbxPrenom.Text;
                        chauffeurmaj.adresse = tbxAdresse.Text;
                        chauffeurmaj.telephone_c = tbxTel.Text;
                        chauffeurmaj.statut = tbxStatut.Text;
                    }
                    var lentrepmaj = context.entreprise.SingleOrDefault(c => c.code_siret == tbxEntreprise.Text);
                    if (lentrepmaj != null)
                    {
                        chauffeurmaj.le_chauffeur_id = lentrepmaj.id;
                    }
                }
                context.SaveChanges();
                ApresActionBtn();
            }

            this.lireTousLesUsers();
            this.AfficheDetailChauffeur();
        }
        private void btnSuppr_Click(object sender, EventArgs e)
        {
            using (tregortransportEntities context = new tregortransportEntities())
            {
                int chauffeurID = int.Parse(cbxRechercheChauffeur.SelectedValue.ToString());

                if (chauffeurID != 0)
                {
                    var clientmaj = context.chauffeur.SingleOrDefault(c => c.id == chauffeurID);
                    context.chauffeur.Remove(clientmaj);
                    context.SaveChanges();
                }
            }
            this.lireTousLesUsers();
            this.AfficheDetailChauffeur();
            ApresActionBtn();
        }
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (btnModifier.Visible == false)
            {
                using (tregortransportEntities context = new tregortransportEntities())
                {
                    var lentrepmaj = context.entreprise.SingleOrDefault(c => c.code_siret == tbxEntreprise.Text);
                    chauffeur leChauffeur = new chauffeur
                    {
                        nom = cbxRechercheChauffeur.Text,
                        prenom = tbxPrenom.Text,
                        adresse = tbxAdresse.Text,
                        telephone_c = tbxTel.Text,
                        statut = tbxStatut.Text,
                        le_chauffeur_id = lentrepmaj.id
                    };

                    context.chauffeur.Add(leChauffeur);
                    // execution de la requete
                    context.SaveChanges();
                }
                this.lireTousLesUsers();
                this.AfficheDetailChauffeur();
                btnModifier.Visible = true;
                btnSuppr.Visible = true;
                btnAnnule.Visible = false;
            }
            else
            {
                btnModifier.Visible = false;
                btnSuppr.Visible = false;
                btnAnnule.Visible = true;
            }
        }
        private void btnAnnule_Click(object sender, EventArgs e)
        {
            btnModifier.Visible = true;
            btnSuppr.Visible = true;
            btnAnnule.Visible = false;
        }
        private void lireTousLesUsers()
        {
            using (tregortransportEntities context = new tregortransportEntities())
            {

                cbxRechercheChauffeur.DataSource = context.chauffeur.ToList();
                cbxRechercheChauffeur.DisplayMember = "NOM";
                cbxRechercheChauffeur.ValueMember = "ID";
            }
        }

        private void AfficheDetailChauffeur()
        {
            using (tregortransportEntities context = new tregortransportEntities())
            {

                // Remplissage du  datagrid mgsalaries
                var detail = from c in context.chauffeur
                             join u in context.utilisation
                             on c.id equals u.chauffeur_id into util
                             from ut in util.DefaultIfEmpty()
                             join l in context.ligne
                             on ut.l_utilisation_id equals l.id into lig
                             from line in lig.DefaultIfEmpty()
                             select new
                             {
                                 Nom = c.nom,
                                 Prenom= c.prenom,
                                 Ligne= line == null ? "Non assigné":line.nom

                             };
                dataGridView1.DataSource = detail.ToList();

            }

        }
        
        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow ligneSelectionnee = null;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                ligneSelectionnee = dataGridView1.SelectedRows[0];
            }

            if (ligneSelectionnee == null) return;

            /*mtbid.Text = ligneSelectionnee.Cells["ID"].Value.ToString();
            mtbsalarie.Text = ligneSelectionnee.Cells["NOM"].Value.ToString();
            mcbservice.SelectedIndex = mcbservice.FindStringExact(ligneSelectionnee.Cells["DENOMINATION"].Value.ToString());
            */
        }
        private void cbxRechercheChauffeur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRechercheChauffeur.ValueMember != "")
            {
                using (tregortransportEntities context = new tregortransportEntities())
                {
                    int selection = int.Parse(cbxRechercheChauffeur.SelectedValue.ToString());

                    var leChauffeur = context.chauffeur.SingleOrDefault(c => c.id == selection);
                    var lEntreprise = context.entreprise.SingleOrDefault(c => c.id == leChauffeur.le_chauffeur_id);

                    if (leChauffeur != null)
                    {
                        btnModifier.Visible = true;
                        btnSuppr.Visible = true;

                        tbxPrenom.Text = leChauffeur.prenom;
                        tbxAdresse.Text = leChauffeur.adresse;
                        tbxTel.Text = leChauffeur.telephone_c;
                        tbxStatut.Text = leChauffeur.statut;
                        if (lEntreprise != null)
                        {
                            tbxEntreprise.Text = lEntreprise.code_siret;
                        }
                    }
                    else
                    {
                        btnModifier.Visible = false;
                        btnSuppr.Visible = false;
                    }
                }


            }
            else
            {
                btnModifier.Visible = false;
                btnSuppr.Visible = false;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbxRechercheChauffeur.SelectedIndex = cbxRechercheChauffeur.FindStringExact(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        
    }
}
