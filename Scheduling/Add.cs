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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        database data_base = new database();

        private void Add_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt = data_base.create_empid();
            foreach (DataRow dr in dt.Rows)
            {
                label4.Text = (Int64.Parse(dr[0].ToString()) + 1).ToString();


            }
        }

      
        private void Add_emp_Click(object sender, EventArgs e)
        {
            string result = data_base.create_emp(label4.Text, comboBox1.Text, comboBox2.Text);
            MessageBox.Show(result);
            this.Close();
        }
    }
}
