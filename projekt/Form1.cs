using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace projekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = textBox5.Text;
            dataGridView1.Rows[n].Cells[1].Value = textBox6.Text;
            dataGridView1.Rows[n].Cells[2].Value = textBox7.Text;
            dataGridView1.Rows[n].Cells[3].Value = comboBox1.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "Firma";
            dt.Columns.Add("Tytul");
            dt.Columns.Add("NazwaFirmy");
            dt.Columns.Add("Rejestrator1");
            dt.Columns.Add("Rejestrator2");
            ds.Tables.Add(dt);

            DataTable dt1 = new DataTable();
            dt1.TableName = "InformacjeOPracowniku";
            dt1.Columns.Add("ID");
            dt1.Columns.Add("Imie");
            dt1.Columns.Add("Nazwisko");
            dt1.Columns.Add("Zgoda_RODO");
            ds.Tables.Add(dt1);

            DataRow row = ds.Tables["Firma"].NewRow();
            row["Tytul"] = textBox1.Text;
            row["NazwaFirmy"] = textBox2.Text;
            row["Rejestrator1"] = textBox3.Text;
            row["Rejestrator2"] = textBox4.Text;
            ds.Tables["Firma"].Rows.Add(row);

            
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                DataRow row1 = ds.Tables["InformacjeOPracowniku"].NewRow();
                row1["ID"] = Convert.ToString(r.Cells[0].Value);
                row1["Imie"] = Convert.ToString(r.Cells[1].Value);
                row1["Nazwisko"] = Convert.ToString(r.Cells[2].Value);
                row1["Zgoda_RODO"] = Convert.ToString(r.Cells[3].Value);
                ds.Tables["InformacjeOPracowniku"].Rows.Add(row1);
                
            }
            
            ds.WriteXml("C:\\Users\\Admin\\Downloads\\Szkoła\\Język opisu dokumentów elektronicznych\\projekt Biblioteka\\Bibioteka\\Biblioteka\\Dane.xml");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("C:\\Users\\Admin\\Downloads\\Szkoła\\Język opisu dokumentów elektronicznych\\projekt Biblioteka\\Bibioteka\\Biblioteka\\Dane.xml");
            textBox1.Text = ds.Tables["Firma"].Rows[0][0].ToString();
            textBox2.Text = ds.Tables["Firma"].Rows[0][1].ToString();
            textBox3.Text = ds.Tables["Firma"].Rows[0][2].ToString();
            textBox4.Text = ds.Tables["Firma"].Rows[0][3].ToString();
            foreach(DataRow item in ds.Tables["InformacjeOPracowniku"].Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["ID"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Imie"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["Nazwisko"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item["Zgoda_RODO"].ToString();
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectedRows[0].Cells[0].Value = textBox5.Text;
            dataGridView1.SelectedRows[0].Cells[1].Value = textBox6.Text;
            dataGridView1.SelectedRows[0].Cells[2].Value = textBox7.Text;
            dataGridView1.SelectedRows[0].Cells[3].Value = comboBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
        }
    }
}
