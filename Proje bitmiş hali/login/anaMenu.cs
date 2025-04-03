using calisanlar;
using departmanlar;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class anaMenu : Form
    {
        public anaMenu()
        {
            InitializeComponent();
        }

        private void departmanlarBTN_Click(object sender, EventArgs e)
        {
            Departmanlar departmanlar = new Departmanlar();
            departmanlar.Show();
            this.Close();
        }

        

      


        private void calisanlarBTN_Click(object sender, EventArgs e)
        {
            Calisanlar cls=new Calisanlar();
            cls.Show();
            this.Close();
        }

       
        

       

       

       
    }
}
