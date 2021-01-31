using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;


[WebService]
public class WebServiceAuth
{
    public AuthUser User;
    [WebMethod]
    [SoapHeader("User",Required = true)]
    public string HelloWorld()
    {
        if (User!= null)
        {
            if (User.IsValid())
                return "Hello" + " "+ User.UserName;
            else
                return "Invalid user details";
        }return "Please provide user details";
    }
  
}