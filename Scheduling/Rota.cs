using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling
{
    public partial class Rota : Form
    {
        public Rota()
        {
            InitializeComponent();
        }
        public DateTime from;
        public DateTime to;
        database data_base = new database();
       // DataTable dt = new DataTable();
        private void Rota_Load(object sender, EventArgs e)
        {
            show();
        }

        void show()
        {
            DataTable dt = new DataTable();
            dt = data_base.dis_schedule(from);

            int n;
            dataGridView1.Rows.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                n = dataGridView1.Rows.Add();

                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = dr[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = dr[6].ToString();
                dataGridView1.Rows[n].Cells[7].Value = dr[7].ToString();
            }
        }

        void search(string ID)
        {
           
            DataTable dt = new DataTable();
            dt = data_base.search_schedule(ID, from);
            int n;
            dataGridView1.Rows.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                n = dataGridView1.Rows.Add();

                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = dr[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = dr[6].ToString();
                dataGridView1.Rows[n].Cells[7].Value = dr[7].ToString();


            }
        }


        private void search_emp_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                show();
            }
            else
            {
                search(textBox1.Text);
            }
        }


        //MessageBox.Show("Please enter a 7 digit employee ID to search for");

    }
}
