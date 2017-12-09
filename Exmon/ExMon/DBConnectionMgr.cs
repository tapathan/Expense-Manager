using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExMon
{
    public class DBConnectionMgr
    {
        public static SqlConnection GetCon(Boolean open, string InitialSetup)
        {
            string cons = "Data Source=localhost;Initial Catalog=master;Integrated Security=True";
            SqlConnection SqlCon = new SqlConnection(cons);
            SqlConnection SqlConErr = new SqlConnection();
            try
            {
                if (open)
                    SqlCon.Open();
                return SqlCon;
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ERROR:", MessageBoxButtons.OK);
                return SqlConErr;
            }
        }

        public static SqlConnection GetCon(Boolean open)
        {
            try
            {
                string cons = "Data Source=localhost;Initial Catalog=ExMon;Integrated Security=True";

                SqlConnection SqlCon = new SqlConnection(cons);
                if (open)
                    SqlCon.Open();
                return SqlCon;
            }
            catch (Exception Ex)
            {
                string cons = "Data Source=localhost;Initial Catalog=master;Integrated Security=True";
                SqlConnection SqlCon = new SqlConnection(cons);
                SqlConnection SqlConErr = new SqlConnection();
                if (Ex.Message.Contains("Cannot open database"))
                {
                    DialogResult Res = MessageBox.Show("Initial Setups needs to be done.", "DB Not Found", MessageBoxButtons.OKCancel);
                    if (Res == System.Windows.Forms.DialogResult.OK)
                    {
                        if (open)
                            SqlCon.Open();
                        return SqlCon;
                    }
                    else
                        return SqlConErr;
                }
                else
                    MessageBox.Show(Ex.Message, "ERROR:", MessageBoxButtons.OK);
                return SqlConErr;
            }
        }

    }
}
