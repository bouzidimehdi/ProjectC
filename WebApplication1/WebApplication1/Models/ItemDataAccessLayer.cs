using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ItemDataAccessLayer
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=aspnet-WebApplication1-53bc9b9d-9d6a-45d4-8429-2a2761773502;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //To View all employees details   
        public IEnumerable<Items> GetAllEmployees()
        {
            List<Items> lstemployee = new List<Items>();
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Product WHERE ID < 5", con);
                cmd.CommandType = CommandType.Text;


                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Items employee = new Items();

                    employee.ID = Convert.ToInt32(rdr["ID"]);
                    employee.QueryName = rdr["QueryName"].ToString();
                    employee.HeaderImage = rdr["HeaderImage"].ToString();


                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }



    }
}
