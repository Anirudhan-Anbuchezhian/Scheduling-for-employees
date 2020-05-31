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

namespace Scheduling
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }


        database data_base = new database();
        Add a = new Add();
        generate g = new generate();
        Home_duty d = new Home_duty();



        private void Home_Load(object sender, EventArgs e)
        {
            show();
        }


        
        private void view_generate_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(dateTimePicker1.Text).DayOfWeek == DayOfWeek.Saturday && Convert.ToDateTime(dateTimePicker2.Text).DayOfWeek == DayOfWeek.Friday && (Convert.ToDateTime(dateTimePicker2.Text) - Convert.ToDateTime(dateTimePicker1.Text)).TotalDays <= 7)
            {
                g.from = Convert.ToDateTime(dateTimePicker1.Text);
                g.to = Convert.ToDateTime(dateTimePicker2.Text);
                g.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a week starting from saturday to friday");
            }
        }


        void show()
        {
            // creating a datatable and assigning it values from calling the database class functino dis_emp()
            DataTable dt = new DataTable();
            dt = data_base.dis_emp();

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


        private void Add_Click(object sender, EventArgs e)
        {
            // opening a new windows form to add an employee

            a.ShowDialog();
            show();
        }



        private void delete_Click(object sender, EventArgs e)
        {
            // deleting an new employee from the database

            if (dataGridView1.CurrentRow.Cells[0].Value != null)
            {
                string name = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string result = data_base.dele_emp(name);
                MessageBox.Show(result);
                show();
            }
            else
            {
                MessageBox.Show("please select a employee from the table to delete");
            }
        }

        private void Add_duty_Click(object sender, EventArgs e)
        {
            d.ShowDialog();
        }


    }
}
