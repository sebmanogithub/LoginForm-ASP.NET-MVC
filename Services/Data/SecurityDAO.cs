using LoginMVCWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LoginMVCWebApp.Services.Data
{
    public class SecurityDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        internal bool FindByUser(UserModel user)
        {
            bool success = false;

            string queryString = $"SELECT * from dbo.Users WHERE" +
                $" username=@Username AND password = @Password";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(queryString, sqlConnection);
                cmd.Parameters.Add("@Username", System.Data.SqlDbType.VarChar, 50).Value = user.UserName;
                cmd.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;

                try
                {
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return success;

        }
    }
}