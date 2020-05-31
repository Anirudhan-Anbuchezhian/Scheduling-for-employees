using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling
{
    class CSP_solver
    {
        public int emp_size = 0;
        public int duty_size = 0;
        public int csp_size = 0;
        public string[,] employee = new string[1000,5];
        public string[,] duty = new string[1000,4];
        database data_base = new database();
        public DateTime now;
        public DateTime from;
        public DateTime to;
        public string[,] csp = new string[1000, 7];
        public string[,] backtrack = new string[1000 * 1000, 7];
       

// algorithm that uses backtracking and forward checking
        public void generate()
        {
      // randomize();
        
         Array.Clear(csp, 0, csp.Length);
         Array.Clear(backtrack, 0, backtrack.Length);
                   
         Boolean a = false;                              
         int c = 0;
         int k = -1;

            for (int i = 0; i < emp_size; i++)
            {
                for (int j = 0; j < duty_size; j++)
                {
                    c = 0;
                    for (int z = 0; z <= k; z++)
                    {
                        if (backtrack[z, 0] == employee[i, 0] && backtrack[z, 2] == "RD")
                        {
                            c = 1;
                            break;
                        }
                        if (backtrack[z, 0] == employee[i, 0] && backtrack[z, 2] == duty[j, 1] && backtrack[z, 4] == duty[j, 2] && backtrack[z, 3] == employee[i, 3])
                        {
                            c = 1;
                            break;
                        }
                    }
                    if (c == 0)
                    {
                        if (duty[j, 1] == "O" || duty[j, 2] == employee[i, 3])
                        {
                            if (constraint1(duty[j, 1], i) && constraint2(duty[j, 0], duty[j, 1], duty[j, 2], i) && constraint3(duty[j, 1], i) && constraint5(duty[j, 1], i))
                            {
                                k++;
                                a = true;
                                csp[i, 0] = employee[i, 0];
                                csp[i, 1] = duty[j, 0];
                                csp[i, 2] = duty[j, 1];
                                csp[i, 3] = employee[i, 3];
                                csp[i, 4] = duty[j, 2];
                                csp[i, 5] = duty[j, 3];
                                csp[i, 6] = employee[i, 4];
                                backtrack[k, 0] = employee[i, 0];
                                backtrack[k, 1] = duty[j, 0];
                                backtrack[k, 2] = duty[j, 1];
                                backtrack[k, 3] = employee[i, 3];
                                backtrack[k, 4] = duty[j, 2];
                                backtrack[k, 5] = duty[j, 3];
                                backtrack[k, 6] = employee[i, 4];
                                break;
                            }
                        }
                    }
                    a = false;
                }

              

                if (a == false)
                {
                    int aka = 0;
                    if (constraint4(i))
                    {
                        // while (i < emp_size)
                        //  {
                        k++;
                        csp[i, 0] = employee[i, 0];
                        csp[i, 1] = "RD";
                        csp[i, 2] = "O";
                        csp[i, 3] = employee[i, 3];
                        csp[i, 4] = employee[i, 3];
                        csp[i, 5] = "3928";
                        csp[i, 6] = employee[i, 4];
                        backtrack[k, 0] = employee[i, 0];
                        backtrack[k, 1] = "RD";
                        backtrack[k, 2] = "O";
                        backtrack[k, 3] = employee[i, 3];
                        backtrack[k, 4] = employee[i, 3];
                        backtrack[k, 5] = "3928";
                        backtrack[k, 6] = employee[i, 4];
                        aka++;
                        //    i++;
                        //      }
                        // break;    
                    }
                    // if (i != 0)
                  //  {
                    if (aka == 0)
                    {
                        for (int b = 0; b <= k; b++)
                        {
                            if (backtrack[b, 0] == employee[i - 1, 0] && backtrack[b, 3] == employee[i - 1, 3])
                            {
                                while (b <= k)
                                {
                                    if (backtrack[b, 0] != employee[i - 1, 0] || backtrack[b, 3] != employee[i - 1, 3])
                                    {
                                        b--;
                                        while (k != b)
                                        {
                                            k--;
                                        }
                                    }
                                    b++;
                                }
                            }
                        }
                        i -= 2;

                    }
                /*      else if(i ==0 && k > 1)
                      {
                          break;
                      }*/
                     //}
                }
            }
            /*
              string s = "";

                  for (int v = 0; v <= k; v++)
                  {
                      s += backtrack[v, 0] + backtrack[v, 1] + backtrack[v, 2] + backtrack[v, 3] + backtrack[v, 4] + backtrack[v, 5] + backtrack[v, 6] + "******";
                  }

                  MessageBox.Show(s);*/

            for (int i = 0; i < emp_size; i++)
            {
                data_base.create_schedule_d(csp[i, 5], csp[i, 6], csp[i, 0], csp[i, 1], csp[i, 2], csp[i, 3]);             
            }
            
        }



// constraint five
        public Boolean constraint5(string duty, int l)
        {
            
            int a = 0;
            if(duty == "N")
            {

               for(int i = 0; i < l; i++)
                {
                    if(employee[l, 0] == csp[i, 0] && csp[i, 2] == "N" && (csp[i, 3] == DateTime.Parse(employee[l, 3]).AddDays(-1).ToString("d") || csp[i, 3] == DateTime.Parse(employee[l, 3]).AddDays(-2).ToString("d"))) //DateTime.Parse(csp[i,3]) >= from && DateTime.Parse(csp[i, 3]) <= to)
                    {
                        a++;
                    }
                }
               if(a >= 2)
                {
                    return false;
                }
            }
            return true;
        }


// Constraint three
        public Boolean constraint3(string duty, int l)
        {           
            int a = Int32.Parse(employee[l, 2]);
            int c = 0;
            int d = 0;
            int b = 7 - a;

            if (duty == "O")
            {              
                for(int i = 0; i<l; i++)
                {
                    if (employee[l, 0] == csp[i, 0] && csp[i, 2] == "O" && DateTime.Parse(csp[i, 3]) >= from && DateTime.Parse(csp[i, 3]) <= to)
                    {
                        c++;
                    }                   
                }
                if(c >= b)
                {
                    return false;
                }
            }
            if(duty == "N" || duty == "D" || duty == "E")
            {
                for (int i = 0; i < l; i++)
                {
                    if (employee[l, 0] == csp[i, 0] && (csp[i, 2] == "D" || csp[i, 2] == "N" || csp[i, 2] == "E") && DateTime.Parse(csp[i, 3]) >= from && DateTime.Parse(csp[i, 3]) <= to)
                    {
                        d++;
                    }
                }
                if (d >= a)
                {
                    return false;
                }
            }
                return true;
        }


// this method randomize all the domain values 
    /*    public void randomize()
        {
            string temp = "";
            string temp1 = "";
            string temp2 = "";
            string temp3 = "";

            int j;
            Random rand = new Random();

            for (int i = 0; i < duty_size; i++)
            {
                j = i + rand.Next(duty_size - i);
                temp = duty[i, 0];
                temp1 = duty[i, 1];
                temp2 = duty[i, 2];
                temp3 = duty[i, 3];
                duty[i, 0] = duty[j, 0];
                duty[i, 1] = duty[j, 1];
                duty[i, 2] = duty[j, 2];
                duty[i, 3] = duty[j, 3];
                duty[j, 0] = temp;
                duty[j, 1] = temp1;
                duty[j, 2] = temp2;
                duty[j, 3] = temp3;

            }
        }*/

// constraint four
        public Boolean constraint4(int l)
        {
            int oa = 0;
            int o = 0;

            if (csp[l, 1] == "RD") 
            {
                return false;
            }
              for (int i = 0; i < duty_size; i++)
                {
                if ((duty[i, 1] == "N" || duty[i, 1] == "D" || duty[i, 1] == "E") && employee[l, 3] == duty[i, 2])
                {
                    oa++;
                }
                for (int j = 0; j < l; j++)
                {
                    
                    if(duty[i, 1] == csp[j, 2] && duty[i, 0] == csp[j, 1] && duty[i, 2] == csp[j, 3]  && employee[l, 3] == csp[j, 3]  && duty[i, 1] != "O")
                    {
                        o++;
                        break; 
                    }
                }
            }
         
            if (o == oa)
            {
                return true;
            }            
                return false;           
        }

// constrain one
        public Boolean constraint1(string duty, int l)
        {
            if ((duty == "D" || duty == "E") && DateTime.Parse(employee[l, 3]) == from)
            {
                DataTable dt = new DataTable();
                dt = data_base.lst_duty(employee[l, 0], DateTime.Parse(employee[l, 3]).AddDays(-1).ToString("d"));
                foreach(DataRow dr in dt.Rows)
                {
                    if(dr[0].ToString() == "N")
                    {
                        return false;
                    }
                }
            }

            if (duty == "D" || duty == "E")
            {
                for (int i = 0; i < l; i++)
                {
                    if (employee[l, 0] == csp[i, 0] && csp[i, 2] == "N" && csp[i, 3] == DateTime.Parse(employee[l, 3]).AddDays(-1).ToString("d"))
                    {
                        return false;
                    }
                }
               
            }
            if(duty == "N")
            {
                for (int i = 0; i < l; i++)
                {
                    if (employee[l, 0] == csp[i, 0] && (csp[i, 2] == "D" || csp[i, 2] == "E") && csp[i, 3] == DateTime.Parse(employee[l, 3]).AddDays(1).ToString("d"))
                    {
                        return false;
                    }
                }
            }
                return true;
        }

        
// constraint two
        public Boolean constraint2(string route, string duty, string date, int l)
        {
            for (int i = 0; i < l; i++)
            {
                if (csp[i, 1] == route && csp[i, 2] == duty && csp[i, 4] == date)
                {
                    
                        return false;
                    
                   
                }
            }
            return true;
        }


        
    }
}

