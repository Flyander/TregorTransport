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
    public partial class MenuLigne : Form
    {
        public MenuLigne()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            new Menu().Show();
            this.Hide(); 
        }

        private void MenuLigne_Load(object sender, EventArgs e)
        {
            lireTousLesEntreprises();
            
            btnModifier.Visible = false;
            cbxRechercheEntreprise.SelectedValue = 1;
            
        }

        private void lireTousLesEntreprises()
        {
            using (tregortransportEntities context = new tregortransportEntities())
            {

                cbxRechercheEntreprise.DataSource = context.entreprise.ToList();
                cbxRechercheEntreprise.DisplayMember = "code_siret";
                cbxRechercheEntreprise.ValueMember = "id";
            }
            this.lireTousLesLignes();
            
        }

        private void lireTousLesLignes()
        {
            using (tregortransportEntities context = new tregortransportEntities())
            {

                cbxRechercheLigne.DataSource = context.ligne.ToList();
                //.SingleOrDefault(c => c.les_lignes_id == int.Parse(cbxRechercheEntreprise.SelectedValue.ToString()))
                cbxRechercheLigne.DisplayMember = "nom";
                cbxRechercheLigne.ValueMember = "id";
            }
        }
        private void ApresActionBtn()
        {
            btnModifier.Visible = false;
            btnSuppr.Visible = false;
            cbxRechercheLigne.Text = "";
            cbxRechercheEntreprise.Text = "";
        }

        private void AfficheDetailLigne()
        {
            using (tregortransportEntities context = new tregortransportEntities())
            {
                var idEntrep = int.Parse(cbxRechercheEntreprise.SelectedValue.ToString());
                // Remplissage du  datagrid mgsalaries
                var detail = from l in context.ligne
                             join e in context.entreprise
                             on l.les_lignes_id equals e.id
                             join u in context.utilisation
                             on l.id equals u.l_utilisation_id into lig
                             from line in lig.DefaultIfEmpty()
                             where e.id == idEntrep
                             select new
                             {
                                 Nom = l.nom,
                                 Entreprise = e.code_siret,
                                 Nbticket = line == null ? "Non utilisé" : line.id.ToString()

                             };
                dataGridView1.DataSource = detail.ToList();

            }

        }

        private void cbxRechercheLigne_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRechercheLigne.ValueMember != "")
            {
                using (tregortransportEntities context = new tregortransportEntities())
                {
                    int selection = int.Parse(cbxRechercheLigne.SelectedValue.ToString());

                    var laLigne = context.ligne.SingleOrDefault(c => c.id == selection);
                    if (laLigne != null)
                    {
                        btnModifier.Visible = true;
                        btnSuppr.Visible = true;
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

        private void cbxRechercheEntreprise_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRechercheEntreprise.ValueMember != "")
            {
                using (tregortransportEntities context = new tregortransportEntities())
                {
                    int selection = int.Parse(cbxRechercheEntreprise.SelectedValue.ToString());

                    var laLigne = context.ligne.SingleOrDefault(c => c.id == selection);
                    if (laLigne != null)
                    {
                        this.AfficheDetailLigne();
                    }
                    else
                    {
                        
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
            cbxRechercheLigne.SelectedIndex = cbxRechercheLigne.FindStringExact(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow ligneSelectionnee = null;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                ligneSelectionnee = dataGridView1.SelectedRows[0];
            }

            if (ligneSelectionnee == null) return;

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (btnModifier.Visible == false)
            {
                using (tregortransportEntities context = new tregortransportEntities())
                {
                    var lentrepmaj = context.entreprise.SingleOrDefault(c => c.code_siret == cbxRechercheEntreprise.Text);
                    ligne laLigne = new ligne
                    {
                        les_lignes_id = lentrepmaj.id,
                        nom = cbxRechercheLigne.Text
                    };

                    context.ligne.Add(laLigne);
                    // execution de la requete
                    context.SaveChanges();
                }
                this.lireTousLesEntreprises();
                this.lireTousLesLignes();
                this.AfficheDetailLigne();
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

        private void btnModifier_Click(object sender, EventArgs e)
        {
            using (tregortransportEntities context = new tregortransportEntities())
            {
                int ligneID = int.Parse(cbxRechercheLigne.SelectedValue.ToString());
                // instantiation d'un nouveau salarié
                if (ligneID != 0)
                {
                    var lignemaj = context.ligne.SingleOrDefault(c => c.id == ligneID);
                    if (lignemaj != null)
                    {
                        lignemaj.nom = cbxRechercheLigne.Text;
                        lignemaj.les_lignes_id = int.Parse(cbxRechercheEntreprise.SelectedValue.ToString());
                    }
                    
                }
                context.SaveChanges();
                ApresActionBtn();
            }

            this.lireTousLesLignes();
            this.AfficheDetailLigne();
        }

        private void btnSuppr_Click(object sender, EventArgs e)
        {
            using (tregortransportEntities context = new tregortransportEntities())
            {
                int ligneID = int.Parse(cbxRechercheLigne.SelectedValue.ToString());

                if (ligneID != 0)
                {
                    var lignemaj = context.ligne.SingleOrDefault(c => c.id == ligneID);
                    context.ligne.Remove(lignemaj);
                    context.SaveChanges();
                }
            }
            this.lireTousLesLignes();
            this.AfficheDetailLigne();
            ApresActionBtn();
        }
    }
}
