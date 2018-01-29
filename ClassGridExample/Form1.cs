using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace ClassGridExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class deneme
        {
            public deneme(string _a,string _b, int _c, int _d)
            {
                a = _a;
                b = _b;
                c = _c;
                d = _d;
            }

            [DisplayName("kolon 1")]
            public string a { get; set; }

            [DisplayName("b")]
            public string b { get; set; }

            [DisplayName("c")]
            public int c { get; set; }

            [DisplayName("id")]
            public int d { get; set; }
        }

        List<deneme> liste = new List<deneme>();
        int satir = 0; 
 
        private void Form1_Load(object sender, EventArgs e)
        {
           // SetDataGrid();
        }
        /*
        private void SetDataGrid()
        { 
            dataGridView1.Columns.Add("a", "Kolon 1");
            dataGridView1.Columns.Add("b", "b");
            dataGridView1.Columns.Add("c", "c");
            dataGridView1.Columns.Add("d", "id");
        }
        */

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(200); 
                liste.Add(new deneme("a", "b", 1, ++satir));
                //dataGridView1.Invoke((Action)(() => dataGridView1.Rows.Add("a", "b", 1, satir)));
                //dataGridView1.Invoke((Action)(() => dataGridView1.Rows.Insert(0,"a", "b", 1, satir)));
            }
        } 

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            
        }

        private void jsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tmp = liste;
            string json = new JavaScriptSerializer().Serialize(tmp);
            MessageBox.Show(json);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = liste;

        }


        private void gosterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
