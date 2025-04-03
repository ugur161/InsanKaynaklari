using Islemler;
using login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace departmanlar
{
    public partial class Departmanlar : Form
    {
        public Departmanlar()
        {
            InitializeComponent();
        }


        DataTable tablo = new DataTable();
        DepartmanIslemleri di = new DepartmanIslemleri();

        private async void Form1_Load(object sender, EventArgs e)
        {
            tablo = await di.TamaminiGetirAsync("", null);
            dataGridView1.DataSource = tablo;
            comboBox1.DataSource = await di.TamaminiGetirAsync("", null);
            comboBox1.DisplayMember = "departmnaAdı";
            comboBox1.ValueMember = "ID";

        }
        public async void deparmanY()
        {
            comboBox1.DataSource = await di.TamaminiGetirAsync("", null);
        }

       

        private async void button2_Click(object sender, EventArgs e)
        {
            var IdParam = new Dictionary<string, object>()
            {
                {"@ID", label5.Text}
            };
            await di.SilAsync("", IdParam);
            tablo.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            MessageBox.Show("departman silindi.");

        }

        private async void button3_Click_1(object sender, EventArgs e)
        {

            var eklemeParam = new Dictionary<string, object>()
            {

               {"@departmanAdi",comboBox1.Text},
               {"@telefon",textBox1.Text.Trim() },
                {"@departmanAciklama",richTextBox1.Text }

            };
            long ID = await di.EkleAsync("", eklemeParam);
            var IdParam = new Dictionary<string, object>()
            {
                {"@ID", ID}
            };
            DataRow EklenenDepartman = await di.TekilGetirAsync("", IdParam);
            if (EklenenDepartman != null)
            {
                DataRow yeniSatir = tablo.NewRow();
                for (int i = 0; i < tablo.Columns.Count; i++)
                {
                    yeniSatir[i] = EklenenDepartman[i];
                }
                tablo.Rows.InsertAt(yeniSatir, 0);
            }

            MessageBox.Show("departman eklendi.");
        }

       

        private async void button5_Click(object sender, EventArgs e)
        {
            var eklemeParam = new Dictionary<string, object>()
            {

               {"@departmanAdi",comboBox1.Text},
               {"@telefon",textBox1.Text.Trim() },
                {"@departmanAciklama",richTextBox1.Text },
                {"@id",label5.Text }

            };
            await di.GuncelleAsync("", eklemeParam);
            var sorguP = new Dictionary<string, object>()
            {
                {"@ID", label5.Text}
            };
           
            
            DataRow gelen = await di.TekilGetirAsync("", sorguP);
            if (gelen != null)
            {
                int index = dataGridView1.CurrentRow.Index;
                DataRow yeniSatir=tablo.NewRow();
                for (int i = 0; i < tablo.Columns.Count; i++) 
                { 
                    yeniSatir[i]=gelen[i];
                }
                tablo.Rows.RemoveAt(index);
                tablo.Rows.InsertAt(yeniSatir,index);

            }
            MessageBox.Show("departman güncellendi");

        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            anaMenu ana = new anaMenu();
            ana.Show();
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            parcala();
        }
        private void parcala()
        {
            if (dataGridView1.CurrentRow.Index > -1)
            {
               comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                richTextBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                label5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();


            }

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

            comboBox1.SelectedIndex = -1;
            ekleTBox.Clear();
            textBox1.Clear();
            richTextBox1.Clear();

        }

       
    }
    }
        


