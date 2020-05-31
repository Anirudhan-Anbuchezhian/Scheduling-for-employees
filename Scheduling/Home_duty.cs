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
    public partial class Home_duty : Form
    {
        public Home_duty()
        {
            InitializeComponent();
        }

        string status;
        string status_des;
        database data_base = new database();
        private void Add_duty_Click(object sender, EventArgs e)
        {
            DataSet dt = new DataSet();
            dt = data_base.check_duty_exists(textBox1.Text, status);

            int i = dt.Tables[0].Rows.Count;
            if (!(i > 0))
            {
                string result = data_base.createduty(textBox1.Text, status, status_des);
                MessageBox.Show(result);
                show();
            }
            else {
                MessageBox.Show("duty already exists");
            }
        }

        void show()
        {
            DataTable dt = new DataTable();
            dt = data_base.disduty();

            //displaying the values in the datagridview1
            int n;
            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
            }
        }

        private void Home_duty_Load(object sender, EventArgs e)
        {
            show();
        }

        private void Delete_duty_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[0].Value != null)
            {   
                string duty = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string name = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string result = data_base.deleduty(name, duty);
                MessageBox.Show(result);
                show();
            }
            else
            {
                MessageBox.Show("please select a employee from the table to delete");
            }
        }

        private void Day_CheckedChanged(object sender, EventArgs e)
        {
            status = "D";
            status_des = "Day duty";
        }

        private void Night_CheckedChanged(object sender, EventArgs e)
        {
            status = "N";
            status_des = "Night duty";
        }

        private void Evening_CheckedChanged(object sender, EventArgs e)
        {
            status = "E";
            status_des = "Evening duty";
        }

    }
}
