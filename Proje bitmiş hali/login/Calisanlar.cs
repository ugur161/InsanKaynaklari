using Islemler;
using login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace calisanlar
{
    public partial class Calisanlar : Form
    {   
        DataTable tablo = new DataTable();
        KulanicilerIslemleri ki = new KulanicilerIslemleri();
        public Calisanlar()
        {
            InitializeComponent();
        }
    
        private async void Form1_Load(object sender, EventArgs e)
        {
            tablo = await ki.TamaminiGetirAsync("", null);
            dataGridView1.DataSource = tablo;

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("mesaj");
                return;
            }
            var eklemeParam = new Dictionary<string, object>()
            {
                {"@TckimlikNo",textBox1.Text.Trim() },
                 {"@Adi",textBox7.Text.Trim() },
                {"@Soyadı",textBox6.Text.Trim() },
                 {"@Telefon",textBox9.Text.Trim() },
                 {"@Adresi",textBox2.Text.Trim() },
                  {"@DogumTarihi",dateTimePicker1.Value }



            };
            long ID = await ki.EkleAsync("", eklemeParam);
            var IdParam = new Dictionary<string, object>()
            {
                {"@ID", ID}
            };
            DataRow EklenenProje = await ki.TekilGetirAsync("", IdParam);
            if (EklenenProje != null)
            {
                DataRow yeniSatir = tablo.NewRow();
                for (int i = 0; i < tablo.Columns.Count; i++)
                {
                    yeniSatir[i] = EklenenProje[i];
                }
                tablo.Rows.InsertAt(yeniSatir, 0);
            }

            MessageBox.Show("çalışan eklendi.");
        }
        

        private void button6_Click(object sender, EventArgs e)
        {
            anaMenu ana = new anaMenu();
            ana.Show();
            this.Close();
        }

        private async void button2_Click(object sender, EventArgs e)
        { 

           if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
             {
                 MessageBox.Show("Boş Kayıt Güncellenemez!");
                 return;
             }
             var eklemeParam = new Dictionary<string, object>()
             {
                {"@TckimlikNo",textBox1.Text.Trim() },
                  {"@Adi",textBox7.Text.Trim() },
                 {"@Soyadı",textBox6.Text.Trim() },
                  {"@Adresi",textBox2.Text.Trim() },
                 {"@Telefon",textBox9.Text.Trim() },
                   {"@DogumTarihi",dateTimePicker1.Value },
                     {  "@ID" ,label13.Text}

             };
             await ki.GuncelleAsync("", eklemeParam);
             var sorguP = new Dictionary<string, object>();
              var IdParam = new Dictionary<string, object>()
             {
                 {"@ID",label13.Text},
             };
            // DataRow gelen = await ki.TekilGetirAsync("", sorguP);
             DataRow EklenenProje = await ki.TekilGetirAsync("", IdParam);
             if (EklenenProje != null)
             {
                 DataRow yeniSatir = tablo.NewRow();
                 for (int i = 0; i < tablo.Columns.Count; i++)
                 {
                     yeniSatir[i] = EklenenProje[i];
                 }
                 int index = dataGridView1.CurrentRow.Index;
                 tablo.Rows.RemoveAt(index);
                 tablo.Rows.InsertAt(yeniSatir, index);
             }
             MessageBox.Show("Çalışan Güncellendi.");
            temizle();
        }
        private void parcala()
        {
           
            if (dataGridView1.CurrentRow.Index > -1)
            {
                label13.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
               
                

                string dateString = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                if (DateTime.TryParse(dateString, out DateTime parsedDate))
                {
                    dateTimePicker1.Value = parsedDate;
                }
                else
                {
                    // Handle invalid date format
                }
            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            parcala();
        }

        private async void button3_Click(object sender, EventArgs e)
        {

            if (label13.Text == "-1")
            {
                MessageBox.Show("Silinecek Kaydı Seçiniz");
                return;
            }
            var IdParam = new Dictionary<string, object>()
            {
                {"@ID", label13.Text}
            };
            await ki.SilAsync("", IdParam);
            tablo.Rows.RemoveAt(dataGridView1.CurrentRow.Index);

            MessageBox.Show("çalışan silindi.");
            temizle();

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
            tablo.DefaultView.RowFilter = string.Format("isim LIKE '%{0}%' OR soyisim LIKE '%{0}%'", textBox8.Text);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                temizle();
            }
        }

        private void temizle()
        {

            label13.Text = "-1";
            textBox1.Clear();
            textBox7.Clear();
            textBox6.Clear();
            textBox2.Clear(); 
            textBox9.Clear();
      
          

        }
    }
}
