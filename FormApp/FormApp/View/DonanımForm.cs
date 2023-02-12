using FormApp.ContextData;
using FormApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp.View
{
    public partial class DonanımForm : Form
    {
        DbContextApp dbContext = new DbContextApp();
        string ID = "0";
        public DonanımForm()
        {
            InitializeComponent();
        }

        private void Donanım_Load(object sender, EventArgs e)
        {
            List();
        }
        private void List()
        {
            dataGrid.DataSource = dbContext.Donanım.Where(x => x.Deleted == false).ToList();
        }
        private void Save(Donanım donanım, bool Deleted = false, string Marka = "", string Model = "", string SeriNo = "", string Kategori = "", string ArizaAciklama = "", bool Modife = false)
        {
            if (Deleted)
            {
                //dbContext.Donanım.Remove(donanım);
                donanım.Deleted = true;
            }
            else if (!Modife)
            {
                donanım = new Donanım()
                {
                    Marka = Marka,
                    Model = Model,
                    SeriNo = SeriNo,
                    Kategori = Kategori,
                    ArizaAciklama = ArizaAciklama,
                    Deleted = Deleted,
                    Status = true,
                    Modife = Modife,
                    CreateDate = System.DateTime.Now

                };
                dbContext.Donanım.Add(donanım);
            }
            else
            {
                donanım.Marka = Marka;
                donanım.Model = Model;
                donanım.SeriNo = SeriNo;
                donanım.Kategori = Kategori;
                donanım.ArizaAciklama = ArizaAciklama;
                donanım.Deleted = false;
                donanım.Status = true;
                donanım.Modife = Modife;

            }
            dbContext.SaveChanges();
            MessageBox.Show("Başarılı", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clear();
            List();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
                MessageBox.Show("Eksik Alanları Kontrol Ediniz.", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                Save(new Donanım(), false, txtMarka.Text, txtModel.Text, txtSeriNo.Text, txtKategori.Text, txtAciklama.Text, false);


        }
        private void Clear()
        {
            foreach (Control i in Controls)
            {
                if (i is TextBox)
                {
                    i.Text = "";
                    i.CausesValidation = false;
                }
            }
        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dataGrid.CurrentRow.Cells[0].Value.ToString();
            txtMarka.Text = dataGrid.CurrentRow.Cells[1].Value.ToString();
            txtModel.Text = dataGrid.CurrentRow.Cells[2].Value.ToString();
            txtSeriNo.Text = dataGrid.CurrentRow.Cells[3].Value.ToString();
            txtKategori.Text = dataGrid.CurrentRow.Cells[4].Value.ToString();
            txtAciklama.Text = dataGrid.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ID);
            var donanim = dbContext.Donanım.FirstOrDefault(x => x.ID == id);
            Save(donanim, false, txtMarka.Text, txtModel.Text, txtSeriNo.Text, txtKategori.Text, txtAciklama.Text, true);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ID);
            var donanim = dbContext.Donanım.FirstOrDefault(x => x.ID == id);
            Save(donanim, true);
        }

        private void txtMarka_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMarka.Text))
            {
                e.Cancel = true;
                txtMarka.Focus();
                errorProvider1.SetError(txtMarka, "Lütfen Marka Bilgisi Giriniz. ");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMarka, "");
            }

        }

        private void txtModel_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtModel.Text))
            {
                e.Cancel = true;
                txtModel.Focus();
                errorProvider1.SetError(txtModel, "Lütfen Model Bilgisi Giriniz. ");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtModel, "");
            }

        }

        private void txtSeriNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSeriNo.Text))
            {
                e.Cancel = true;
                txtSeriNo.Focus();
                errorProvider1.SetError(txtSeriNo, "Lütfen SeriNo Bilgisi Giriniz. ");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtSeriNo, "");
            }

        }

        private void txtKategori_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKategori.Text))
            {
                e.Cancel = true;
                txtKategori.Focus();
                errorProvider1.SetError(txtKategori, "Lütfen Kategori Bilgisi Giriniz. ");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtKategori, "");
            }

        }

        private void txtAciklama_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAciklama.Text))
            {
                e.Cancel = true;
                txtAciklama.Focus();
                errorProvider1.SetError(txtAciklama, "Lütfen Açıklama Bilgisi Giriniz. ");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAciklama, "");
            }


        }
    }
}
