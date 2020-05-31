using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling
{
    public partial class generate : Form
    {
        public generate()
        {
            InitializeComponent();
        }

        public DateTime from;// = Convert.ToDateTime("2020-01-01");
        public DateTime to;// = Convert.ToDateTime("2020-01-07");
        public DateTime temp;
        CSP_solver sol = new CSP_solver();
        database data_base = new database();

       
        void find_emp()
        {
            int i = 0;
            DataTable dt = new DataTable();
            dt = data_base.find_all_emp();

            foreach (DataRow dr in dt.Rows)
            {
                temp = from;
                while (temp <= to)
                {
                    i++;
                    temp = temp.AddDays(1);
                }

            }
            sol.emp_size = i;
            i = -1;
            
                foreach (DataRow dr in dt.Rows)
                {
                temp = from;
                while (temp <= to)
                {

                    i++;
                    sol.employee[i, 0] = dr[0].ToString();
                    sol.employee[i, 1] = dr[1].ToString();
                    sol.employee[i, 2] = dr[2].ToString();
                    sol.employee[i, 3] = temp.ToString("d");
                    sol.employee[i, 4] = dr[3].ToString();
                    temp = temp.AddDays(1);
                }
               
            }

        }

        void find_duty()
        {

            int i= 0;
            int j = -1;
            int m = 0;
            int tem = 0;

            DataTable dt = new DataTable();
            dt = data_base.find_all_duty();

           foreach (DataRow dr in dt.Rows)
            {
                i++;
                j++;
                sol.duty[j, 0] = dr[0].ToString();
                sol.duty[j, 1] = dr[1].ToString();
                sol.duty[j, 2] = dr[2].ToString();
                sol.duty[j, 3] = dr[3].ToString();

            }
            // sol.duty_size = i;
            //sol.randomize();

            DataTable dt1 = new DataTable();
            dt1 = data_base.find_all_dayoff();

            foreach (DataRow dr1 in dt1.Rows)
            {
                int k = Int32.Parse(dr1[2].ToString());
                while (k < 7)
                {
                    m++;
                    k++;
                }
            }

             while (tem < m)
            {
                tem++;
                i++;
                j++;
                sol.duty[j, 0] = "RD" + tem.ToString();
                sol.duty[j, 1] = "O";
                sol.duty[j, 2] = "";
                sol.duty[j, 3] = "3928";
            }

            sol.duty_size = i;
        }


        private void Generate_Load(object sender, EventArgs e)
        {
            show();
            rem_duty();
            fin_check();
        }

        void fin_check()
        {
            DataTable dt = new DataTable();
            dt = data_base.finalise_check(from, to);
            int n= 0;
           
            foreach (DataRow dr in dt.Rows)
            {
              if (dr[0].ToString() != "")
                {
                    n++;
                }


            }
            if (n > 0)
            {
                generate_rota_c.Enabled = false;
                delet.Enabled = false;
                finalis.Text = "unfinalise";
            }
        }

       void rem_duty()
        {
           
            DataTable dt = new DataTable();
            dt = data_base.unallo_duty(from, to);

            int n;
            dataGridView3.Rows.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                n = dataGridView3.Rows.Add();
                dataGridView3.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView3.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView3.Rows[n].Cells[2].Value = dr[2].ToString();


            }
        }
        void show()
        {
            DataTable dt = new DataTable();
            dt = data_base.dis_route(from,to);

            int n;
            dataGridView1.Rows.Clear();

            foreach (DataRow dr in dt.Rows)
            {
                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
            }

        }

       
        void delete_rota()
        {
            string str = "server=mysql.cms.gre.ac.uk;user id=aa0854y;password=Gertrud9915@;database=mdb_aa0854y";
            MySqlConnection connection = new MySqlConnection(str);

            connection.Open();

            string stri = "DELETE FROM `created_duty` WHERE `status` = ''";

            MySqlCommand cmd = new MySqlCommand(stri, connection);

            try
            {
                MySqlDataReader rd = cmd.ExecuteReader();
                rd.Close();
            }
            catch (Exception ex1)
            {
                ex1.ToString();
            }

            string stri1 = "DELETE FROM `Scheduling` WHERE `status` = ''";

            MySqlCommand cmd1 = new MySqlCommand(stri1, connection);

            try
            {
                MySqlDataReader rd1 = cmd1.ExecuteReader();
                rd1.Close();
            }
            catch (Exception ex1)
            {
                ex1.ToString();
            }
        }
       

    
        private void finalis_Click(object sender, EventArgs e)
        {
            if (finalis.Text == "finalise")
            {
                data_base.finalise_("1", from, to);
                generate_rota_c.Enabled = false;
                delet.Enabled = false;
                finalis.Text = "unfinalise";
            }
            else if (finalis.Text == "unfinalise")
            {
                data_base.finalise_("", from, to);
                finalis.Text = "finalise";
                generate_rota_c.Enabled = true;
                delet.Enabled = true;

            }
        }

        private void delet_Click(object sender, EventArgs e)
        {
            data_base.delete_schedule();
            show();
            rem_duty();
        }

        private void view_emp_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Cells[0].Value.ToString() != null)
                {
                    view_emp f = new view_emp();

                    f.label2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                    DataTable dt = new DataTable();
                    dt = data_base.dis_route_emp(dataGridView1.CurrentRow.Cells[0].Value.ToString());

                    int n;
                    f.dataGridView1.Rows.Clear();

                    foreach (DataRow dr in dt.Rows)
                    {
                        n = f.dataGridView1.Rows.Add();
                        f.dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                        f.dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                        f.dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();


                    }
                    f.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("please select a route to view employees working on that date");
            }

        }

        private void view_rot_Click(object sender, EventArgs e)
        {
            Rota r = new Rota();
            r.from = from;
            r.to = to;
            r.ShowDialog();
        }

        private void generate_rota_c_Click(object sender, EventArgs e)
        {

            try
            {

                if (dataGridView1.CurrentRow.Cells[0].Value.ToString() != null)
                {
                    MessageBox.Show("rota already generated");

                }
            }
            catch (Exception ex)
            {
                int i;
                int j;
                DataTable dt = new DataTable();
                dt = data_base.select_duty();
                foreach (DataRow dr in dt.Rows)
                {
                    temp = from;
                    while (temp <= to)
                    {
                        data_base.create_duty(dr[2].ToString(), dr[0].ToString(), dr[1].ToString(), temp);
                        temp = temp.AddDays(1);
                    }
                }

                sol.from = from;
                sol.to = to;
                find_emp();
                find_duty();
                sol.generate();
                MessageBox.Show("generate rota completed");
                show();
                rem_duty();
            }
        }



    }
    }

