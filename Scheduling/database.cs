using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling
{
    class database
    {

        string str = "server=mysql.cms.gre.ac.uk;user id=aa0854y;password=Gertrud9915@;database=mdb_aa0854y";
        MySqlConnection connection;


// this method selects all the existing employee and returns the datatable
        public DataTable dis_emp()
        {
            // established a connection to database
            connection = new MySqlConnection(str);
            connection.Open();

            // retrive the data from database and returning it
            string stri = "SELECT `employee_id`, `emp_type`, `num_working_days` FROM `Employee_Date` WHERE `removed` = '0'";
            MySqlDataAdapter cmd = new MySqlDataAdapter(stri, connection);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            connection.Close();
            return dt;
        }

// This method updates a column from the table Employee_Date and return a string. it is used so an employee can be deleted
        public string dele_emp(string name)
        {
            // establishing a connectino to database
            connection = new MySqlConnection(str);
            connection.Open();

            // deleting the value from database
            string stri = "UPDATE `Employee_Date` SET `removed`='1' WHERE `employee_id` = '" + name + "'";
            MySqlCommand cmd = new MySqlCommand(stri, connection);
            MySqlDataReader rd;

            try
            {
                rd = cmd.ExecuteReader();
                connection.Close();
                return "Employee deleted from database";
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.Message;
            }
        }


// This method returns employee id with highest in value to create a new employee
        public DataTable create_empid()
        {
            connection = new MySqlConnection(str);
            connection.Open();

            string stri = " SELECT `employee_id` FROM `Employee_Date` order by `employee_id` DESC LIMIT 1";
            MySqlDataAdapter cmd = new MySqlDataAdapter(stri, connection);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            connection.Close();
            return dt;
        }


// This method creates an employee by inserting values that are passed on
        public string create_emp(string emp, string emp_t, string num)
        {
            connection = new MySqlConnection(str);
            connection.Open();

            string stri = "INSERT INTO `Employee_Date`(`employee_id`, `emp_type`, `num_working_days`, `removed`) VALUES ('" + emp + "','" + emp_t + "','" + num + "','0')";
            MySqlCommand cmd = new MySqlCommand(stri, connection);

            try
            {
                MySqlDataReader rd = cmd.ExecuteReader();
                rd.Close();
                connection.Close();
                return "Employee Added";
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.ToString();
            }            
        }

// This method selects the schedule from the database

        public DataTable dis_schedule(DateTime from)
        {
            connection = new MySqlConnection(str);
            connection.Open();

            string stri = "SELECT Scheduling.employee_id , MAX(CASE WHEN Scheduling.date = '" + from.ToString("d") + "' THEN Scheduling.duty END) 'SUN' , MAX(CASE WHEN Scheduling.date = '" + from.AddDays(1).ToString("d") + "' THEN Scheduling.duty END) 'MON' , MAX(CASE WHEN Scheduling.date = '" + from.AddDays(2).ToString("d") + "' THEN Scheduling.duty END) 'TUE' , MAX(CASE WHEN Scheduling.date = '" + from.AddDays(3).ToString("d") + "' THEN Scheduling.duty END) 'WED' , MAX(CASE WHEN Scheduling.date = '" + from.AddDays(4).ToString("d") + "' THEN Scheduling.duty END) 'THU' , MAX(CASE WHEN Scheduling.date = '" + from.AddDays(5).ToString("d") + "' THEN Scheduling.duty END) 'FRI' , MAX(CASE WHEN Scheduling.date = '" + from.AddDays(6).ToString("d") + "' THEN Scheduling.duty END) 'SAT' FROM Scheduling GROUP BY Scheduling.employee_id ASC ORDER BY Scheduling.employee_id ASC";
            MySqlDataAdapter cmd = new MySqlDataAdapter(stri, connection);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            connection.Close();
            return dt;
        }

// This method search the schedule for a perticular employee

        public DataTable search_schedule(string ID, DateTime from)
        {
            connection = new MySqlConnection(str);

            connection.Open();

            string stri = "SELECT Scheduling.employee_id , MAX(CASE WHEN Scheduling.date = '" + from.ToString("d") + "' THEN Scheduling.duty END) 'SUN' , MAX(CASE WHEN Scheduling.date = '" + from.AddDays(1).ToString("d") + "' THEN Scheduling.duty END) 'MON' , MAX(CASE WHEN Scheduling.date = '" + from.AddDays(2).ToString("d") + "' THEN Scheduling.duty END) 'TUE' , MAX(CASE WHEN Scheduling.date = '" + from.AddDays(3).ToString("d") + "' THEN Scheduling.duty END) 'WED' , MAX(CASE WHEN Scheduling.date = '" + from.AddDays(4).ToString("d") + "' THEN Scheduling.duty END) 'THU' , MAX(CASE WHEN Scheduling.date = '" + from.AddDays(5).ToString("d") + "' THEN Scheduling.duty END) 'FRI' , MAX(CASE WHEN Scheduling.date = '" + from.AddDays(6).ToString("d") + "' THEN Scheduling.duty END) 'SAT' FROM Scheduling WHERE Scheduling.employee_id LIKE '%" + ID + "%' GROUP BY Scheduling.employee_id ASC ORDER BY Scheduling.employee_id ASC";
            MySqlDataAdapter cmd = new MySqlDataAdapter(stri, connection);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            connection.Close();
            return dt;
        }

// inserts values into the table created duty: this will be the domain values

        public void create_duty(string duty_id, string route, string duty, DateTime date)
        {
            connection = new MySqlConnection(str);
            connection.Open();

           string stri = "INSERT INTO `created_duty`(`duty_id`, `route`, `duty`, `date`, `allocated_status`, `status`) VALUES (" + Int32.Parse(duty_id) + ", '" + route + "','" + duty + "','" + date.ToString("d") + "','','')";

           MySqlCommand cmd1 = new MySqlCommand(stri, connection);

            try
            {
                MySqlDataReader rd = cmd1.ExecuteReader();
                rd.Close();
            }
            catch (Exception ex1)
            {
                ex1.ToString();
            }
            connection.Close();
        }

// selecting all the values from the duty table

        public DataTable select_duty()
        {
            connection = new MySqlConnection(str);
            connection.Open();

            string stri = "SELECT `route`, `duty`, `duty_id` FROM `Duty_Data` WHERE `duty` <> 'O' AND `Removed` = '0'";
            MySqlDataAdapter cmd = new MySqlDataAdapter(stri, connection);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            connection.Close();
            return dt;
        }

// this method selects all the employee 

        public DataTable find_all_emp()
        {
            connection = new MySqlConnection(str);
            connection.Open();

            string stri = "SELECT `employee_id`, `emp_type`, `num_working_days`, `emp_id` FROM `Employee_Date` WHERE `removed` = '0' order by `emp_type` asc";
            MySqlDataAdapter cmd = new MySqlDataAdapter(stri, connection);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            connection.Close();
            return dt;
        }

// this method selects all the duties

        public DataTable find_all_duty()
        {
            connection = new MySqlConnection(str);
            connection.Open();

            string stri = "SELECT `route`, `duty`, `date`, `created_id` FROM `created_duty` WHERE `duty` <> 'O'";
            MySqlDataAdapter cmd = new MySqlDataAdapter(stri, connection);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            connection.Close();
            return dt;

        }

// this method selects all the rest days

        public DataTable find_all_dayoff()
        {
            connection = new MySqlConnection(str);
            connection.Open();

            string stri1 = "SELECT `employee_id`, `emp_type`, `num_working_days` FROM `Employee_Date` WHERE `removed` = '0'";
            MySqlDataAdapter cmd1 = new MySqlDataAdapter(stri1, connection);
            DataTable dt1 = new DataTable();
            cmd1.Fill(dt1);
            connection.Close();
            return dt1;
        }


// this method returns all the routes

        public DataTable dis_route(DateTime from, DateTime to)
        {
            connection = new MySqlConnection(str);

            connection.Open();

            string stri = "SELECT DISTINCT `route` FROM `created_duty` WHERE `date` BETWEEN '" + from.ToString("d") + "' AND '" + to.ToString("d") + "'";
            MySqlDataAdapter cmd = new MySqlDataAdapter(stri, connection);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            connection.Close();
            return dt;
        }

// this returns distinct routes

        public DataTable finalise_check(DateTime from, DateTime to)
        {

            connection = new MySqlConnection(str);
            connection.Open();

            string stri = "SELECT DISTINCT(`status`) FROM `created_duty` WHERE `date` BETWEEN  '" + from.ToString("d") + "' AND '" + to.ToString("d") + "'";
            MySqlDataAdapter cmd = new MySqlDataAdapter(stri, connection);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            connection.Close();
            return dt;
        }

// returns unallocated duties

        public DataTable unallo_duty(DateTime from, DateTime to)
        {
            connection = new MySqlConnection(str);
            connection.Open();

            string stri = "SELECT `route`, `duty`, `date` FROM `created_duty` WHERE `allocated_status` = '' AND `date` BETWEEN '" + from.ToString("d") + "' AND '" + to.ToString("d") + "'";
            MySqlDataAdapter cmd = new MySqlDataAdapter(stri, connection);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            connection.Close();
            return dt;
        }

// updates status 

        public void finalise_(string type, DateTime from, DateTime to)
        {
            connection = new MySqlConnection(str);
            connection.Open();

            string stri1 = "UPDATE `Scheduling` SET `status`='"+ type +"' WHERE `date` BETWEEN '" + from.ToString("d") + "' AND '" + to.ToString("d") + "'";
            MySqlCommand cmd1 = new MySqlCommand(stri1, connection);
            try
            {
                MySqlDataReader rd1 = cmd1.ExecuteReader();
                rd1.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            string stri = "UPDATE `created_duty` SET `status`='"+ type +"' WHERE `date` BETWEEN '" + from.ToString("d") + "' AND '" + to.ToString("d") + "'";
            MySqlCommand cmd = new MySqlCommand(stri, connection);
            try
            {
                MySqlDataReader rd = cmd.ExecuteReader();
                rd.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            connection.Close();
        }

// returns all the employees working a selected route

        public DataTable dis_route_emp(string route)
        {
            connection = new MySqlConnection(str);
            connection.Open();

            string stri = "SELECT `employee_id`, `date`, `duty` FROM `Scheduling` WHERE `route` = '" + route + "'";
            MySqlDataAdapter cmd = new MySqlDataAdapter(stri, connection);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            connection.Close();
            return dt;
        }

// deletes a generated schedule

        public void delete_schedule()
        {
            connection = new MySqlConnection(str);
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
            connection.Close();
        }

// inserts the schdule to the datbase

        public void create_schedule_d(string c_id, string e_id, string emp_id, string route, string duty, string date)
        {
            connection = new MySqlConnection(str);
            connection.Open();

            string stri = "INSERT INTO `Scheduling`(`created_id`, `emp_id`, `employee_id`, `route`, `duty`, `date`, `status`) VALUES (" + Int32.Parse(c_id) + ", " + Int32.Parse(e_id) + ",'" + emp_id + "','" + route + "','" + duty + "','" + date + "','')";
            MySqlCommand cmd = new MySqlCommand(stri, connection);
            try
            {
                MySqlDataReader rd = cmd.ExecuteReader();
                rd.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            string stri1 = " UPDATE `created_duty` SET `allocated_status`= '1' WHERE `route` = '" + route + "' AND `duty` = '" + duty + "' AND `date` = '" + date + "'";
            MySqlCommand cmd1 = new MySqlCommand(stri1, connection);
            try
            {
                MySqlDataReader rd1 = cmd1.ExecuteReader();
                rd1.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            connection.Close();
        }

// returns last weeks duty of an employee

        public DataTable lst_duty(string emp, string date)
        {
            connection = new MySqlConnection(str);
            connection.Open();

            string stri = "SELECT `duty` FROM `Scheduling` WHERE `employee_id` = '"+ emp +"' AND `date` = '"+ date +"'";
            MySqlDataAdapter cmd = new MySqlDataAdapter(stri, connection);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            connection.Close();
            return dt;
        }

// selects duties from database

        public DataTable disduty()
        {
            connection = new MySqlConnection(str);

            connection.Open();

            string stri = "SELECT `route`, `duty`, `duty_des` FROM `Duty_Data` WHERE `duty` <> 'O' AND `Removed` = '0'";
            MySqlDataAdapter cmd = new MySqlDataAdapter(stri, connection);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            connection.Close();
            return dt;
        }

 // add duties into database
        public string createduty(string route, string duty, string duty_des)
        {
            connection = new MySqlConnection(str);
            connection.Open();

            string stri = "INSERT INTO `Duty_Data`(`route`, `duty`, `duty_des`, `Removed`) VALUES ('"+ route +"', '"+ duty + "', '"+ duty_des +"', '0')";
            MySqlCommand cmd = new MySqlCommand(stri, connection);

            try
            {
                MySqlDataReader rd = cmd.ExecuteReader();
                rd.Close();
                connection.Close();
                return "Duty Added";
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.ToString();
            }
        }


// deleting duty from database

        public string deleduty(string route, string duty)
        {
            connection = new MySqlConnection(str);
            connection.Open();

            string stri = "UPDATE `Duty_Data` SET `Removed`='1' WHERE `route` = '"+ route +"' AND `duty` = '"+ duty +"'";
            MySqlCommand cmd = new MySqlCommand(stri, connection);

            try
            {
                MySqlDataReader rd = cmd.ExecuteReader();
                rd.Close();
                connection.Close();
                return "Duty deleted";
            }
            catch (Exception ex)
            {
                connection.Close();
                return ex.ToString();
            }
        }


//

        public DataSet check_duty_exists(string route, string duty)
        {
            connection = new MySqlConnection(str);

            connection.Open();

            string stri = "SELECT `duty_id` FROM `Duty_Data` WHERE `route` = '"+ route +"' AND `duty` = '"+ duty +"'";
            MySqlDataAdapter cmd = new MySqlDataAdapter(stri, connection);
            DataSet dt = new DataSet();
            cmd.Fill(dt);
            connection.Close();
            return dt;
        }



    }
}
