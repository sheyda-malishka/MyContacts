using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace MyContacts
{
    class ContactsRepository : IContactsRepository
    {
        private string connectionString = "Data Source=.; initial Catalog=Contact_DB; Integrated Security=true";

        public bool Delete(int contactID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "Delete From My_Contacts where ContactID=@ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", contactID);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }

            finally
            {
                connection.Close();

            }

        }



        public bool Insert(string name, string family, string email, string address, string mobile, int age)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                string query = "Insert Into My_Contacts (Name,Family,Email,Address,Mobile,Age) Values(@Name,@Family,@Email,@Address,@Mobile,@Age)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Age", age);
                connection.Open();
                command.ExecuteNonQuery();



                return true;
            }
            catch
            {


                return false;



            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable Search(string parameter)
        {
            string query = "Select * From My_Contacts where Name like @parameter or  Family like @parameter ";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@parameter", "%" + parameter+ "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectAll()
        {
            string query = "Select * From My_Contacts";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;

        }

        public DataTable SelectRow(int contactID)
        {
            string query = "Select * From My_Contacts where ContactID=" + contactID;
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Update(int contactID, string name, string family, string email, string address, string mobile, int age)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = "Update My_Contacts Set Name=@Name,Family=@Family,Email=@Email,Address=@Address,Mobile=@Mobile,Age=@Age where ContactID=@ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", contactID);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@Mobile", mobile);
                command.Parameters.AddWithValue("@Age", age);
                connection.Open();
                command.ExecuteNonQuery();
                return true;


            }
            catch
            {

                return false;
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
