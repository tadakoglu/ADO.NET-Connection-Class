using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TAYFUNADAKOGLU
{
    class Connection
    {
        string str;
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataAdapter adapter;

        public Connection()
        {
            str = "Server=TADAKOGLU\\SERVER;Database=BUSDB;Trusted_Connection=True";
            //str = "Data Source = TADAKOGLU\\SERVER; Initial Catalog = BUSDB; Integrated Security = True";
        }

        public DataTable gettb(string command)
        {
            DataTable table = new DataTable();
            cnn = new SqlConnection(str);
            cmd = new SqlCommand(command, cnn);
            adapter = new SqlDataAdapter(cmd);

            adapter.Fill(table);
            return table;
         }

        public bool control(string cmd)
        {            
            DataTable tb;
            tb = gettb(cmd);
            if (tb.Rows.Count > 0)
                return true;
            return false;
        }

        public bool runcmd(string command)
        {
            cnn = new SqlConnection(str);
            cmd = new SqlCommand(command,cnn);
            int rowsaffacted = 0;
            try
            {
                cnn.Open();
                rowsaffacted = cmd.ExecuteNonQuery();
            }
            catch
            {
                rowsaffacted = -1;
            }
            finally
            {
                cnn.Close();
            }
            if (rowsaffacted != -1)
            return true;
            return false;
            

        }


     }
}
