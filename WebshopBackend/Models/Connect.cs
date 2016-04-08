using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebshopBackend.Models
{
    public class Connect
    {
        string serverAddress = "83.255.163.37";
        string database = "Webshop";
        string username = "webshopuser";
        string password = "!LllHhh111";
        public string getConnectionString() {
            return "Server=" + serverAddress + "; Database=" + database + "; User Id=" + username + ";Password=" + password;
        }
    }
}