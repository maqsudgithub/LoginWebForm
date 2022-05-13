using Microsoft.Data.SqlClient;
using System.Data;

namespace LoginWebForm.DL
{

    public class Helper
    {
        static SqlConnection con = new SqlConnection("Data Source=Maqsud4772\\Maqsud4772;initial catalog=LoginWebForm;integrated security=true");
        
        
        
        
        
        
        public static DataTable GetDataTable(string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public static DataTable GetDataTable(string query, SqlParameter[] prm)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.SelectCommand.Parameters.AddRange(prm);
            da.Fill(dt);
            return dt;

        }

    }
}
