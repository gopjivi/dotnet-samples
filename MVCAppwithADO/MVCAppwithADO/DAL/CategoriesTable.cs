using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using MVCAppwithADO.Models;
using System.Data;

namespace MVCAppwithADO.DAL
{
    public class CategoriesTable
    {

        static string con = System.Configuration.ConfigurationManager.ConnectionStrings["adostring"].ConnectionString;

        SqlConnection connection = new SqlConnection(con);

        public List<Category> GetCategories()
        {
            List<Category> lst = new List<Category>();
            string query = "Select * From Categories ";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            connection.Open();
            da.Fill(dt);
            connection.Close();
            foreach (DataRow dr in dt.Rows)
            {

                lst.Add(

                    new Category
                    {

                        ID = Convert.ToInt32(dr["ID"]),
                        Name = Convert.ToString(dr["Name"]),
                        DisplayOrder = Convert.ToInt32(dr["DisplayOrder"]),
                        CreatedDateTime = Convert.ToDateTime(dr["CreatedDateTime"])

                    }
                    );
            }
            return lst;
        }

        //To Add Category details    
        public bool AddCategory(Category obj)
        {


            SqlCommand com = new SqlCommand("AddCategory", connection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@DisplayOrder", obj.DisplayOrder);
            com.Parameters.AddWithValue("@CreatedDateTime", obj.CreatedDateTime);

            connection.Open();
            int i = com.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }
        }

        //To Update Category details    
        public bool UpdateCategory(Category obj)
        {

            
            SqlCommand com = new SqlCommand("UpdateCategory", connection);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", obj.ID);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@DisplayOrder", obj.DisplayOrder);
            com.Parameters.AddWithValue("@CreatedDateTime", obj.CreatedDateTime);
            connection.Open();
            int i = com.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCategory(int Id)
        {

           
            SqlCommand com = new SqlCommand("DeleteCategory", connection);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", Id);

            connection.Open();
            int i = com.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

    }
}