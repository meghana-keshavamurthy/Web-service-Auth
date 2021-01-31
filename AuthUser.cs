using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class AuthUser : System.Web.Services.Protocols.SoapHeader
{
    public string UserName { get; set; }
    public string Password { get; set; }

    public bool IsValid()
    {
        int count = 0;

        //You can use database connection to check the userdetails valid or not
        //If user details found return true or else return false

        string config = ConfigurationManager.ConnectionStrings["mycon"].ConnectionString;

        using (SqlConnection sqlcon = new SqlConnection(config))
        {
            SqlCommand sqlcmd = new SqlCommand("Select *from tblAuthUser where UserName='" + UserName + "' and Password='" + Password + "'", sqlcon);
            sqlcmd.Connection.Open();
            count = Convert.ToInt32(sqlcmd.ExecuteScalar());
            sqlcmd.Connection.Close();

            if (count > 0)
                return true;
            else
                return false;
        }
    }
}